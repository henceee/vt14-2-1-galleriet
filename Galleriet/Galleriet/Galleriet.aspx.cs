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

            if (Session["success"] != null) {

                Success.Visible = true;
                Session.Remove("success");
            }
           
            //Success.Visible = (Request.QueryString["success"] == "true") ? true : false;
            
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
            //var di = new DirectoryInfo(Server.MapPath("~/Content/Images/Thumbs"));

            //return (from fi in di.GetFiles("*.jpg").Union(di.GetFiles("*.png").Union(di.GetFiles("*gif")))                    
            //        select new FileData                    
            //        {
            //                src = fi.DirectoryName,
            //                name = fi.Name
                            

            //        }).AsEnumerable();
                    
        }

    }
}