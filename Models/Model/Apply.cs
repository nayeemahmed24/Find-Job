using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Model
{
    public class Apply
    {
        [Key] public int Id { get; set; }
        [ForeignKey("UserID")] public UserAccount user { get; set; }
        public int PostId { get; set; }
    }
}
