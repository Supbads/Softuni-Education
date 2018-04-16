using System;
using System.Data.SqlClient;

namespace _01.Initial_Setup
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection
            (
                "Server=.;" +
                "Database=MinionsDB;" +
                "Integrated Security=True"
            );

            connection.Open();

            using (connection)
            {
                var createDb = @"CREATE DATABASE MinionsDB";

                try
                {
                    var commandCreateDB = new SqlCommand(createDb, connection);

                    commandCreateDB.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                var addTables = @"
                                CREATE TABLE Countries(
                                Id INT PRIMARY KEY IDENTITY,
                                Name NVARCHAR(50) NOT NULL
                                )
 
                                CREATE TABLE Towns(
                                Id INT PRIMARY KEY IDENTITY,
                                Name NVARCHAR(50) NOT NULL,
                                CoutryId INT
                                CONSTRAINT FK_CoutryId FOREIGN KEY(CoutryId) REFERENCES Countries(Id)
                                )
 
                                CREATE TABLE Minions(
                                Id INT PRIMARY KEY IDENTITY,
                                Name NVARCHAR(50) NOT NULL,
                                Age INT,
                                TownId INT
                                CONSTRAINT FK_TownId FOREIGN KEY(TownId) REFERENCES Towns(Id)
                                )
 
                                CREATE TABLE EvilnessFactors(
                                Id INT PRIMARY KEY IDENTITY,
                                Name NVARCHAR(50) NOT NULL
                                )
 
                                CREATE TABLE Villains(
                                Id INT PRIMARY KEY IDENTITY,
                                Name NVARCHAR(50) NOT NULL,
                                EvilnessFactorId INT
                                CONSTRAINT FK_EvilnessFactorId FOREIGN KEY(EvilnessFactorId) REFERENCES EvilnessFactors(Id)
                                )
 
                                CREATE TABLE MinionsVillains(
                                MinionId INT,
                                VillainId INT
                                CONSTRAINT PK_MinionId_VillainId PRIMARY KEY(MinionId, VillainId)
                                CONSTRAINT FK_MinionId FOREIGN KEY(MinionId) REFERENCES Minions(Id),
                                CONSTRAINT FK_VillainId FOREIGN KEY(VillainId) REFERENCES Villains(Id))";

                var commandAddTable = new SqlCommand(addTables, connection);
                var createTable = (string)commandAddTable.ExecuteScalar();


                Console.WriteLine(createTable);

            }
            
            //Get-Package | Uninstall-Package -Force

        }
    }
}