using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewBoard.Models
{
    public class Accept
    {
        [Key] public int Id { get; set; }
        [ForeignKey("UserID")] public UserAcc user { get; set; } 
        public int PostId { get; set; }
        public string Username { get; set; }
    }
}
