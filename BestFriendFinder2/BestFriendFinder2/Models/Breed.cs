using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestFriendFinder2.Models
{
    public class Breed
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> Attributes { get; set; }
    }
}