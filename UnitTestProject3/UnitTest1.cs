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
using System.Windows.Forms;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1:Methods
    {        

        #region Youtube
        [TestMethod]
        [TestCategory("YoutubeMarketing")]
        public void LinkedIn()
        {
            driver.Navigate().GoToUrl("https://www.linkedin.com/");
            driver.FindElement(By.XPath(".//*[@id='login-email']")).SendKeys("b2b@bookbindass.com");
            driver.FindElement(By.XPath(".//*[@id='login-password']")).SendKeys("zaq1ZAQ!");
            driver.FindElement(By.XPath(".//*[@id='login-submit']")).Click(); Thread.Sleep(5000);

            driver.Navigate().GoToUrl("https://www.linkedin.com/feed/update/urn:li:activity:6319889201202630656/");

            for (int i = 0; i < 1000; i++)
            {

                driver.FindElement(By.PartialLinkText("bookbindass branding on private boeing")).Click();
                var windows = driver.WindowHandles;
                if(windows.Count>=2)
                {
                    Thread.Sleep(35000);
                    driver.SwitchTo().Window(windows[1]);
                    driver.Navigate().GoToUrl("https://www.youtube.com/watch?v=ZPO7o6tvZ1o&t=3s"); Thread.Sleep(30000);
                    driver.Navigate().GoToUrl("https://www.youtube.com/watch?v=WHZLq51CiM0"); Thread.Sleep(30000);
                    driver.Navigate().GoToUrl("https://www.youtube.com/watch?v=yeuBcGUIo-w"); Thread.Sleep(30000);
                    driver.SwitchTo().Window(windows[1]).Close();
                    driver.SwitchTo().Window(windows[0]);
                    
                }
            }
        }

        [TestMethod]
        [TestCategory("YoutubeMarketing")]
        public void YouTube()
        {
            for (int c = 1; c < YoutubeSharing_Credentials.Length; c++)
            {   
                string[] container= YoutubeSharing_Credentials[c].Split('-');
                string username = container[0];
                string password = container[1];
                
                driver.Navigate().GoToUrl("https://goo.gl/tAC9x8");
                GmailLogin(username, password); Thread.Sleep(4000);

                /*if (c == 1)
                {
                    GmailLogin(username, password); Thread.Sleep(4000);
                }
                else 
                {
                    driver.FindElement(By.CssSelector("a[id='account-chooser-link']")).Click(); Thread.Sleep(2000);
                    driver.FindElement(By.CssSelector("a[id='edit-account-list']")).Click(); Thread.Sleep(1000);
                    driver.FindElement(By.CssSelector("button[id='choose-account-0']")).Click();
                    driver.FindElement(By.CssSelector("a[id='edit-account-list']")).Click(); Thread.Sleep(2000);
                    GmailLogin(username, password); Thread.Sleep(8000);
                }*/

                

                driver.Navigate().GoToUrl("https://www.youtube.com/watch?v=qos0DZUEhGI");

                driver.FindElement(By.XPath(".//*[@id='watch-uploader-info']/strong")).Click();
                driver.FindElement(By.XPath(".//*[@id='eow-title']")).Click();
                Thread.Sleep(10000);

                //Click sharing attempts
                for (int b = 0; b < 3; b++)
                {
                    driver.FindElement(By.XPath(".//*[@id='watch8-secondary-actions']/button")).Click();
                    Thread.Sleep(10000);
                    bool visible = driver.FindElement(By.XPath(".//*[@id='watch-actions-share-panel']/div/div[3]")).Displayed;
                    if (visible)
                    {
                        driver.FindElement(By.XPath(".//*[@id='watch-actions-share-panel']/div/div[1]/span/button[3]")).Click();
                        Thread.Sleep(2000);
                        break;
                    }
                }

                //enter 9 emails and message
                string[] container1 = Youtube_Counter[0].Split('-');
                int LastSentId = Convert.ToInt32(container1[1]);
                for (int i = LastSentId; LastSentId < YoutubeSharing_1.Length; )
                {
                    for (int a = i; a < (i + 9); a++)
                    {
                        driver.FindElement(By.XPath(".//*[@id='watch-actions-share-panel']/div/div[5]/div/form/div[1]/span/textarea")).SendKeys(YoutubeSharing_1[a]);
                        driver.FindElement(By.XPath(".//*[@id='watch-actions-share-panel']/div/div[5]/div/form/div[1]/span/textarea")).SendKeys(",");
                    }

                    driver.FindElement(By.XPath(".//*[@id='watch-actions-share-panel']/div/div[5]/div/form/div[2]/span/textarea")).SendKeys("bookbindass is an online travel agency having best online rates in domestic travel. Here is our latest Advertisement video.");
                    driver.FindElement(By.XPath(".//*[@id='watch-actions-share-panel']/div/div[5]/div/form/p/button")).Click();
                    
                    Thread.Sleep(7000);
                    LastSentId = LastSentId + 9;
                    break;
                }

                driver.FindElement(By.XPath(".//*[@id='yt-masthead-account-picker']/button")).Click();
                Thread.Sleep(3000);
                //var window = driver.FindElement(By.CssSelector("div[class*='masthead-account-picker']"));
                var window = driver.FindElement(By.CssSelector("div[class*='masthead-account-picker']")).FindElement(By.CssSelector("div[class*='yt-masthead-picker-footer']"));
                Thread.Sleep(2000);
                window.FindElement(By.CssSelector("span[class='yt-uix-button-content']")).Click();
                Thread.Sleep(7000);
                driver.Manage().Cookies.DeleteAllCookies();

                //updatelast read in file                
                //string str = Youtube_Counter[0];
                var reader = new StreamReader(@"D:\Project\UnitTestProject3\UnitTestProject3\TestDataFiles\Youtube_Counter.txt");
                string str = reader.ReadToEnd();
                string[] lastvalue = str.Split('-');
                reader.Close();

                var replacedString = str.Replace(str.ToString(), "startValue-" + (Convert.ToInt32(lastvalue[1])+9).ToString());
                var writer = new StreamWriter(@"D:\Project\UnitTestProject3\UnitTestProject3\TestDataFiles\Youtube_Counter.txt");
                writer.Write(replacedString);
                writer.Close();
            }
        }


        #endregion


        #region JustDial
        [TestCategory("JustDial")]
        [TestMethod]
        public void JustDial()
        {
            driver.Navigate().GoToUrl("https://www.justdial.com/Ambala/Bookbindass-Com-Prem-Nagar/9999PX171-X171-151022214507-L4Q4_BZDET");
            
            string[] lines = File.ReadAllLines(@"D:\Project\UnitTestProject3\UnitTestProject3\TestDataFiles\PhoneData.txt", System.Text.Encoding.UTF8);

            driver.FindElement(By.XPath(".//*[@id='setbackfix']/div[1]/div/div[1]/div[2]/div/div/h1/span/a/i")).Click();
            driver.FindElement(By.XPath(".//*[@id='swf']/section/section/ul/li[7]/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(".//*[@id='em']")).SendKeys("7384848484");
            driver.FindElement(By.XPath(".//*[@id='pass']")).SendKeys("xsw2XSW@");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(".//*[@id='lgn_smt']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id='shrSms']/section/span")).Click();

            //Enter Name
            for (int i = 416;i < lines.Length; i++)
            {
                JdPreMethod();
                driver.FindElement(By.XPath(".//*[@id='shrmn1']")).SendKeys(lines[i]);
                JdPostMethod();
                //bool limit = driver.FindElement(By.Id("best_deal_resp_maxlimit")).Enabled;
                Thread.Sleep(5000);
            }
        }
        #endregion


        #region FreeSMS
        [TestMethod]
        [TestCategory("FreeSMS")]
        public void Way2smsTest()
        {
            int lastTimeCount = 4664;
            int lastCompletedCount = lastTimeCount;
            lastCompletedCount = Way2Sms(lastTimeCount, out lastCompletedCount);

            lastCompletedCount = I60By2SMS(lastCompletedCount, out lastCompletedCount);

            Console.WriteLine("Last completed value is: " + lastCompletedCount); 
        }
        
        #endregion


        #region PhoneSMS
        [TestCategory("PhoneSMS")]
        public void MightyText()
        {
            driver.Navigate().GoToUrl("https://mightytext.net/web8/");

            string[] lines = File.ReadAllLines(@"D:\Selenium_Tutorial\VishwasContacts.txt", System.Text.Encoding.UTF8);
            string username = "bookbrother10";
            string password = "bookbrother123";
            string message = "Hi bookbindass.com 3rd anniversary Offer.Get upto Rs 1000 off on your FLIGHTS, HOTEL & PACKAGES.Call 9129888888 Behalf of Vishwas Chadha (Co Founder) 9896577333";

            driver.FindElement(By.XPath(".//*[@id='identifierId']")).SendKeys(username);
            driver.FindElement(By.XPath(".//*[@id='identifierNext']/content/span")).Click(); Thread.Sleep(4000);
            driver.FindElement(By.XPath(".//*[@id='password']/div[1]/div/div[1]/input")).SendKeys(password);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id='passwordNext']/content/span")).Click();
            Thread.Sleep(15000);

            for (int i = 321; i < lines.Length; i++)
            {
                driver.FindElement(By.XPath(".//*[@id='newSms']/span")).Click();
                driver.FindElement(By.XPath(".//*[@id='selectContactForSingleCompose']")).SendKeys(lines[i]);
                driver.FindElement(By.XPath(".//*[@id='send-one-text']")).Click();

                Thread.Sleep(2000);
                driver.FindElement(By.XPath(".//*[@id='send-one-text']")).Clear();
                driver.FindElement(By.XPath(".//*[@id='send-one-text']")).SendKeys(message);
                driver.FindElement(By.XPath(".//*[@id='send-button-single-text']")).Click();
                Thread.Sleep(5000);
                //Delete that sent message
                /*var messageList = driver.FindElement(By.Id("pinnedContent")).FindElement(By.Id("threadListHolder")).FindElements(By.TagName("li"));
                
                string data = messageList[0].Text;
                if (data.Contains(lines[i]))
                {
                    Thread.Sleep(20000);
                    messageList[0].Click();
                    driver.FindElement(By.CssSelector("svg[class='material-svg delete-thread-icon']")).Click();
                    driver.FindElement(By.XPath(".//*[@id='custom-alert-and-confirm-modal-ok-button']")).Click();
                }
                 */

                driver.Navigate().Refresh();
                Thread.Sleep(5000);
            }
        }

        [TestCategory("PhoneSMS")]
        [TestMethod]
        public void MySMS()
        {
            //int startValue = 1937;
            string[] FreeSms = File.ReadAllLines(@"D:\Project\UnitTestProject3\UnitTestProject3\TestDataFiles\PhoneSmsTest.txt", System.Text.Encoding.UTF8);
            IList<string> container = FreeSms[0].Split('-');
            int startValue = Convert.ToInt32(container[1]);
            driver.Navigate().GoToUrl("https://app.mysms.com/");

            string[] lines = File.ReadAllLines(@"D:\Project\UnitTestProject3\UnitTestProject3\TestDataFiles\VishwasContacts.txt", System.Text.Encoding.UTF8);
            string username = "bookbrother10";
            string password = "bookbrother123";
            string message = "Book cheap online Flight Tickets only at www.bookbindass.com ! T&C* Apply";
            
            driver.FindElement(By.CssSelector("button[class='styledButton']")).Click();
            driver.FindElement(By.ClassName("GO2BGF-CHI")).Click();

            var windows = driver.WindowHandles;

            driver.SwitchTo().Window(driver.WindowHandles[1]); Thread.Sleep(3000);
            
            GmailLogin(username,password);

            Thread.Sleep(6000);

            driver.SwitchTo().Window(driver.WindowHandles[0]);            

            for (int i = startValue; 1 < lines.Length; i++)
            {
                if (i >= (startValue + 100))
                {
                    break;
                }
                driver.Navigate().GoToUrl("https://app.mysms.com/#compose"); Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("input[class='recipientTextBox']")).Clear();
                for (int a = i; a < (i+7); a++)
                {
                    driver.FindElement(By.CssSelector("input[class='recipientTextBox']")).SendKeys(lines[a]);
                    driver.FindElement(By.CssSelector("input[class='recipientTextBox']")).SendKeys(OpenQA.Selenium.Keys.Enter);
                }

                i= i + 7;
                
                driver.FindElement(By.CssSelector("div[class='textarea']")).Clear();

                driver.FindElement(By.CssSelector("div[class='textarea']")).SendKeys(message);

                driver.FindElement(By.CssSelector("button[class*='styledButton sendButton']")).Click();

                Thread.Sleep(55000);
            }

            var reader = new StreamReader(@"D:\Selenium_Tutorial\Test Cases Data\PhoneSmsTest.txt"); 
            var str = reader.ReadToEnd(); 
            reader.Close();
            var replacedString = str.Replace(str.ToString(), "startValue-" + (startValue + 100).ToString());
            var writer = new StreamWriter(@"D:\Selenium_Tutorial\Test Cases Data\PhoneSmsTest.txt"); 
            writer.Write(replacedString); 
            writer.Close();
        }

        #endregion


        #region SEO

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

        [TestCategory("SEO")]
        [TestMethod]
        public void SEO_6()
        {
            driver.Navigate().GoToUrl("http://tools.seochat.com/tools/internal-page-crawl/#sthash.9tnQwBUH.dpbs");
            driver.FindElement(By.XPath(".//*[@id='post-2']/form/input[1]")).SendKeys("http://www.bookbindass.com");
            driver.FindElement(By.XPath(".//*[@id='post-2']/form/input[2]")).Click();
            Thread.Sleep(200000);            
        }

        [TestCategory("SEO")]
        [TestMethod]
        public void SEO_7()
        {
            driver.Navigate().GoToUrl("https://www.internetmarketingninjas.com/seo-tools/google-sitemap-generator/");
            driver.FindElement(By.XPath(".//*[@id='url']")).SendKeys("www.bookbindass.com");
            driver.FindElement(By.XPath(".//*[@id='seo-toolsgoogle-sitemap-generator-page']/div[4]/form/input[2]")).Click();
            Thread.Sleep(200000);
        }

        #endregion


        #region SearchEngine
        [TestCategory("SearchEngine")]
        [TestMethod]
        public void SearchEngine_1()
        {
            driver.Navigate().GoToUrl("https://google.co.in/");
            driver.FindElement(By.XPath(".//*[@id='lst-ib']")).SendKeys("bookbindass flights");
            driver.FindElement(By.XPath(".//*[@id='tsf']/div[2]/div[3]/center/input[1]")).Click();
            driver.FindElement(By.XPath(".//*[@id='rso']/div/div/div[1]/div/div/h3/a")).Click();
            Thread.Sleep(20000);
        }

        [TestCategory("SearchEngine")]
        [TestMethod]
        public void SearchEngine_2()
        {
            driver.Navigate().GoToUrl("https://bing.com/");
            driver.FindElement(By.XPath(".//*[@id='sb_form_q']")).SendKeys("bookbindass");
            driver.FindElement(By.XPath(".//*[@id='sb_form_go']")).Click();
            driver.FindElement(By.XPath(".//*[@id='b_results']/li[1]/h2/a")).Click();
            Thread.Sleep(20000);
        }

        [TestCategory("SearchEngine")]
        [TestMethod]
        public void SearchEngine_3()
        {
            driver.Navigate().GoToUrl("https://in.yahoo.com");
            driver.FindElement(By.XPath(".//*[@id='uh-search-box']")).SendKeys("bookbindass");
            driver.FindElement(By.XPath(".//*[@id='uh-search-button']")).Click();
            driver.FindElement(By.XPath(".//*[@id='yui_3_10_0_1_1504504936404_378']")).Click();
            Thread.Sleep(20000);
        }

        [TestCategory("SearchEngine")]
        [TestMethod]
        public void SearchEngine_4()
        {
            driver.Navigate().GoToUrl("http://www.ask.com/");
            driver.FindElement(By.XPath(".//*[@id='search-box']")).SendKeys("bookbindass");
            driver.FindElement(By.XPath(".//*[@id='PartialHome-form']/button")).Click();
            driver.FindElement(By.XPath(".//*[@id='yui_3_10_0_1_1504504936404_378']")).Click();
            Thread.Sleep(20000);
        }

        #endregion


        #region GMAIL
        [TestCategory("GMAIL")]
        [TestMethod]
        public void Mail()
        {
            driver.Navigate().GoToUrl("https://www.gmail.com");
            driver.FindElement(By.XPath(".//*[@id='identifierId']")).SendKeys("ops@bookbindass.com");
            driver.FindElement(By.XPath(".//*[@id='identifierNext']/content/span")).Click(); Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id='account-list']/li[1]/button")).Click(); Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id='Passwd']")).SendKeys("Babajirehmatkero");
            driver.FindElement(By.XPath(".//*[@id='signIn']")).Click(); Thread.Sleep(3000);
            
            driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/#contacts");
            Thread.Sleep(9999);

            IList<IWebElement> GroupsList = new List<IWebElement>();
            GroupsList = driver.FindElement(By.ClassName("TK")).FindElements(By.ClassName("aim"));
            
            Thread.Sleep(9999);
            IList<IWebElement> Tables = new List<IWebElement>();

            Tables = driver.FindElements(By.TagName("table"));
            int tableNumber = 0;

            for (int b = 0; b < Tables.Count; b++)
            {
                if (Tables[b].Text == "")
                { continue; }
                else 
                {
                    tableNumber = b;
                }
            }

            for (int a = 0; a < GroupsList.Count; a++)
            {
                string text = GroupsList[a].Text;
                if ((text == "My Contacts") || (text == "Starred"))
                { continue; }
                GroupsList[a].Click();

                IList<IWebElement> RowsList = new List<IWebElement>();

                List<string> emailsList = new List<string>();

                RowsList = Tables[tableNumber].FindElements(By.TagName("tr"));

                for (int e = 0; e < RowsList.Count; e++)
                {
                    for (int d = 0; d < RowsList.Count; d++)
                    {
                        IList<IWebElement> columnList = new List<IWebElement>();

                        columnList = RowsList[d].FindElements(By.TagName("td"));

                        for (int c = 0; c < columnList.Count; c++)
                        {
                            if (columnList[c].Text.Contains("@"))
                            {
                                emailsList.Add(columnList[c].Text);
                                continue;
                            }
                        }
                    }
                }
                break;
            }
        }
        #endregion


        #region Classifieds

        #region ClickIn
        [TestMethod]
        [TestCategory("Classifieds")]
        public void Clickin()
        {
            string username = "bookbrother10@gmail.com";
            string password = "zaq1ZAQ!";
            string longDesc = "Scoot Airline International fares from Chennai to Singapore starting Rs 4999/- only at bookbindass.com.";
            string[] Cities = File.ReadAllLines(@"D:\Project\UnitTestProject3\UnitTestProject3\TestDataFiles\Clickin.txt", System.Text.Encoding.UTF8);
 
            driver.Navigate().GoToUrl("https://www.click.in/mylisting.html");
            driver.FindElement(By.XPath(".//*[@id='customBtn']/span[2]")).Click();

            driver.FindElement(By.XPath(".//*[@id='clickin-signInBlock']/div[1]/input")).SendKeys(username);
            driver.FindElement(By.XPath(".//*[@id='clickin-signInBlock']/div[2]/input")).SendKeys(password);
            driver.FindElement(By.XPath(".//*[@id='clickin-signInBlock']/div[4]/input")).Click();
            Thread.Sleep(5000);

            for (int a = 0; a < Cities.Length; a++)
            {
                //IAlert alert = driver.SwitchTo().Alert();
                //alert.Accept();

                string subject = "Scoot Flights to Singapore Starting Rs 4999 at www.bookbindass.com " + Cities[a] + " Special.";

                string customurl = ("https://www.click.in/" + Cities[a].ToLower() + "/classifieds/148/post.html");
                driver.Navigate().GoToUrl(customurl); Thread.Sleep(3000);
                driver.FindElement(By.XPath(".//*[@id='fld_36']")).SendKeys("bookbindass.com");
                driver.FindElement(By.XPath(".//*[@id='select2-chosen-1']")).Click();
                var locality = driver.FindElement(By.Id("select2-results-1")).FindElements(By.TagName("li"));
                locality[1].Click();

                driver.FindElement(By.XPath(".//*[@id='fld_1']")).SendKeys(subject);
                driver.FindElement(By.XPath(".//*[@id='fld_3']")).SendKeys(longDesc);
                driver.FindElement(By.XPath(".//*[@id='btn_submit']/input")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("div[class='popup-link']")).Click();
                Thread.Sleep(8000);
            }
        }
        #endregion

        #region Locanto
        [TestMethod]
        [TestCategory("Classifieds")]
        public void Locanto()
        {
            string username = "bookbrother10@gmail.com";
            string password = "zaq1ZAQ!";

            string longDesc = "Scoot Airline International fares from Chennai to Singapore starting Rs 4999/- only at bookbindass.com.";
            
            string[] Cities = File.ReadAllLines(@"D:\Project\UnitTestProject3\UnitTestProject3\TestDataFiles\Locanto.txt", System.Text.Encoding.UTF8);
            
            driver.Navigate().GoToUrl("https://my.locanto.info/login?cid=3");
            driver.FindElement(By.XPath(".//*[@id='middle']/div[2]/form/div[1]/div[2]/div[1]/label/input")).SendKeys(username);
            driver.FindElement(By.XPath(".//*[@id='middle']/div[2]/form/div[1]/div[2]/div[2]/label/input")).SendKeys(password);
            driver.FindElement(By.XPath(".//*[@id='middle']/div[2]/form/div[3]/button")).Click(); Thread.Sleep(4000);
            
            for (int i = 0; i < Cities.Length;i++ )
            {
                //IAlert alert = driver.SwitchTo().Alert();
                //alert.Accept();
                string url = "https://www.locanto.net/post/S/518/1/";
                string subject = "Scoot Flights to Singapore Starting Rs 4999 at www.bookbindass.com " + Cities[i] + " Special";
                driver.Navigate().GoToUrl(url);
                driver.FindElement(By.XPath(".//*[@id='subject']")).SendKeys(subject);
                driver.FindElement(By.XPath(".//*[@id='redactor-uuid-0']")).SendKeys(longDesc);

                driver.FindElement(By.XPath(".//*[@id='js-feature_container']/div[2]/div[4]/div/div[2]/input")).SendKeys("www.bookbindass.com");
                driver.FindElement(By.XPath(".//*[@id='target_form']/div[6]/button[2]")).Click(); Thread.Sleep(4000);
                driver.FindElement(By.CssSelector("button[class*='paf_proceed_btn']")).Click();
                Thread.Sleep(9000);
            }
        }
        #endregion

        #endregion
        

        #region STUDY
        [TestMethod]
        [TestCategory("Study")]
        public void IDEASPROJECT()
        {
            //open application
            driver.Navigate().GoToUrl("http://example.com/doc.html");
            driver.Manage().Window.Maximize();

            //Download with accepting - Click on My Doc Pdf
            driver.FindElement(By.Id("mydocpdf")).Click();

            Assert.IsTrue(driver.Title.ToString().Contains("403"), "403 page not found when user tried to download pdf doc without accepting terms.");
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
        [TestCategory("Study")]
        public void CheckForRadioCheckbox()
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/"); driver.Manage().Window.Maximize();
        }

        [TestMethod]
        [TestCategory("Study")]
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

        [TestMethod]
        [TestCategory("Study")]
        public void Table()
        {
            driver.Navigate().GoToUrl("https://www.w3schools.com/html/html_tables.asp");
            IWebElement table = driver.FindElement(By.Id("customers"));

            int tableRows = table.FindElements(By.TagName("tr")).Count;

            string tableData = driver.FindElement(By.XPath(".//*[@id='customers']/tbody/tr[3]/td[2]")).Text;

        }

        [TestMethod]
        [TestCategory("Study")]
        public void InlineElements()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.FindElement(By.XPath(".//*[@id='gbwa']/div[1]/a")).Click();

            driver.FindElement(By.XPath(".//*[@id='gb36']/span[1]")).Click();

            driver.Navigate().Back();
        }

        #endregion


        #region PreferredCustomer
        // Send Personal message
        // Send email
        // Invite at linkedin
        // Collect reviews
        // Link with facebook
        // Follow them on twitter
        // Share youtube videos with them
        // Prepare database for their DOB
        #endregion

    }
}
