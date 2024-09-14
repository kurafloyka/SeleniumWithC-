using System;
using OpenQA.Selenium;

namespace SeleniumWithCSharp.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement searchArea => driver.FindElement(By.Name("q"));

        public void SearchKeywordOnGoogle(string text)
        {


            searchArea.ClickElement();
            searchArea.SendKeysElement( text);
            searchArea.SendKeysElement( Keys.Enter);

        }

        public (bool,bool) IsSearchAreaVisible()
        {
            return (searchArea.Displayed,searchArea.Enabled);
        }
    }
}

