using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewBoard.Models
{
    public class Messege
    {
        [Key] public int Id { get; set; }
        
        [ForeignKey("senduser")]public UserAcc SenderUser { get; set; }
        [Required] public String text { get; set; }
        public String SenderUsername { get; set; }
        public String ReciverUsername { get; set; }

    }
}
 