using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApiTokenUser.Entity.Models
{
    public class CustomUserRole : IdentityUserRole<long>
    {
        [Key]
        public long Id { get; set; }
    }
}
