using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Instagraph.DataProcessor
{
    using Dtos;
    using System;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Instagraph.Data;

    public class Serializer
    {
        //json
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var postsWithoutComments = context.Posts
                .Where(p => !p.Comments.Any())
                .OrderBy(p => p.Id)
                .ProjectTo<UncommentedPostDto>()
                .ToArray();

            var serialized = JsonConvert.SerializeObject(postsWithoutComments, Formatting.Indented);
            return serialized;
        }
        //json
        public static string ExportPopularUsers(InstagraphContext context)
        {
            var popularUsers = context.Users
                .Include(u => u.Posts)
                .ThenInclude(p => p.Comments)
                .Include(u => u.Followers)
                .Where(u => u.Posts.
                    Any(p => p.Comments
                        .Any(c => u.Followers
                            .Any(f => f.FollowerId == c.UserId))))
                            .ProjectTo<PopularUserDto>();

            string serialized = JsonConvert.SerializeObject(popularUsers, Formatting.Indented);

            return serialized;
        }
        //xml
        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var users = context.Users
                .Select(u => new
                {
                    Username = u.Username,
                    PostsCommentCount = u.Posts.Select(p => p.Comments.Count).ToArray()
                });

            var userDtos = new List<UserTopCommentsDto>();

            foreach (var u in users)
            {
                int mostComments = 0;
                if (u.PostsCommentCount.Any())
                {
                    mostComments = u.PostsCommentCount.OrderByDescending(c => c).First();
                }

                var userDto = new UserTopCommentsDto()
                {
                    Username = u.Username,
                    MostComments = mostComments
                };

                userDtos.Add(userDto);
            }

            userDtos = userDtos.OrderByDescending(u => u.MostComments)
                .ThenBy(u => u.Username)
                .ToList();

            var doc = new XDocument();

            doc.Add(new XElement("users"));

            var elements = doc.Root.Elements();
            foreach (var user in userDtos)
            {
                doc.Root.Add(new XElement("user",
                    new XElement("Username", user.Username),
                    new XElement("MostComments", user.MostComments)));
            }

            return doc.ToString();
        }
    }
}