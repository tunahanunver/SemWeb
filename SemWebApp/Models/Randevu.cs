using System.ComponentModel.DataAnnotations;

namespace SemWebApp.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public int DersId { get; set; }
        public Ders Ders { get; set; }
        [Required]
        public DateTime RandevuTarihi { get; set; }
        [Required]
        [StringLength(20)]
        public string Durum { get; set; }
    }
}
