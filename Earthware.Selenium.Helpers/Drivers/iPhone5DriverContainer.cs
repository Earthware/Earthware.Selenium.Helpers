namespace Earthware.Selenium.Helpers.Drivers
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;

    public class iPhone5DriverContainer : DriverContainer
    {
        protected override DesiredCapabilities Capabilities
        {
            get
            {
                var caps = new DesiredCapabilities();

                caps.SetCapability("browserName", "iPhone");
                caps.SetCapability("platform", "MAC");
                caps.SetCapability("device", "iPhone 5");

                return caps;
            }
        }
    }
}