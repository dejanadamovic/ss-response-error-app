using System;
using System.Collections.Generic;
using System.Linq;
using ResponseErrorApp.Models;
using ServiceStack;
using ServiceStack.Text;

namespace ResponseError.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new JsonServiceClient("http://localhost:5000");

            //100 items in list
            try
            {
                client.Post(CreateRequest(itemsCount: 100, throwServerException: true)).PrintDump();
            }
            catch (Exception e)
            {
                e.Message.PrintDump();
            }

            //1000 items in list
            try
            {
                client.Post(CreateRequest(itemsCount: 1000, throwServerException: true)).PrintDump();
            }
            catch (Exception e)
            {
                e.Message.PrintDump();
            }

            //10000 items in list
            try
            {
                client.Post(CreateRequest(itemsCount: 10000, throwServerException: true)).PrintDump();
            }
            catch (Exception e)
            {
                e.Message.PrintDump();
            }


            Console.ReadLine();
        }

        private static SampleRequest CreateRequest(int itemsCount, bool throwServerException)
        {
            var req = new SampleRequest()
            {
                ThrowException = throwServerException,
                Samples = new List<Sample>()
            };

            Enumerable.Range(1, itemsCount).Each(x =>
            {
                req.Samples.Add(new Sample
                {
                    Prop1 = $"Prop1-{x}",
                    Prop2 = $"Prop2-{x}",
                    Prop3 = $"Prop3-{x}",
                });
            });

            return req;
        }
    }
}
