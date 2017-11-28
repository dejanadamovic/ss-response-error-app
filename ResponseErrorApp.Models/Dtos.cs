using System;
using System.Collections.Generic;
using ServiceStack;

namespace ResponseErrorApp.Models
{
    public class Sample
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public string Prop3 { get; set; }
    }

    [Route("/sample", Verbs = "POST")]
    public class SampleRequest : IReturn<SampleResponse>
    {
        public bool ThrowException { get; set; }
        public List<Sample> Samples { get; set; }
    }

    public class SampleResponse
    {
        public string Message { get; set; }
    }
}
