using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Stations.DataProcessor.Dto;
using Stations.DataProcessor.Dto.Ticket;
using Stations.Models.Enums;
using CardDto = Stations.DataProcessor.Dto.CardDto;
using TripDto = Stations.DataProcessor.Dto.TripDto;

namespace Stations.DataProcessor
{
    using System;
    using Stations.Data;
    using Stations.Models;
    using Newtonsoft.Json;

    public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportStations(StationsDbContext context, string jsonString)
		{
		    var importedStations = ImportJson<Station>(jsonString);

		    var stations = context.Stations.AsNoTracking().ToArray();

            var validStations = new List<Station>();

            StringBuilder sb = new StringBuilder();

		    foreach (var station in importedStations)
		    {
		        bool isValid = !string.IsNullOrWhiteSpace(station.Name) && station.Name.Length <= 50;

		        if (!isValid)
		        {
		            sb.AppendLine(FailureMessage);
                    continue;
		        }

		        //var townName = station.Town;
		        if (string.IsNullOrWhiteSpace(station.Town))
		        {
		            station.Town = station.Name;
		        }
                else if (station.Town.Length > 50)
		        {
		            sb.AppendLine(FailureMessage);
                    continue;
		        }

                //stations.Any(s => s.Name == station.Name) ||
                bool alreadyExists = validStations.Any(s => s.Name == station.Name);
                if(alreadyExists)
                {
                    //⦁	If a station with the same name already exists, ignore the entity. <- is clearly misleading
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                validStations.Add(station);
		        sb.AppendLine(string.Format(SuccessMessage, station.Name));
		    }

            context.Stations.AddRange(validStations);
		    context.SaveChanges();

            return sb.ToString();
		}

		public static string ImportClasses(StationsDbContext context, string jsonString)
		{
		    var importedClasses = ImportJson<SeatingClass>(jsonString);

		    var classes = context.SeatingClasses.AsNoTracking().ToArray();

            var validatedClasses = new List<SeatingClass>();

		    StringBuilder sb = new StringBuilder();

		    foreach (var seatingClass in importedClasses)
		    {

		        bool isValid = !string.IsNullOrWhiteSpace(seatingClass.Name) && seatingClass.Name.Length <= 30 &&
		                       !string.IsNullOrWhiteSpace(seatingClass.Abbreviation) && seatingClass.Abbreviation.Length <= 2;
		        if (!isValid)
		        {
		            sb.AppendLine(FailureMessage);
                    continue;
		        }

                //classes.Any(c => c.Name == seatingClass.Name || c.Abbreviation == seatingClass.Abbreviation)
                if (validatedClasses.Any(c => c.Name == seatingClass.Name || c.Abbreviation == seatingClass.Abbreviation))
		        {
		            sb.AppendLine(FailureMessage);
                    continue;
		        }

                validatedClasses.Add(seatingClass);
		        sb.AppendLine(string.Format(SuccessMessage, seatingClass.Name));
		    }

            context.SeatingClasses.AddRange(validatedClasses);
		    context.SaveChanges();

            return sb.ToString();
		}

        public static string ImportTrains(StationsDbContext context, string jsonString)
        {
            var importedTrains = JsonConvert.DeserializeObject<TrainDto[]>(jsonString, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            
            var trains = context.Trains.AsNoTracking().ToArray();

            StringBuilder sb = new StringBuilder();

            var validTrains = new List<Train>();

            foreach (var trainDto in importedTrains)
            {
                if (!IsValid(trainDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var trainAlreadyExists = validTrains.Any(t => t.TrainNumber == trainDto.TrainNumber);
                if (trainAlreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatsAreValid = trainDto.Seats.All(IsValid);
                if (!seatsAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                
                var seatingClassesAreValid = trainDto.Seats
                    .All(s => context.SeatingClasses.Any(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation));
                if (!seatingClassesAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var type = Enum.Parse<TrainType>(trainDto.Type);

                var trainSeats = trainDto.Seats.Select(s => new TrainSeat
                    {
                        SeatingClass =
                            context.SeatingClasses.SingleOrDefault(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation),
                        Quantity = s.Quantity.Value
                    })
                    .ToArray();

                var train = new Train
                {
                    TrainNumber = trainDto.TrainNumber,
                    Type = type,
                    TrainSeats = trainSeats
                };

                validTrains.Add(train);

                sb.AppendLine(string.Format(SuccessMessage, trainDto.TrainNumber));
            }

            context.Trains.AddRange(validTrains);
            context.SaveChanges();

            return sb.ToString();
        }

		public static string ImportTrips(StationsDbContext context, string jsonString)
		{
		    var importedTrips = JsonConvert.DeserializeObject<TripDto[]>(jsonString, new JsonSerializerSettings
		    {
		        NullValueHandling = NullValueHandling.Ignore
		    });

		    var validTrips = new List<Trip>();

            var sb = new StringBuilder();

            string timeDifferenceFormat = $"hh\\:mm";
		    string dateFormat = "dd/MM/yyyy HH:mm";

            foreach (var tripDto in importedTrips)
		    {
		        if (!IsValid(tripDto))
		        {
		            sb.AppendLine(FailureMessage);
                    continue;
		        }

		        var train = context.Trains.SingleOrDefault(t => t.TrainNumber == tripDto.Train);

		        var originStation = context.Stations.SingleOrDefault(s => s.Name == tripDto.OriginStation);

		        var destinationStation = context.Stations.SingleOrDefault(s => s.Name == tripDto.DestinationStation);

		        if (train == null || originStation == null || destinationStation == null)
		        {
		            sb.AppendLine(FailureMessage);
                    continue;
		        }

		        var departureTime = DateTime.ParseExact(tripDto.DepartureTime, dateFormat, CultureInfo.InvariantCulture);
		        var arrivalTime = DateTime.ParseExact(tripDto.ArrivalTime, dateFormat, CultureInfo.InvariantCulture);

		        if (departureTime > arrivalTime)
		        {
		            sb.AppendLine(FailureMessage);
                    continue;
		        }

                var timeDifference = new TimeSpan();
		        if (tripDto.TimeDifference != null)
		        {
		            timeDifference = TimeSpan.ParseExact(tripDto.TimeDifference, timeDifferenceFormat, CultureInfo.InvariantCulture);
                }

		        var status = Enum.Parse<TripStatus>(tripDto.Status);

		        var trip = new Trip()
		        {
		            Train = train,
                    DestinationStation = destinationStation,
                    ArrivalTime = arrivalTime,
                    DepartureTime = departureTime,
                    OriginStation = originStation,
                    Status = status,
                    TimeDifference = timeDifference
		        };

		        validTrips.Add(trip);
		        sb.AppendLine($"Trip from {tripDto.OriginStation} to {tripDto.DestinationStation} imported.");
		    }

            context.Trips.AddRange(validTrips);
		    context.SaveChanges();

            return sb.ToString();
		}

		public static string ImportCards(StationsDbContext context, string xmlString)
		{
		    var serializer = new XmlSerializer(typeof(CardDto[]), new XmlRootAttribute("Cards"));
		    var deserializedCards = (CardDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var validCards = new List<CustomerCard>();

            var sb = new StringBuilder();

		    foreach (var cardDto in deserializedCards)
		    {
		        if (!IsValid(cardDto))
		        {
		            sb.AppendLine(FailureMessage);
                    continue;
		        }

		        //var type = Enum.TryParse<CardType>(cardDto.CardType, out var card) ? card : CardType.Normal;
		        var type = Enum.Parse<CardType>(cardDto.CardType);

                var customerCard = new CustomerCard
                {
                    Name = cardDto.Name,
                    Age = cardDto.Age,
                    Type = type,
                };

                validCards.Add(customerCard);
		        sb.AppendLine(string.Format(SuccessMessage, customerCard.Name));
            }

            context.Cards.AddRange(validCards);
		    context.SaveChanges();

		    return sb.ToString();
		}

        public static string ImportTickets(StationsDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(TicketDto[]), new XmlRootAttribute("Tickets"));
            var deserializedTickets = (TicketDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();

            var validTickets = new List<Ticket>();

            string dateFormat = @"dd/MM/yyyy HH:mm";
            foreach (var ticketDto in deserializedTickets)
            {
                if (!IsValid(ticketDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var departureTime = DateTime.ParseExact(ticketDto.Trip.DepartureTime, dateFormat, CultureInfo.InvariantCulture);

                var originStationStr = ticketDto.Trip.OriginStation;
                var destinationStationStr = ticketDto.Trip.DestinationStation;

                var trip = context.Trips
                    .Include(t => t.OriginStation)
                    .Include(t => t.DestinationStation)
                    .Include(t => t.Train)
                    .ThenInclude(t => t.TrainSeats)
                    .SingleOrDefault(t => t.OriginStation.Name == ticketDto.Trip.OriginStation &&
                                          t.DestinationStation.Name == ticketDto.Trip.DestinationStation &&
                                          t.DepartureTime == departureTime);
                if (trip == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                CustomerCard card = null;
                if (ticketDto.Card != null)
                {
                    card = context.Cards.SingleOrDefault(c => c.Name == ticketDto.Card.Name);

                    if (card == null)
                    {
                        sb.AppendLine(FailureMessage);
                        continue;
                    }
                }

                var seatAbbreviation = ticketDto.Seat.Substring(0, 2);
                var spotNumber = int.Parse(ticketDto.Seat.Substring(2));

                var seat = trip.Train.TrainSeats.SingleOrDefault(
                        s => s.SeatingClass.Abbreviation == seatAbbreviation && spotNumber <= s.Quantity);
                if (seat == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var ticket = new Ticket()
                {
                    Trip = trip,
                    CustomerCard = card,
                    Price = ticketDto.Price,
                    SeatingPlace = ticketDto.Seat
                };

                validTickets.Add(ticket);
                sb.AppendLine($"Ticket from {originStationStr} to {destinationStationStr} departing at {trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} imported.");
            }

            context.Tickets.AddRange(validTickets);
            context.SaveChanges();

            return sb.ToString();
        }
      
        static T[] ImportJson<T>(string input)
	    {
	        T[] objects = JsonConvert.DeserializeObject<T[]>(input);

	        return objects;
	    }

	    private static bool IsValid(object obj)
	    {
	        var validationContext = new ValidationContext(obj);
	        var validationResults = new List<ValidationResult>();

	        var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
	        return isValid;
	    }
    }
}