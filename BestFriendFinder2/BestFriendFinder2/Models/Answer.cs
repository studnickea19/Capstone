using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BestFriendFinder2.Models
{
    public class Answer
    {

        public int Id { get; set; }

        public string AnswerContent { get; set; }

        [ForeignKey("Question")]

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}