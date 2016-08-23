namespace Earthware.Selenium.Helpers.Drivers
{
    using System;
    using System.Configuration;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Reflection;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    public abstract class DriverContainer
    {
        protected IWebDriver driver;

        public DriverContainer()
        {
        }

        public virtual IWebDriver Driver
        {
            get
            {
                if (this.driver == null)
                {
                    var capability = this.Capabilities;
                    var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                    capability.SetCapability("browserstack.user", ConfigurationManager.AppSettings["browserstack.user"]);
                    capability.SetCapability("browserstack.key", ConfigurationManager.AppSettings["browserstack.key"]);
                    capability.SetCapability("project", ConfigurationManager.AppSettings["browserstack.project"]);
                    capability.SetCapability("build", version);
                    
                    capability.SetCapability("browserstack.debug", true);
                    capability.SetCapability("browserstack.video", true);

                    this.driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
                }

                return this.driver;
            }
        }

        protected abstract DesiredCapabilities Capabilities { get; }

        public void Cleanup()
        {
            if (this.Driver != null)
            {
                try
                {
                    this.Driver.Quit();
                }
                catch
                {
                    // this sometimes randomly fails in browserstack for no reason
                }
            }
        }

        public void TakeScreenshot(string pageName = "")
        {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "screenshots");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var directoryWithPagename = !string.IsNullOrWhiteSpace(pageName) ? Path.Combine(directory, pageName) : directory;

            if (!Directory.Exists(directoryWithPagename))
            {
                Directory.CreateDirectory(directoryWithPagename);
            }

            var path = Path.Combine(directoryWithPagename, $"{this.GetType().Name}{DateTime.Now.ToString("yyyy-MM-dd HHmmssms")}.png");

            this.SaveScreenshot(path);
        }

        protected virtual void SaveScreenshot(string path)
        {
            var screenshoter = (ITakesScreenshot)this.Driver;
            var screenshot = screenshoter.GetScreenshot();

            screenshot.SaveAsFile(path, ImageFormat.Png);
        }
    }
}