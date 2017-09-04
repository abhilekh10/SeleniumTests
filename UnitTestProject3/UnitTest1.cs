using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
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
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            //start browser
            driver = new ChromeDriver("D:\\Selenium_Tutorial");
            driver.Manage().Window.Maximize();

        }

        [TestCleanup]
        public void Cleanup()
        {
            //stop browser
            driver.Quit();
        }

        [TestMethod] [TestCategory("IDEA")]
        public void IDEASPROJECT()
        {
            //open application
            driver.Navigate().GoToUrl("http://example.com/doc.html");
            driver.Manage().Window.Maximize();

            //Download with accepting - Click on My Doc Pdf
            driver.FindElement(By.Id("mydocpdf")).Click();
            
            Assert.IsTrue(driver.Title.ToString().Contains("403"),"403 page not found when user tried to download pdf doc without accepting terms.");
            Console.WriteLine("HTTP 403 error appeared when user tried to download the doc without accepting terms");

            driver.Navigate().Back();

            driver.FindElement(By.CssSelector("a[id='toc-link']")).Click();    
            
            //Verify Download scenarios on window

            //driver.SwitchTo().Window(driver.WindowHandles.Last()).FindElement(By.CssSelector("input[id='accept']")).Click();

            //driver.SwitchTo().Window(driver.WindowHandles.First()).FindElement(By.CssSelector("a[id='mydocpdf']")).Click();    
        
            //Download Status check here 
            
            driver.FindElement(By.CssSelector("a[id='toc-link']")).Click();

            //driver.SwitchTo().Window(driver.WindowHandles.Last()).FindElement(By.CssSelector("input[id='reject']")).Click();

            //driver.SwitchTo().Window(driver.WindowHandles.First()).FindElement(By.CssSelector("a[id='mydocpdf']")).Click();

            Assert.IsTrue(driver.Title.ToString().Contains("403"), "403 page not found when user tried to download pdf doc without accepting terms.");
            Console.WriteLine("HTTP 403 error appeared when user tried to download the doc without accepting terms");
        }

        [TestMethod]
        public void BookBindassHotelClick()
        {
            driver.Navigate().GoToUrl("http://www.bookbindass.com");
            driver.FindElement(By.XPath("html/body/div[4]/div/div/div[2]/nav/ul/li[2]/a/i[1]")).Click();
        }

        [TestMethod] [TestCategory("RadioAndCheckbox")]
        public void CheckForRadioCheckbox()
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/"); driver.Manage().Window.Maximize();
        }

        [TestMethod]
        [TestCategory("DropdownAndFrameSwitch")]
        public void SelectFromDropdownAndFrame()
        {
            driver.Navigate().GoToUrl("https://www.webcomponents.org/element/pushkar8723/paper-dropdown/demo/demo/index.html"); driver.Manage().Window.Maximize();
            Thread.Sleep(20000);

            driver.SwitchTo().Frame(driver.FindElement(By.Id("demo-frame")));

            driver.FindElement(By.CssSelector("paper-dropdown-menu[id='dropdownMenu']")).Click();

            var dropdown = driver.FindElement(By.CssSelector("paper-listbox[id='list']"));

            IList<IWebElement> values = dropdown.FindElements(By.TagName("paper-item"));

            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].Text == "Banana")
                {
                    values[i].Click();
                    break;
                }
            
            }
        }

        [TestMethod] [TestCategory("MouseActions")]
        public void HoverAndCssProperty()
        {
            driver.Navigate().GoToUrl("https://www.carmax.com/");

            Actions mouse = new Actions(driver);

            mouse.MoveToElement(driver.FindElement(By.ClassName("global-nav--link"))).Perform();
            
            IList<string> dropdownList = new List<string>();

            SelectElement dropdown = new SelectElement(driver.FindElement(By.CssSelector("select[id='day']")));

            int count = dropdown.Options.Count; 

            for(int i=0;i<count;i++)
            {
                dropdownList.Add(dropdown.Options[i].Text);
            }

            driver.FindElement(By.CssSelector("select[id='day']"));

            driver.Navigate().GoToUrl("Http://google.com"); driver.Manage().Window.Maximize();

         }

        [TestMethod]
        public void Table()
        {
            driver.Navigate().GoToUrl("https://www.w3schools.com/html/html_tables.asp");
            IWebElement table =  driver.FindElement(By.Id("customers"));

            int tableRows = table.FindElements(By.TagName("tr")).Count;

            string tableData = driver.FindElement(By.XPath(".//*[@id='customers']/tbody/tr[3]/td[2]")).Text;

        }

        [TestMethod]
        public void InlineElements()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.FindElement(By.XPath(".//*[@id='gbwa']/div[1]/a")).Click();

            driver.FindElement(By.XPath(".//*[@id='gb36']/span[1]")).Click();

            driver.Navigate().Back();
        }

        [TestMethod]
        [TestCategory("SEO")]
        public void SEO_1()
        {
            //WEBSITE 1
            driver.Navigate().GoToUrl("https://seositecheckup.com/");
            driver.FindElement(By.XPath(".//*[@id='select-url']")).SendKeys("http://www.bookbindass.com");
            driver.FindElement(By.XPath(".//*[@id='st-container']/div/div/section[1]/div/form/div/button")).Click();
            Thread.Sleep(200000);
        }

        [TestCategory("SEO")]
        [TestMethod]
        public void SEO_2()
        {
            //Website 2
            bool link;
            driver.Navigate().GoToUrl("https://neilpatel.com/seo-analyzer/");
            try
            {
                link = driver.FindElement(By.XPath(".//*[@id='popup-exit-v2']/p[4]")).Enabled;
                if (link)
                {
                    driver.FindElement(By.XPath(".//*[@id='article']/div[2]/div/form/input[2]")).SendKeys("http://www.bookbindass.com");
                    driver.FindElement(By.XPath(".//*[@id='article']/div[2]/div/form/input[3]")).Click();
                    Thread.Sleep(200000);
                }
                else
                {
                    driver.FindElement(By.XPath(".//*[@id='article']/div[2]/div/form/input[2]")).SendKeys("http://www.bookbindass.com");
                    driver.FindElement(By.XPath(".//*[@id='article']/div[2]/div/form/input[3]")).Click();
                    Thread.Sleep(200000);
                }
            }
            catch (Exception)
            {
                driver.FindElement(By.XPath(".//*[@id='article']/div[2]/div/form/input[2]")).SendKeys("http://www.bookbindass.com");
                driver.FindElement(By.XPath(".//*[@id='article']/div[2]/div/form/input[3]")).Click();
                Thread.Sleep(200000);
            }
        }

        [TestCategory("SEO")]
        [TestMethod]
        public void SEO_3()
        {
            //WEBSITE 3
            driver.Navigate().GoToUrl("http://www.seoptimer.com/");
            driver.FindElement(By.XPath(".//*[@id='domain']")).SendKeys("http://www.bookbindass.com");
            driver.FindElement(By.XPath(".//*[@id='submit']/span[2]")).Click();
            Thread.Sleep(200000);
        }

        [TestCategory("SEO")]
        [TestMethod]
        public void SEO_4()
        {
            //WEBSITE 4
            driver.Navigate().GoToUrl("https://sitechecker.pro/");
            driver.FindElement(By.XPath(".//*[@id='resource_url']")).SendKeys("http://www.bookbindass.com");
            driver.FindElement(By.XPath(".//*[@id='resource_save']")).Click();
            Thread.Sleep(200000);
        }

        [TestCategory("SEO")]
        [TestMethod]
        public void SEO_5()
        {
            //WEBSITE 5
            driver.Navigate().GoToUrl("http://www.seowebpageanalyzer.com/");
            driver.FindElement(By.XPath(".//*[@id='url']")).SendKeys("http://www.bookbindass.com");
            driver.FindElement(By.XPath(".//*[@id='content']/div[1]/div[1]/form/input[3]")).Click();
            Thread.Sleep(200000);
        }

        
    }
}
