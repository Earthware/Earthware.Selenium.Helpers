namespace Earthware.Selenium.Helpers.Drivers
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;

    public class IE10DriverContainer : DriverContainer
    {
        protected override DesiredCapabilities Capabilities
        {
            get
            {
                var caps = new DesiredCapabilities();

                caps.SetCapability("browser", "IE");
                caps.SetCapability("browser_version", "10.0");
                caps.SetCapability("os", "Windows");
                caps.SetCapability("os_version", "8");
                caps.SetCapability("resolution", "2048x1536");

                return caps;
            }
        }
    }
}