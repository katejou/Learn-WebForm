using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_ex1.Models
{
    public class Candidate
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}