using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Galleriet.Model;

namespace Galleriet
{
    public partial class Galleriet : System.Web.UI.Page
    {
        
        private Gallery Gal
        {
            
            get { return Session["Gallery"] as Gallery ?? (Gallery)(Session["Gallery"] = new Gallery()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            Image1.Visible = (Request.QueryString["name"] != null) ? true : false;

            if (Session["success"] as bool? == true) {

                Success.Visible = true;
                Session.Remove("success");
            }
           
                      
            Image1.ImageUrl = @"~\Content\Images\" + Request.QueryString["name"];
            
           
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            if (IsValid) {

                if (FileUpload.HasFile) {

                    string name = Gal.SaveImage(FileUpload.FileContent, FileUpload.FileName);

                    Image1.ImageUrl = @"~\Content\Images\" + name;
                    Image1.Visible = true;

                    Session["success"] = true;
                    Response.Redirect(@"~/Galleriet.aspx?name="+  name );
                    
                }
               
            }
                        
        }
        
        
        public IEnumerable<string> Repeater1_GetData()
        {

            return Gal.GetImageNames();
            
                    
        }

    }
}