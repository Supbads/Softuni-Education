namespace PhotoShare.Client.Core.Commands
{
    using Contracts;
    using System;

    public class ShareAlbumCommand : ICommand
    {
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer

        public string Execute(params string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
