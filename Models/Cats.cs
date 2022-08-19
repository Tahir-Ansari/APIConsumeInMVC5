using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeAPI.Models
{
    public class Cats
    {
        public string Fact { get; set; }

        public int Length { get; set; }
    }

    public class Dogs
    {
        public string Message { get; set; }
        public string Status { get; set; }
    }
}