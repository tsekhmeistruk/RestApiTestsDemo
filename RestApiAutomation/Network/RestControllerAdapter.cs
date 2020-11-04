using System;
using System.Diagnostics;

namespace RestApiAutomation.Network
{
    public class RestControllerAdapter
    {
        private RestController _restController;
        public RestControllerAdapter(RestController restController)
        {
            _restController = restController;
        }
        public ResponseModel Get<T>()
        {
            Stopwatch sw = Stopwatch.StartNew();
            var response = _restController.Get<T>();
            Console.Out.WriteLine("Elapsed Time: " + sw.Elapsed);
            return response;
        }

        public ResponseModel Get<T>(int id)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var response = _restController.Get<T>(id);
            Console.Out.WriteLine("Elapsed Time: " + sw.Elapsed);
            return response;
        }
    }
}
