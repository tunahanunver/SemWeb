using System.ComponentModel.DataAnnotations;

namespace SemWeb.Models
{
    public class Abonelik
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        [Required]
        public DateTime BaslangicTarihi { get; set; }
        [Required]
        public DateTime BitisTarihi { get; set; }
        [Required]
        [StringLength(20)]
        public string Tur { get; set; }
        [Required]
        public decimal Fiyat { get; set; }
        public bool AktifMi { get; set; }
        public List<Odeme> Odemeler { get; set; }
        public Abonelik()
        {
            Odemeler = new List<Odeme>();
        }
    }
}
