using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QnA_Platform.Domain.Entities
{
    
    public class User
    {
        [Required]
        [Key]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
