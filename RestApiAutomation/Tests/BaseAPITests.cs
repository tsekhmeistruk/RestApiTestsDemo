using RestApiAutomation.Network;
using RestApiAutomation.ParseHelpers;

namespace RestApiAutomation.Tests
{
    public class BaseAPITests
    {
        public RestController Rest { get; set; }

        public RestControllerAdapter RestAdapter { get; set; }

        public BaseAPITests()
        {
            JsonHelper jh = new JsonHelper("config.json");
            Rest = new RestController(jh.GetJsonValueByKey("url"));
            RestAdapter = new RestControllerAdapter(Rest);
        }
    }
}
