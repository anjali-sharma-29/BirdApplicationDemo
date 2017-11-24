using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirdApplication.Models
{
    public class BirdModel
    {
        public string BirdName { get; set; }
        public List<string> BirdBehaviourList { get; set; }
    }
}