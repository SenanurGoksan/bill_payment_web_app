using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;

namespace BillApp2.Models
{
    public class Kurumsal
    {
        [Key]
        public int kurumId { get; set; }

        [Required]
        public string kurumAdi { get; set; }

        [Required]
        public string adminMail { get; set; }

        [Required]
        public string password { get; set; }

        public string? Token { get; set; }
        public string? Role { get; set; }

    }
}
