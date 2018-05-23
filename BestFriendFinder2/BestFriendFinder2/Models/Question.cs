using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestFriendFinder2.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string QuestionContent { get; set; }

        public string OptionOne { get; set; }

        public string OptionTwo { get; set; }

        public string Selection { get; set; }
    }
}