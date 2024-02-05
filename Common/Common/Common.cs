using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace Common
{
    public class Common
    {
        public enum BrowserType
        {
            Chrome,
            FireFox,
            Edge
        }
        public enum MessageColor
        {
            RED,
            WHITE,
            YELLOW
        }

        private WebDriver webDriver;
        private WebDriverWait webDriverWait;

        public WebDriver GetWebDriver()
        {
            return webDriver;
        }

        public WebDriverWait GetWebDriverWait()
        {
            return webDriverWait;
        }
        public void LaunchBrowser(BrowserType browserType)
        {
            try
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        webDriver = new ChromeDriver();
                        break;
                    case BrowserType.FireFox:
                        webDriver = new FirefoxDriver();
                        break;
                    case BrowserType.Edge:
                        webDriver = new EdgeDriver();
                        break;
                    default:
                        webDriver = new ChromeDriver();
                        break;
                }


                webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                webDriver.Manage().Window.Maximize();
            }
            catch (Exception e)
            {
                Report(e.Message, MessageColor.RED);
            }
        }

        public void NivigateTo(String URL)
        {
            try
            {
                webDriver.Navigate().GoToUrl(URL);
            }
            catch (Exception e)
            {
                Report(e.Message, MessageColor.RED);
            }
        }

        public void CloseBrowser()
        {
            try
            {
                webDriver.Close();
            }
            catch (Exception e)
            {
                Report(e.Message, MessageColor.RED);
            }
        }

        public void ExitEnvironment()
        {

            try
            {
                webDriver.Quit();

            }
            catch (Exception e)
            {
                Report(e.Message, Common.MessageColor.RED);
            }

        }

        public void SwitchToWindow(String WindowTitle)
        {
            try
            {
                IList<String> widows = new List<String>(webDriver.WindowHandles);

                foreach (String window in widows)
                {

                    webDriver.SwitchTo().Window(window);

                    if (webDriver.Title.Trim().Contains(WindowTitle))
                    {
                        Report("Switch to " + WindowTitle + " succeed");
                        break;
                    }

                }

            }
            catch (Exception e)
            {
                Report(e.Message, Common.MessageColor.RED);
            }
        }

        public void await(int seconds)
        {
            Report("Waitinf for " + seconds + " seconds");
            Thread.Sleep(seconds * 1000);
        }

        public static void Report(String message)
        {
            Console.WriteLine(message);
        }

        public static void Report(String message, MessageColor outputColor)
        {
            if (outputColor.Equals(MessageColor.RED))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }

            Assert.IsTrue(false, message);
        }

        public string CleanUpText(string text)
        {
            string cleanedText = "";

            try
            {
                cleanedText = Regex.Replace(text, "[^a-zA-Z ]", " ");

                cleanedText = Regex.Replace(cleanedText, @"\s+", " ");

                cleanedText = cleanedText.ToLower();

            }
            catch(Exception e)
            {
                Report(e.Message, MessageColor.RED);
            }

            return cleanedText;
        }

        public Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> wordsDictionary = null;

            try
            {
                string[] words = text.Split(' ');

                wordsDictionary = new Dictionary<string, int>();

                foreach (string word in words)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        if (wordsDictionary.ContainsKey(word))
                        {
                            wordsDictionary[word]++;
                        }
                        else
                        {
                            wordsDictionary[word] = 1;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Report(e.Message, MessageColor.RED);
            }

            return wordsDictionary;
        }

        public void PrintResultDictionary(Dictionary<string, int> wordsDictionary)
        {            
            try
            {
                foreach (var entry in wordsDictionary)
                {
                    Report($"Word: {entry.Key}, {entry.Value}");
                }

                Report($"Total unique word: {wordsDictionary.Count}");

            }
            catch (Exception e)
            {
                Report(e.Message, MessageColor.RED);
            }
        }

        public string Get_TestDrivenDevelopmentTitle_Text(string htmlSourse)
        {
            string foundText = "";

            try
            {                
                HtmlDocument htmlDoc = new HtmlDocument();

                htmlDoc.LoadHtml(htmlSourse);

                HtmlNode paragraphNode = htmlDoc.DocumentNode.SelectSingleNode("//h3/span[@id='Test-driven_development']");

                foundText = paragraphNode.InnerText;
            }
            catch (Exception e)
            {
               Report(e.Message, MessageColor.RED);
            }

            return foundText;
        }

        public string Get_TextContent_ByTitle(string title, string htmlSourse)
        {
            string foundText = "";

            try
            {
                HtmlDocument htmlDoc = new HtmlDocument();

                htmlDoc.LoadHtml(htmlSourse);

                HtmlNode paragraphNode = htmlDoc.DocumentNode.SelectSingleNode("//p[preceding-sibling::h3/span[contains(.,'"+ title + "')]][1]");

                foundText = paragraphNode.InnerText;
            }
            catch (Exception e)
            {
                Report(e.Message, MessageColor.RED);
            }

            return foundText;
        }
    }
}
