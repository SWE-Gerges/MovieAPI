namespace MoviesInfoAPI.Settings
{
    public static class FileSettings
    {
        
        public const string allowedExtentions = ".jpg,.jpeg,.png";

        public const int maxFileSizeMB = 1;

        public const int maxFileSizeByte = maxFileSizeMB * 1024 * 1024;
    }
}
