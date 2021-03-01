using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Utilities.Business.FileManager
{
    public class CarImagesFileHelper
    {
        static string directory = Directory.GetCurrentDirectory() + @"\wwwroot\";
        static string path = @"Images\";
        public static string Add(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            string newFileName = Guid.NewGuid().ToString("N") + extension;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            using (FileStream fileStream = File.Create(directory + path + newFileName))
            {
                file.CopyToAsync(fileStream);
                fileStream.Flush();
            }
            return (path + newFileName).Replace("\\","/");
        } 

        public static string Update(IFormFile file,string OldImagePath)
        {
            Delete(OldImagePath);
            return Add(file);
        }

        public static void Delete(string ImagePath)
        {
            bool x = File.Exists(directory + ImagePath.Replace("/", "\\"));
            if ( x && Path.GetFileName(ImagePath)!="default.png"){
                File.Delete(directory + ImagePath.Replace("/", "\\"));
            }
        }

    }
}
