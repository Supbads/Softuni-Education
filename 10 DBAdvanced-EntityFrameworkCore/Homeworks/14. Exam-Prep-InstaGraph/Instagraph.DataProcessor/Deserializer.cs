using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

using Newtonsoft.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Instagraph.Data;
using Instagraph.DataProcessor.Dtos;
using Instagraph.Models;

namespace Instagraph.DataProcessor
{
    public class Deserializer
    {
        private const string error = "Error: Invalid data.";

        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            var pictures = ImportJson<Picture>(jsonString);

            List<Picture> validPictures = new List<Picture>();

            StringBuilder sb = new StringBuilder();

            foreach (Picture picture in pictures)
            {
                bool isValid = !string.IsNullOrWhiteSpace(picture.Path) && picture.Size > 0;

                if (!isValid)
                {
                    sb.AppendLine(error);
                    continue;
                }

                if (context.Pictures.Any(p => p.Path == picture.Path) || validPictures.Any(p => p.Path == picture.Path))
                {
                    sb.AppendLine(error);
                    continue;
                }

                validPictures.Add(picture);
                sb.AppendLine($"Successfully imported Picture {picture.Path}.");
            }

            context.Pictures.AddRange(validPictures);

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            var userDtos = ImportJson<UserDto>(jsonString);

            var pictures = context.Pictures.AsNoTracking().ToArray();
            var users = context.Users.AsNoTracking().ToArray();
            var validUsers = new List<User>();

            StringBuilder sb = new StringBuilder();

            foreach (var userDto in userDtos)
            {

                bool isValid = !String.IsNullOrWhiteSpace(userDto.Username) &&
                   userDto.Username.Length <= 30 &&
                   !String.IsNullOrWhiteSpace(userDto.Password) &&
                   userDto.Password.Length <= 20 &&
                   !String.IsNullOrWhiteSpace(userDto.ProfilePicture);

                if (!isValid)
                {
                    sb.AppendLine(error);
                    continue;
                }

                var picture = pictures.FirstOrDefault(p => p.Path == userDto.ProfilePicture);
                bool userExists = users.Any(u => u.Username == userDto.Username) ||
                    validUsers.Any(u => u.Username == userDto.Username);

                if (picture == null || userExists)
                {
                    sb.AppendLine(error);
                    continue;
                }

                var user = Mapper.Map<User>(userDto);
                user.ProfilePictureId = picture.Id;

                validUsers.Add(user);
                sb.AppendLine($"Successfully imported User {userDto.Username}.");
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var deserializedUsersFollowers = ImportJson<UserFollowerDto>(jsonString);

            var validUserFollowers = new List<UserFollower>();
            var users = context.Users.AsNoTracking().ToArray();
            var allUsersFollowers = context.UsersFollowers.AsNoTracking().ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var dto in deserializedUsersFollowers)
            {
                var follower = users.FirstOrDefault(u => u.Username == dto.Follower);
                var user = users.FirstOrDefault(u => u.Username == dto.User);

                if (user == null || follower == null)
                {
                    sb.AppendLine(error);
                    continue;
                }
                
                bool alreadyFollowed = validUserFollowers
                    .Any(f => f.UserId == user.Id &&
                        f.FollowerId == follower.Id);

                if (alreadyFollowed)
                {
                    sb.AppendLine(error);
                    continue;
                }

                if (allUsersFollowers.Any(uf => uf.FollowerId == follower.Id && uf.UserId == user.Id))
                {
                    sb.AppendLine(error);
                    continue;
                }

                validUserFollowers.Add(new UserFollower()
                {
                    UserId = user.Id,
                    FollowerId = follower.Id
                });

                sb.AppendLine($"Successfully imported Follower {follower.Username} to User {user.Username}.");
            }

            context.AddRange(validUserFollowers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var users = context.Users.AsNoTracking().ToArray();
            var pictures = context.Pictures.AsNoTracking().ToArray();
            
            var validPosts = new List<Post>();

            StringBuilder sb = new StringBuilder();
            var xmlDoc = XDocument.Parse(xmlString);
            var elements = xmlDoc.Root.Elements();

            foreach (XElement element in elements)
            {
                var caption = element.Element("caption")?.Value;
                var username = element.Element("user")?.Value;
                var picturePath = element.Element("picture")?.Value;

                bool inputIsValid = !String.IsNullOrWhiteSpace(caption) &&
                                    !String.IsNullOrWhiteSpace(username) &&
                                    !String.IsNullOrWhiteSpace(picturePath);

                if (!inputIsValid)
                {
                    sb.AppendLine(error);
                    continue;
                }

                var user = users.FirstOrDefault(u => u.Username == username);
                var picture = pictures.FirstOrDefault(p => p.Path == picturePath);

                if (user == null || picture == null)
                {
                    sb.AppendLine(error);
                    continue;
                }

                validPosts.Add(new Post()
                {
                    UserId = user.Id,
                    PictureId = picture.Id,
                    Caption = caption
                });

                sb.AppendLine($"Successfully imported Post {caption}.");
            }

            context.Posts.AddRange(validPosts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var users = context.Users.AsNoTracking().ToArray();
            var posts = context.Posts.AsNoTracking().ToArray();

            var validComments = new List<Comment>();

            StringBuilder sb = new StringBuilder();
            var xmlDoc = XDocument.Parse(xmlString);
            var elements = xmlDoc.Root.Elements();

            foreach (XElement element in elements)
            {
                //max length check (250) ?
                var content = element.Element("content")?.Value;
                var username = element.Element("user")?.Value;
                var postId = element.Element("post")?.Attribute("id")?.Value;

                int parsedId = -1;
                if (!int.TryParse(postId, out parsedId))
                {
                    sb.AppendLine(error);
                    continue;
                }
                
                var user = users.FirstOrDefault(u => u.Username == username);
                var post = posts.FirstOrDefault(p => p.Id == parsedId);

                if (user == null || post == null)
                {
                    sb.AppendLine(error);
                    continue;
                }

                validComments.Add(new Comment()
                {
                    UserId = user.Id,
                    PostId = post.Id,
                    Content = content
                });

                sb.AppendLine($"Successfully imported Comment {content}.");
            }

            context.Comments.AddRange(validComments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        static T[] ImportJson<T>(string jsonString)
        {
            T[] objects = JsonConvert.DeserializeObject<T[]>(jsonString);

            return objects;
        }
    }
}