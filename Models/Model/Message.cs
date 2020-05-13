using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Model
{
    public class Message
    {

        [Key] public int Id { get; set; }

        [ForeignKey("senduser")] public UserAccount SenderUser { get; set; }
        [Required] public String text { get; set; }
        public String SenderUsername { get; set; }
        public String ReciverUsername { get; set; }
    }
}
