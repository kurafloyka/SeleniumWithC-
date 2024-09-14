using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWithCSharp
{
    public static class SeleniumCustomMethods
    {



        public static void ClickElement(this IWebElement locator)
        {

            locator.Click();

        }

        public static void ClearElement(this IWebElement locator)
        {

            locator.Clear();
        }

        public static void SendKeysElement(this IWebElement locator, string text)
        {
            locator.SendKeys(text);
        }


        public static string GetTitle(IWebDriver driver)
        {

            return driver.Title;
        }

        public static void MaximizeWindow(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public static void NavigateToUrl(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void SelectDropDownByText(this IWebElement locator, string text)
        {
            var selectElement = new SelectElement(locator);
            selectElement.SelectByText(text);
        }


        public static void SelectDropDownByValue(this IWebElement locator, string value)
        {
            var selectElement = new SelectElement(locator);
            selectElement.SelectByValue(value);
        }

        public static void MultiSelectElements(this IWebElement locator, string[] values)
        {
            var multiSelect = new SelectElement(locator);

            foreach (var value in values)
            {
                multiSelect.SelectByValue(value);
            }

        }

        public static List<string> GetAllSelectedLists(this IWebElement locator)
        {
            var options = new List<string>();
            var multiSelect = new SelectElement(locator);
            var selectedOption = multiSelect.AllSelectedOptions;

            foreach (IWebElement option in selectedOption)
            {
                options.Add(option.Text);
            }

            return options;
        }
        public static void QuitBrowser(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}

