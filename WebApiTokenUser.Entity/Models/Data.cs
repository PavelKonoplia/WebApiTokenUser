using System.ComponentModel.DataAnnotations;

namespace WebApiTokenUser.Entity.Models
{
    public class Data
    {
        [Key]
        public int Id { get; set; }

        public string Topic { get; set; }

        public string Description { get; set; }

        public int? Year { get; set; }
    }
}