namespace PhotoShare.Services.Contracts
{
    using Models;
    using System.Collections.Generic;

    public interface IAlbumService
    {
        void AddTagTo(string albumName, string tagName);

        void ShareAlbum(int albumId, string username, string permission);

        void UploadPicture(string albumName, string pictureTitle, string picturePath);

        void Create(string username, string albumTitle, string bgColor, params string[] tags);

        ICollection<User> GetAlbumOwners(Album album);
    }
}