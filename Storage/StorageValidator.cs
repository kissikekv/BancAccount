﻿namespace Storage
{
    internal class StorageValidator
    {
        public static void ValidateFilePath(string filePath)
        {
            try
            {
                UriBuilder uriBuilder = new UriBuilder();
                uriBuilder.Scheme = Uri.UriSchemeFile;
                uriBuilder.Path = filePath;

                bool isValid = Uri.TryCreate(uriBuilder.Uri.ToString(), UriKind.Absolute, out Uri resultUri);
            }
            catch (UriFormatException)
            {
                throw new FormatException(message: "Invalid path format");
            }
        }
    }
}