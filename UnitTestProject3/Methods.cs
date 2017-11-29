using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace UnitTestProject3
{
    public class Methods
    {
        public IWebDriver driver;

        string[] freeSMS = File.ReadAllLines(@"D:\Project\UnitTestProject3\UnitTestProject3\TestDataFiles\FreeSms.txt", System.Text.Encoding.UTF8);

        public string[] I60By2credentials = File.ReadAllLines(@"D:\Project\UnitTestProject3\UnitTestProject3\TestDataFiles\160by2.txt", System.Text.Encoding.UTF8);

        public string[] Way2SMScredentials = File.ReadAllLines(@"D:\Project\UnitTestProject3\UnitTestProject3\TestDataFiles\Way2sms.txt", System.Text.Encoding.UTF8);
        
        public string Message = "Air Asia Flight Sale! Buy Now Fly Now.. Fares Starting Rs 1299 only at www.bookbindass.com";

        public string[] YoutubeSharing_1 = File.ReadAllLines(@"D:\Project\UnitTestProject3\UnitTestProject3\TestDataFiles\Youtube_Sharing_1.txt", System.Text.Encoding.UTF8);
        public string[] YoutubeSharing_Credentials = File.ReadAllLines(@"D:\Project\UnitTestProject3\UnitTestProject3\TestDataFiles\Youtube_Sharing_login.txt", System.Text.Encoding.UTF8);
        public string[] Youtube_Counter = File.ReadAllLines(@"D:\Project\UnitTestProject3\UnitTestProject3\TestDataFiles\Youtube_Counter.txt", System.Text.Encoding.UTF8);
        

        #region Way2sms
                
        public int Way2Sms(int lastTimeCount, out int lastCompletedCount)
        {
            lastCompletedCount = lastTimeCount;
            for (int a = 0; a < Way2SMScredentials.Length; a++)
            {
                int updatedCount = lastCompletedCount;
                IList<string> nameContainer = new List<string>();
                nameContainer = Way2SMScredentials[a].Split('-');
                string username = nameContainer[0];
                string password = nameContainer[1];
                driver.Navigate().GoToUrl("http://site24.way2sms.com/content/index.html");
                driver.FindElement(By.XPath(".//*[@id='username']")).SendKeys(username);
                driver.FindElement(By.XPath(".//*[@id='password']")).SendKeys(password); 
                driver.FindElement(By.XPath(".//*[@id='loginBTN']")).Click();
                
                lastCompletedCount = Way2SmsImp(lastCompletedCount, out updatedCount);
            }

            return lastCompletedCount;
        }

        public int Way2SmsImp(int lastTimeCount, out int updatedCount)
        {
            string currentUrl = driver.Url;
            updatedCount = lastTimeCount;
            for (int i = lastTimeCount; i < freeSMS.Length; i++)
            {
                TypeMessage(i,currentUrl);Thread.Sleep(5000);

                if (i == lastTimeCount + 25)
                {
                    Dologout();
                    updatedCount = lastTimeCount + 25;
                    break;
                } 
                else {continue;}
            }
            return updatedCount;
        }

        public void TypeMessage(int i, string currentUrl)
        {     
                driver.Navigate().GoToUrl(currentUrl); Thread.Sleep(3000);
                
                driver.FindElement(By.XPath(".//*[@id='sendSMS']/a")).Click(); 
                Thread.Sleep(2000);
                driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("iframe[id='frame']")));
                driver.FindElement(By.CssSelector("input[id='mobile']")).SendKeys(freeSMS[i]);
                driver.FindElement(By.XPath(".//*[@id='message']")).SendKeys(Message);
                driver.FindElement(By.CssSelector("input[id='Send']")).Click();

                /*try { driver.FindElement(By.CssSelector("input[id='Send']")).Click(); }
                catch (Exception) 
                { driver.FindElement(By.CssSelector("input[id='Send']")).Click(); }*/
                
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    alert.Accept();
                }
                catch (Exception)
                {
                    //do nothing
 
                }
                Thread.Sleep(5000);
        }

        public void Dologout()
        {
            driver.Navigate().GoToUrl("http://site21.way2sms.com/content/index.html?");
        }

        #endregion


        #region JustDial
        public void JdPreMethod()
        {
            Thread.Sleep(4000);
            driver.FindElement(By.XPath(".//*[@id='setbackfix']/div[1]/div/div[1]/div[2]/div/div/h1/span/a/i")).Click();
            driver.FindElement(By.XPath(".//*[@id='swf']/section/section/ul/li[7]/a")).Click();
            driver.FindElement(By.XPath(".//*[@id='shrmnm1']")).SendKeys("User");
        }

        public void JdPostMethod()
        {
            driver.FindElement(By.XPath(".//*[@id='shrSms']/section/section[4]/p/span/button")).Click();
        }

        #endregion


        #region 160by2SMS
        public int I60By2SMS(int i, out int lastCompletedCount)
        {
            lastCompletedCount = i;
            for (int z = 0; z < I60By2credentials.Length; z++)
            {
                driver.Navigate().GoToUrl("http://www.160by2.com/Login");

                IList<string> nameContainer = new List<string>();
                nameContainer = I60By2credentials[z].Split('-');
                string username = nameContainer[0];
                string password = nameContainer[1];
                driver.FindElement(By.XPath(".//*[@id='username']")).SendKeys(username);
                driver.FindElement(By.XPath(".//*[@id='password']")).SendKeys(password);
                driver.FindElement(By.XPath(".//*[@id='loginform']/div/section/div/div[1]/div[2]/div[3]/button")).Click();

                for (int y = i; y < freeSMS.Length; y++)
                {                    
                    string currentUrl = "http://www.160by2.com";
                    driver.Navigate().GoToUrl(currentUrl); Thread.Sleep(5000);

                    driver.SwitchTo().Frame(driver.FindElement(By.Id("by2Frame")));

                    var parentClass = driver.FindElements(By.ClassName("sms-nu-row"));
                    parentClass[0].FindElement(By.TagName("input")).SendKeys(freeSMS[y]);

                    driver.FindElement(By.CssSelector("textarea[id='sendSMSMsg']")).SendKeys(Message);
                    driver.FindElement(By.XPath(".//*[@id='btnsendsms']")).Click();
                    try
                    {
                        IAlert alert = driver.SwitchTo().Alert();
                        alert.Accept();
                    }
                    catch (Exception)
                    {
                        //do nothing
                    }

                    Thread.Sleep(8000);
                    if (y >= (i + 25)) //202
                    {
                        driver.FindElement(By.XPath("html/body/div[4]/div/div[2]/button[4]")).Click();
                        lastCompletedCount = lastCompletedCount + 25;
                        break;
                    }
                }
            }
            return lastCompletedCount;
        }

        #endregion


        #region CommonFunctions

        public void GmailLogin(string username, string password)
        {
            driver.FindElement(By.XPath(".//*[@id='Email']")).SendKeys(username);
            driver.FindElement(By.XPath(".//*[@id='next']")).Click(); Thread.Sleep(4000);
            driver.FindElement(By.XPath(".//*[@id='Passwd']")).SendKeys(password);
            Thread.Sleep(4000);
            driver.FindElement(By.XPath(".//*[@id='signIn']")).Click();
        }

        public void GmailLogout()
        {
            driver.Navigate().GoToUrl("https://www.google.co.in");
            driver.FindElement(By.XPath(".//*[@id='gbw']/div/div/div[2]/div[4]/div[1]/a/span")).Click();
            driver.FindElement(By.XPath(".//*[@id='gb_71']")).Click();
            Thread.Sleep(5000);
        }

        #endregion


        [TestInitialize]
        public void Setup()
        {
            //driver = new ChromeDriver("D:\\Selenium_Tutorial");
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            //stop browser
            driver.Quit();
        }
    }     
}
