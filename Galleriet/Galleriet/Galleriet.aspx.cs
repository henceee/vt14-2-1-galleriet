using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using Galleriet.Model;

namespace Galleriet
{
    public partial class Galleriet : System.Web.UI.Page
    {
        Gallery gal;

        protected void Page_Load(object sender, EventArgs e)
        {
           gal  = new Gallery();
        }

        protected void Uppload_Click(object sender, EventArgs e)
        {
            if (IsValid) {

                if (FileUpload.HasFile) {
                                       

                    gal.SaveImage(FileUpload.FileContent, FileUpload.FileName);

                    ThumbsPanel.Visible = true;
                }
            
            }
        }


        



        public IEnumerable<dynamic> Repeater1_GetData()
        {
            var di = new DirectoryInfo(Server.MapPath("~/Content/Images/Thumbs"));

            return (from fileinfo in di.GetFiles()
                    select new FileData
                    {
                        href = fileinfo.DirectoryName

                    }).AsEnumerable();

            //return null;
        }

       
    }
}