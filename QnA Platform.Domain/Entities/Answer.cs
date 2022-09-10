using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QnA_Platform.Domain.Entities
{
    public class Answer
    {
        public int AnswerId { get; set; }
        [Required]
        [StringLength(250)]
        public string AnswerValue { get; set; }
        [Required]
        public int VoteScore { get; set; }
        [Required]
        public int QuestionId { get; set; }
    }

}
