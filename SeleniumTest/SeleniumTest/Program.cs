using OpenQA.Selenium;
using SeleniumTest.AppData;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;


//本demo使用的是selenium2.0
namespace SeleniumTest
{
    //后期把测试用例也放到文件夹中
    class Program
    {
        static void Main(string[] args)
        {
            string banseUrl = "http://122.11.51.170:20002/server/login?sessionTimeOut=true";
            StartRequest p = new StartRequest(banseUrl);

            Console.WriteLine("请输入要使用的浏览器框架：ie,chrome,其他-Firefox");
            string browserType = Console.ReadLine();
            browserType = browserType.ToUpper();
            IWebDriver driver = p.RequestPage(browserType);
            //关闭浏览器
            driver.Quit();




            //ImageFormat.Png该格式selenium2.0才能用，3.0不能用
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(@"\jietu.png", ImageFormat.Png);
          //截图的路径必须是本地路径 \代表C盘根目录
           
        }
    }
}
