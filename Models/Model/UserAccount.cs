
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class UserAccount : IdentityUser
    {
        [Required] public string Name { get; set; }
    }
}
