using System.ComponentModel.DataAnnotations;

namespace WebApiTokenUser.Models
{
    public class Data
    {
        [Key]
        public int Id { get; set; }

        public string Topic { get; set; }

        public string Description { get; set; }
    }
}