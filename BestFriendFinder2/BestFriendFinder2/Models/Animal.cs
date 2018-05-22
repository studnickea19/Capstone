using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BestFriendFinder2.Models
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public bool Neutered { get; set; }

        public int Age { get; set; }

        [ForeignKey("HumaneSociety")]
        [Display(Name="Humane Society")]
        public int HumaneSocietyID { get; set; }

        public virtual HumaneSociety HumaneSociety { get; set; }
    }
}