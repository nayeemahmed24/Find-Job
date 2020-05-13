using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Model
{
    public class Post
    {
        [Key] public int PostId { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Content { get; set; }
        [ForeignKey("User")] public UserAccount user { get; set; }
    }
}
