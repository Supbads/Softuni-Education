using PhotoShare.Client.Core.Commands;

namespace PhotoShare.Client.Utilities
{
    static class CommandValidators
    {
        public const int RegisterUserArguments = 4;

        public const int AddTownArguments = 2;

        public const int ModifyUserArguments = 3;

        public const int DeleteUserArguments = 1;

        public const int AddTagArguments = 1;

        public const int AddTagToArguments = 2;

        public const int AddFriendArguments = 2;

        public const int AcceptFriendArguments = 2;

        public const int ListFriendsArguments = 1;

        public const int ShareAlbumArguments = 3;

        public const int CreateAlbumArguments = int.MaxValue;

        public const int UploadPictureArguments = 3;

        public const int ExitArguments = 0;

        public const int LoginArugments = 2;

        public const int LogoutArguments = 0;
    }
}