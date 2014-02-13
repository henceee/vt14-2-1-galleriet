using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;

namespace Galleriet.Model
{
    public class Gallery
    {
       private static Regex ApprovedExtensions;
       private static String PhysicalUploadedImagesPath;
       private static Regex SanitizePath;

       static Gallery()
       {

            ApprovedExtensions = new Regex("^.*(gif|jpg|png)$", RegexOptions.IgnoreCase);            
            string physical = AppDomain.CurrentDomain.GetData("APPBASE").ToString();
            PhysicalUploadedImagesPath = Path.Combine(physical, @"Content\Images").ToString();

           var invalidChars = new string(Path.GetInvalidFileNameChars());
           SanitizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));
            
        
        }
       
        public IEnumerable<string> GetImageNames(){
        
            throw new NotImplementedException();
        
        }
        
        bool ImageExist(string name){
        
              throw new NotImplementedException();
              
        }

        private bool ValidImage(Image image){
        
            throw new NotImplementedException();
        }

        public string SaveImage(Stream stream, string fileName){

            string thumbsdirectory = Path.Combine(PhysicalUploadedImagesPath, @"Thumbs").ToString();

            var image = System.Drawing.Image.FromStream(stream); // stream -> ström med bild
            var thumbnail = image.GetThumbnailImage(60, 45, null, System.IntPtr.Zero);
            thumbnail.Save(Path.Combine(thumbsdirectory, fileName ), ImageFormat.Jpeg);
            image.Save(Path.Combine(PhysicalUploadedImagesPath, fileName), ImageFormat.Jpeg);


            return fileName;



   
}
                  

    }
}