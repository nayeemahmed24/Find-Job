using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Model
{
    public class Apply
    {
        public Apply(UserAccount _user, int postId)
        {
            user = _user;
            PostId = postId;
        }
        [Key] public int Id { get; set; }
        [ForeignKey("UserID")] public UserAccount user { get; set; }
        public int PostId { get; set; }
    }
}
