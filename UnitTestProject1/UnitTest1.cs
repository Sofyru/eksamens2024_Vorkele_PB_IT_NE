using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WindowsFormsApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;

        [TestInitialize] 
        public void Setup()
        {
            var options = new ChromeOptions();
            driver = new ChromeDriver(@"C:\Users\Sonja\source\repos\eksamens2024_Vorkele_PB_IT_NE\packages\Chromedriver\chromedriver-win64\", options); 
            driver.Navigate().GoToUrl("https://www.ebay.com"); 
        }

        [TestMethod] 
        public void Test1_field()
        {
            var searchField = driver.FindElement(By.Id("gh-ac")); 
        }

        [TestMethod]
        public void Test2_search()
        {
            var searchButton = driver.FindElement(By.Id("gh-btn")); 
        }

        [TestCleanup] 
        public void Teardown()
        {
            driver.Quit(); 
        }
    }
}
