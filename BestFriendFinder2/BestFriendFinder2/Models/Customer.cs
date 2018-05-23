using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestFriendFinder2.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> Attributes { get; set; }

        public string UserID { get; set; }
    }
}