using System.ComponentModel.DataAnnotations;

namespace BillApp2.Models
{
    public class Bireysel
    {
        [Key]
        public int idNum { get; set; }

        [Required]
        public string firstName { get; set; }
        [Required]

        public string lastName { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string parola { get; set; }

        public string? Token { get; set; }
        public string? Role { get; set; }


    }

}

