using BillApp2.Models;

namespace BillApp2.DTOs
{
    public class FaturaDto
    {

        public decimal tutar { get; set; }


        public int userId { get; set; } 

        public int kurumId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string kurumAdi { get; set; }


    }
}
