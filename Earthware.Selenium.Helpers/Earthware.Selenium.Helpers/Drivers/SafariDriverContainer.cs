namespace Earthware.Selenium.Helpers.Drivers
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;

    public class SafariDriverContainer : DriverContainer
    {
        protected override DesiredCapabilities Capabilities
        {
            get
            {
                var caps = new DesiredCapabilities();

                caps.SetCapability("browser", "Safari");
                caps.SetCapability("browser_version", "9.1");
                caps.SetCapability("os", "OS X");
                caps.SetCapability("os_version", "El Capitan");
                caps.SetCapability("resolution", "1920x1080");

                return caps;
            }
        }
    }
}