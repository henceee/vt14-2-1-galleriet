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
       private static string PhysicalUploadedImagesPath;
       private static Regex SanitizePath;
       private static string thumbsdirectory;
       List<string> filenames = new List<string>(100);

       static Gallery()
       {

            ApprovedExtensions = new Regex("^.*.(gif|jpg|png)$", RegexOptions.IgnoreCase);            
            string physical = AppDomain.CurrentDomain.GetData("APPBASE").ToString();
            PhysicalUploadedImagesPath = Path.Combine(physical, @"Content\Images").ToString();

           var invalidChars = new string(Path.GetInvalidFileNameChars());
           SanitizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));
           thumbsdirectory = Path.Combine(PhysicalUploadedImagesPath, "Thumbs").ToString();

                   
        }
       

        public IEnumerable<string> GetImageNames(){

           var di = new DirectoryInfo(thumbsdirectory);

           
           FileInfo[] fi = di.GetFiles();
           foreach (FileInfo fileinfo in fi) {
               filenames.Add(fileinfo.Name);
               
           }

           filenames.TrimExcess();

           return filenames;
        }
        
        bool ImageExist(string name){

            return File.Exists(Path.Combine(thumbsdirectory, name));
                          
        }

        private bool ValidImage(Image image){

            return image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid ||
                    image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid ||
                    image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid;
                        
        }

        public string SaveImage(Stream stream, string fileName){
                        
            var image = System.Drawing.Image.FromStream(stream); // stream -> ström med bild

                        
            if (ValidImage(image))
            {
                GetImageNames();

                    if (ImageExist(fileName) && ApprovedExtensions.IsMatch(fileName))
                    {
                        string filewithoutext = Path.GetFileNameWithoutExtension(fileName);

                        int filecounter = 0;

                        string newfilename;

                            do
                            {
                                filecounter++;

                                string namewithoutExt = string.Format(filewithoutext + "({0})", filecounter);

                                newfilename = namewithoutExt + Path.GetExtension(fileName);


                            } while (ImageExist(newfilename));

                        fileName = newfilename;

                    }

                fileName = SanitizePath.Replace(fileName, string.Empty);
                var thumbnail = image.GetThumbnailImage(100, 75, null, System.IntPtr.Zero);
                thumbnail.Save(Path.Combine(thumbsdirectory, fileName));
                image.Save(Path.Combine(PhysicalUploadedImagesPath, fileName));
                
                return fileName;
                

            } else {

                throw new Exception();
            
             }   
        }       
    }
}