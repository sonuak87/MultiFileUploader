using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demotest.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UploadFiles()
        {
            string uname = Request["uploadername"];
            HttpFileCollectionBase files = Request.Files;
            if (files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    string fname;
                    // Checking for Internet Explorer      
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;
                    }
                    // Get the complete folder path and store the file inside it.      
                    fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                    file.SaveAs(fname);
                   
                }
                return Json("Hi, " + uname + ". Your files uploaded successfully", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please select File", JsonRequestBehavior.AllowGet);
            }


        }
    }
}