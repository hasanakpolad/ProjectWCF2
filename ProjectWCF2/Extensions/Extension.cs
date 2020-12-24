using Bussiness.Helper;
using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace DataAccess.Extensions
{
    public static class Extension
    {
        public static string ImageToBase64(this string imgPath)
        {
            byte[] imageBytes = File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
                                                                          //MySqlLogger.Instance.Info(base64String);
            return base64String;
                                                                          //MySqlLogger.Instance.Error(ex, "ImageToBase64");
        }

        public static Image Base64ToImage(this string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        public static string StringToBase64(this string data)
        {
            byte[] dataString = Encoding.ASCII.GetBytes(data);
            string base64Data = Convert.ToBase64String(dataString);
            return base64Data;
        }

        public static string Base64ToString(this string base64String)
        {
            var base64Strings = Convert.FromBase64String(base64String);
            return Encoding.UTF8.GetString(base64Strings);
        }
    }
}
