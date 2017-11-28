using System;
using ResponseErrorApp.Models;
using ServiceStack;

namespace ResponseErrorApp
{
    public class SampleService : Service
    {
        public object Post(SampleRequest req)
        {
            if (req.ThrowException)
            {
                throw new ArgumentException($"Exception thrown from server - {req.Samples.Count} items in list");
            }

            return new SampleResponse
            {
                Message = "Hello from sample service!"
            };
        }
    }
}
