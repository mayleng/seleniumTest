using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumTest.AppData
{
    //这个类里开始写初始页面的进入，创建webdriver
    class StartRequest
    {
        public IWebDriver driver = null;
        public string _url;
        public string Url
        {
            get { return _url; }
            //设置一个默认的url
            set {
                if(value==" " || value==null)
                {
                    _url = "http://122.11.51.170:20002/server/login?sessionTimeOut=true";
                }
                else
                {
                    _url = value;
                }
                
            }
        }

        //通过构造方法将初始url传入
        public StartRequest(string url)
        {
            this._url = url;
        }

        //获得操作浏览器的driver
        public void  MakeDriver(string browserType)
        {
           // IWebDriver driver = null;
            // InternetExplorerDriver driver = new InternetExplorerDriver(@"C:\Users\bonree\Desktop\webapi\netframework\SeleniumTest\packages\Selenium.WebDriver.3.13.1");
            if (browserType.Equals("IE"))
            {
                //使用IE时要取消浏览器的保护模式，添加如下两行代码。
                InternetExplorerOptions options = new InternetExplorerOptions();
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                driver = new InternetExplorerDriver(options);
            }
            else if (browserType.Equals("Chrome".ToUpper()))
            {
                driver = new ChromeDriver();
            }
            else
            {
                driver = new FirefoxDriver();
            }         

        }

        //进入请求页面
        public IWebDriver RequestPage(string browserType)
        {
            MakeDriver(browserType);
            driver.Navigate().GoToUrl(Url);
            return driver;
        }


    }
}
