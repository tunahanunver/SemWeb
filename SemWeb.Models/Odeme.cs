using System.ComponentModel.DataAnnotations;

namespace SemWeb.Models
{
    public class Odeme
    {
        public int Id { get; set; }

        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public int? AbonelikId { get; set; }
        public Abonelik Abonelik { get; set; }

        [Required]
        public decimal Miktar { get; set; }

        [Required]
        public DateTime OdemeTarihi { get; set; }

        [Required]
        [StringLength(50)]
        public string OdemeYontemi { get; set; }
    }
}
