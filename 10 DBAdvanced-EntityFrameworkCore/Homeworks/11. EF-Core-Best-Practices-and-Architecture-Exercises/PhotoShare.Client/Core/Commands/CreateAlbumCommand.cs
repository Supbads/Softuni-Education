namespace PhotoShare.Client.Core.Commands
{
    using System.Linq;
    using Services.Contracts;
    using Contracts;

    public class CreateAlbumCommand : ICommand
    {
        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        
        private readonly IAlbumService albumService;

        public CreateAlbumCommand(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        public string Execute(params string[] data)
        {
            var username = data[0];
            var albumTitle = data[1];
            var bgColor = data[2];
            var tags = data.Skip(3).ToArray();

            albumService.Create(username, albumTitle, bgColor, tags);

            return $"Album {albumTitle} successfully created!";
        }
    }
}