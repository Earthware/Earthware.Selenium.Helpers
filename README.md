# Earthware.Selenium.Helpers

Earthware's Selenium Helpers contains a number of helper classes, extension methods, and drivers for running Selenium on Browserstack. The following is currently included:

* `BaseNUnitTest<T>` - the Base NUnit test which includes `OneTimeTearDown`/`TearDown` and `Setup` methods for starting and tidying up the Selenium driver. `T` is required to be a `Drivers.DriverContainer`.
* `DataGenerator` - currently containing a `RandomString` method. 
* `WebDriverExtensionMethods` - containing a number of extension methods for waiting and checking of values. 
* Drivers - a number of pre-setup drivers are included in the `.Drivers` namespace including `ChromeDriverContainer`, `IE10DriverContainer` and `SafariDriverContainer`.

## Required App.config settings

The library assumes a number of App.config settings have been set:

* `browserstack.user` - The BrowserStack user
* `browserstack.key` - The BrowserStack key
* `browserstack.project` - the name of the project as it should appear in BrowserStack reports
* `baseUrl` - the start/base url that all tests start from
