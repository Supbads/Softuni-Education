using AutoMapper;
using Instagraph.DataProcessor.Dtos;
using Instagraph.Models;

namespace Instagraph.App
{
    public class InstagraphProfile : Profile
    {
        public InstagraphProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(u => u.ProfilePicture, pp => pp.UseValue<Picture>(null));

            CreateMap<Post, UncommentedPostDto>()
                .ForMember(p => p.User, u => u.MapFrom(p => p.User.Username))
                .ForMember(p => p.Picture, pic => pic.MapFrom(p => p.Picture.Path))
                .ForMember(p => p.Id, id => id.MapFrom(p => p.Id));
            CreateMap<User, PopularUserDto>()
                .ForMember(u => u.Username, username => username.MapFrom(u => u.Username))
                .ForMember(u => u.Followers, f => f.MapFrom(u => u.Followers.Count));
        }
    }
}