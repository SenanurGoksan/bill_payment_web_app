using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BillApp2.Models
{
    public class Fatura
    {
            [Key]
            public int? faturaNo { get; set; }

            [Required]
            [Column(TypeName = "decimal(18, 2)")]
            public decimal tutar { get; set; }

            [Required]
            public DateTime sonOdemeTarihi { get; set; }

            [JsonIgnore]
            public int userId { get; set; }

            [JsonIgnore]
            public int kurumId { get; set; }

            // Aşağıdaki özellikler sayesinde ilişkileri modelledik, Fluent API gerekmiyor.
            [ForeignKey("userId")]
            public Bireysel Bireysel { get; set; }

            [ForeignKey("kurumId")]
            public Kurumsal Kurumsal { get; set; }


    }
}





