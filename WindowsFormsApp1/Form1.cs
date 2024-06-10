using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private IWebDriver driver;
        private Stack<string> searchQueries;

        public Form1()
        {
            InitializeComponent();
            InitializeWebDriver();
            OpenEbayHomePage();
            searchQueries = new Stack<string>();
        }

        private void InitializeWebDriver()
        {
            var chromeOptions = new ChromeOptions();
            string driverPath = @"C:\Users\Sonja\source\repos\eksamens2024_Vorkele_PB_IT_NE\packages\Chromedriver\chromedriver-win64\";
            driver = new ChromeDriver(driverPath, chromeOptions);
        }

        private void OpenEbayHomePage()
        {
            string ebayUrl = "https://www.ebay.com";
            driver.Navigate().GoToUrl(ebayUrl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchQuery = textBox1.Text;
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQueries.Push(searchQuery);
                NavigateToSearchResults(searchQuery);
            }
        }

        private void NavigateToSearchResults(string query)
        {
            string searchUrl = $"https://www.ebay.com/sch/i.html?_nkw={Uri.EscapeDataString(query)}";
            driver.Navigate().GoToUrl(searchUrl);
            textBox2.Text = searchUrl;
            AppendToRichTextBox(searchUrl);
        }

        private void AppendToRichTextBox(string text)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox1.AppendText(Environment.NewLine);
            }
            richTextBox1.AppendText(text);
        }

        private void NavigateToPreviousSearch(string query)
        {
            string previousSearchUrl = $"https://www.ebay.com/sch/i.html?_nkw={Uri.EscapeDataString(query)}";
            driver.Navigate().GoToUrl(previousSearchUrl);
            textBox1.Text = query;
            textBox2.Text = previousSearchUrl;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (searchQueries.Count > 1)
            {
                searchQueries.Pop();
                string previousQuery = searchQueries.Peek();
                NavigateToPreviousSearch(previousQuery);
            }
            else
            {
                driver.Navigate().Back();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            driver.Quit();
        }
    }
}