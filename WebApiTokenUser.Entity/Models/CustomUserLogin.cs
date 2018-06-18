using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace WebApiTokenUser.Entity.Models
{
    public class CustomUserLogin : IdentityUserLogin<long>
    {
        [Key]
        public long Id { get; set; }
    }
}
