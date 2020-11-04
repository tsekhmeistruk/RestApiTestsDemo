It is Automation Tests Demo project, which covers some endpoints from site: https://swapi.dev
To run the tests you need to have installed >= .NET Framework v4.5.2

The Allure is used as a report tool and all reports will be placed in the allure-results folder but could be configured from AllureConfig.json (root directory).

There are several options run the tests:
1. From Test Explorer in Visual Studio
2. dotnet test {path_to_your_project}\bin\debug\RestApiAutomation.dll
3. use any other applicable testrunner
4. from CI tool like Jenkins

Because luck of time, here is a list of obvious improvements in code:

Feel free to create your fork and invest to Open Source project :)

TODO:
1) add DI container like nInject + use Interfaces
2) add TestData layer (checking data in response)
3) consider using RestSharp + ApiException
4) for checking structure of response and properties ordering use FluentAsserions which has extended list of useful methods
5) add Logger
6) add html parser for raw allure reports (or even use more powerful tool like ReportPortal)
