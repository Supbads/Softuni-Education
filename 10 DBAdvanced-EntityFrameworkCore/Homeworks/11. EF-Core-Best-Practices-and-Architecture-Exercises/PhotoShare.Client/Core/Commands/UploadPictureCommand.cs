namespace PhotoShare.Client.Core.Commands
{
    using Contracts;
    using System;

    public class UploadPictureCommand : ICommand
    {
        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(params string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
