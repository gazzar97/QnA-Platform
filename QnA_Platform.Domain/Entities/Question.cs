using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QnA_Platform.Domain.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        [Required]
        [StringLength(150)]
        public string QuestionHeader { get; set; }

        public List<Answer> Answers { get; set; }


    }
}
