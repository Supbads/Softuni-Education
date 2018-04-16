namespace PhotoShare.Client.Core.Commands
{
    using Services.Contracts;
    using Contracts;

    public class AddTagToCommand : ICommand
    {
        // AddTagTo <albumName> <tag>

        private readonly IAlbumService albumService;

        public AddTagToCommand(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        public string Execute(params string[] data)
        {
            var album = data[0];
            var tag = data[1];

            albumService.AddTagTo(album, tag);

            return $"Tag {tag} added to {album}!";
        }
    }
}