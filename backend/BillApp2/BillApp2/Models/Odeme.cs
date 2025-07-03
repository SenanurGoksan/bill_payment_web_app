using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BillApp2.Models
{
    public class Odeme
    {
        [Key]
        public int odemeId { get; set; }
        
        public int? faturaNo { get; set; }
        [ForeignKey("faturaNo")]
        public virtual Fatura Fatura { get; set; }

        [Required]
        public int idNum { get; set; }
        [ForeignKey("idNum")]
        public virtual Bireysel Bireysel { get; set; }
        

        [Required] //son ödeme tarihi olacak 
        public DateTime odenmeTarihi { get; set; }

        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal odenenMiktari { get; set; }

    }
}


