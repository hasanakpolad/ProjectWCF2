using System;
using System.IO;

namespace DataAccess.Extensions
{
    public static class Extension
    {
        public static string ImageToBase64(this string imgPath)
        {
            byte[] imageBytes = File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}
