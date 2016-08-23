namespace Earthware.Selenium.Helpers
{
    using System;
    using System.Linq;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using OpenQA.Selenium.Support.UI;

    public static class WebDriverExtensionMethods
    {
        public static T WaitUntil<T>(this IWebDriver driver, int seconds, Func<IWebDriver, T> func)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            return wait.Until(func);
        }

        public static void ClickDisplayedLink(this IWebDriver driver, string text)
        {
            var link = driver.WaitUntil(15, (d) =>
            {
                return d.FindElements(By.LinkText(text)).FirstOrDefault(i => i.Displayed);
            });

            link.Click();
        }

        public static bool Contains(this IWebDriver driver, string text, int seconds = 30)
        {
            var contains = driver.WaitUntil(seconds, (d) =>
            {
                return d.PageSource.Contains(text);
            });

            return contains;
        }

        public static string GetFormFieldValue(this IWebDriver driver, string name)
        {
            return driver.FindElement(By.Name(name)).GetAttribute("value");
        }

        public static void ScrollTo(this IWebDriver driver, IWebElement element)
        {
            driver.ExecuteJavaScript<string>("arguments[0].scrollIntoView(true);", element); //cant click on it till it has scrolled in the view            
        }

        public static bool WaitUntilSuccessful(this IWebDriver driver, Func<IWebDriver, bool> func, int seconds = 30, int numberOfRetries = 3)
        {
            for (int i = 0; i < numberOfRetries; i++)
            {
                var result = driver.WaitUntil(seconds, func);

                if (result)
                {
                    return true;
                }
            }

            return false;
        }
    }
}