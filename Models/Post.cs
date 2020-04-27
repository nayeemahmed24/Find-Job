using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewBoard.Models
{
    public class Post
    {
        [Key] public int PostId { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Content { get; set; }
        [ForeignKey("User")] public UserAcc user { get; set; }

        public String Username { get; set; }
       
    }
}
