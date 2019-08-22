using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.Settings;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumWebdriver.ComponentHelper
{
    public class GenericHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof (GenericHelper));
         
            

        public static void TakeScreenShot(string filename = "Screen")
        {
            var screen = ObjectRepository.Driver.TakeScreenshot();
            if (filename.Equals("Screen"))
            {
                filename = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
                screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
                Logger.Info(" ScreenShot Taken : " + filename);
                return;
            }
            screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg); Logger.Info(" ScreenShot Taken : " + filename);
        }       
       
      
        

    }
}
