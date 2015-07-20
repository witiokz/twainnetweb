using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TwainTester.Controllers
{
    public class HomeController : Controller
    {

        //http://www.codeproject.com/Articles/10518/NET-Web-Twain
        public ActionResult NETWebTwain()
        {
            return View();
        }

        //http://shekhar619.blogspot.com/2015/06/scanner-in-aspnet-both-twain-and-wia.html
        public ActionResult TwainAndWia()
        {
            return View();
        }

        //https://github.com/tmyroadctfig/twaindotnet
        //https://bitbucket.org/soukoku/ntwain
        public ActionResult TwainNet()
        {
            //<canvas width="270" height="16" style="position: absolute; left: 0px; top: 334px;"></canvas>
            return View();
        }

        //http://twainx.sourceforge.net/
        public ActionResult TwainX()
        {
            return View();
        }

        //http://www.dynamsoft.com/Products/WebTWAIN-with-HTML5-WebSocket-for-chrome.aspx
        //http://www.dynamsoft.com/blog/document-imaging/use-dynamic-web-twain-scanning-sdk-in-chrome-42/
        //http://www.dynamsoft.com/blog/document-imaging/web-twain-html5-edition/
        //http://www.dynamsoft.com/blog/document-imaging/scan-and-upload-documents-in-asp-net-mvc-application-using-dynamic-web-twain/
        //http://www.dynamsoft.com/Downloads/WebTWAIN-Sample-Download.aspx
        public ActionResult Index()
        {
            return View();
        }

        //https://sarafftwain.codeplex.com/documentation


        public ActionResult SaveToFile()
        {
            try
            {
                string strImageName;
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                HttpPostedFile uploadfile = files["RemoteFile"];
                strImageName = uploadfile.FileName;
                uploadfile.SaveAs(Server.MapPath("/") + "\\UploadedImages\\" + strImageName);
            }
            catch (Exception ex)
            {

            }

            return null;
        }
    }
}