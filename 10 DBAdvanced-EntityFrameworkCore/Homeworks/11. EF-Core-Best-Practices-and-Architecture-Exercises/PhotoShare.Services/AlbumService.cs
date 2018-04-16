namespace PhotoShare.Services
{
    using System;
    using Contracts;
    using Data;
    using System.Linq;
    using Models;
    using System.Collections.Generic;

    public class AlbumService : IAlbumService
    {
        private readonly PhotoShareContext context;
        private readonly IUserService userService;
        private readonly IUserSessionService sessionService;

        public AlbumService(PhotoShareContext context, IUserService userService, IUserSessionService sessionService)
        {
            this.context = context;
            this.userService = userService;
            this.sessionService = sessionService;
        }

        public void AddTagTo(string albumName, string tagName)
        {
            if (!sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You must log in to add a tag to an Album");
            }

            var album = context.Albums.FirstOrDefault(a => a.Name == albumName);

            var tag = context.Tags.FirstOrDefault(t => t.Name == tagName);
            
            if (album == null || tag == null)
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }

            var albumOwners = GetAlbumOwners(album);

            if (!albumOwners.Any(sessionService.ValidateUser))
            {
                throw new InvalidOperationException("You must be the owner of the Album to add a tag");
            }

            var albumTag = new AlbumTag
            {
                Album = album,
                Tag = tag
            };

            album.AlbumTags.Add(albumTag);

            context.SaveChanges();
        }

        //Apperently Albums can have many Owners
        public void ShareAlbum(int albumId, string username, string permission)
        {
            if (!sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You must be logged in to Share an Album");
            }

            var album = context.Albums.Find(albumId);

            if (album == null)
            {
                throw new ArgumentException($"Album {albumId} not found!");
            }

            var albumOwners = GetAlbumOwners(album);
            
            if (!albumOwners.Any(sessionService.ValidateUser))
            {
                throw new InvalidOperationException("You can only Share an album if you Own the album");
            }

            var addedUser = this.userService.ByUsername(username);

            if (addedUser == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (permission != "Owner" || permission != "Viewer")
            {
                throw new ArgumentException("Permission must be either “Owner” or “Viewer”!");
            }

            var parsedRole = Enum.Parse<Role>(permission);

            var albumRole = new AlbumRole()
            {
                Album = album,
                User = addedUser,
                Role = parsedRole
            };

            context.AlbumRoles.Add(albumRole);

            context.SaveChanges();
        }

        public void UploadPicture(string albumName, string pictureTitle, string picturePath)
        {
            if (!sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You must be logged in to Upload a picture to an Album");
            }

            var album = context.Albums.SingleOrDefault(a => a.Name == albumName);

            if (album == null)
            {
                throw new ArgumentException($"Album {albumName} not found!");
            }

            var albumOwners = GetAlbumOwners(album);

            if (!albumOwners.Any(sessionService.ValidateUser))
            {
                throw new InvalidOperationException("You can only Upload pictures to albums you Own");
            }

            var picture = new Picture()
            {
                Title = pictureTitle,
                Path = picturePath
            };

            album.Pictures.Add(picture);

            context.SaveChanges();
        }

        public void Create(string username, string albumTitle, string bgColor, params string[] tags)
        {
            if (!sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You must be logged in to Create an Album");
            }

            var user = userService.ByUsername(username);

            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (!this.sessionService.ValidateUser(user))
            {
                throw new InvalidOperationException("You can only create your Own Albums");
            }

            if (context.Albums.Any(a => a.Name == albumTitle))
            {
                throw new ArgumentException($"Album {albumTitle} exists!");
            }

            Color parsedColor;
            try
            {
                parsedColor = Enum.Parse<Color>(bgColor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); //to check the ex type
                throw new ArgumentException($"Color {bgColor} not found");
            }

            var allTagNames = context.Tags.Select(t => t.Name).ToArray();

            foreach (string tag in tags)
            {
                if (!allTagNames.Contains(tag))
                {
                    throw new ArgumentException("Invalid tags!");
                }
            }

            var album = new Album()
            {
                Name = albumTitle,
                BackgroundColor = parsedColor
            };

            var albumRole = new AlbumRole()
            {
                Album = album,
                User = user,
                Role = Role.Owner
            };

            album.AlbumRoles.Add(albumRole);

            foreach (var tagName in tags)
            {
                var tag = context.Tags.FirstOrDefault(t => t.Name == tagName);

                var albumTag = new AlbumTag
                {
                    Album = album,
                    Tag = tag
                };

                album.AlbumTags.Add(albumTag);
            }

            context.SaveChanges();
        }

        public ICollection<User> GetAlbumOwners(Album album)
        {
            var albumOwners = album.AlbumRoles.Where(r => r.Role == Role.Owner).Select(r => r.User).ToArray();
            
            return albumOwners;
        }
    }
}