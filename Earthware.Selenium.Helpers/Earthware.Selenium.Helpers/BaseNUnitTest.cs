namespace Earthware.Selenium.Helpers
{
    using System.Configuration;

    using NUnit.Framework;

    public class BaseNUnitTest<T>
        where T : Drivers.DriverContainer, new()
    {
        protected Drivers.DriverContainer DriverContainer { get; private set; }

        protected string BaseUrl => ConfigurationManager.AppSettings["baseUrl"];

        [OneTimeSetUp]
        public void Setup()
        {
            DriverContainer = new T();

            DriverContainer.Driver.Navigate().GoToUrl(this.BaseUrl);
        }

        [TearDown]
        public void Teardown()
        {
            DriverContainer.Driver.Manage().Cookies.DeleteAllCookies();
            DriverContainer.Driver.Url = this.BaseUrl;
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            DriverContainer.Cleanup();
        }
    }
}