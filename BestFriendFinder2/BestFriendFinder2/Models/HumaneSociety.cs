using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BestFriendFinder2.Models
{
    public class HumaneSociety
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zipcode { get; set; }

        [Display(Name = "Address")]
        public string FullAddress
        {
            get
            {
                return StreetAddress + " " + City + ", " + State + " " + Zipcode;
            }
        }
    }
}