using System.ComponentModel.DataAnnotations;

namespace SemWebApp.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Ad { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Soyad { get; set; }
        
        [Required]
        [StringLength(50)]
        public string KullaniciAdi { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        
        [Phone]
        [StringLength(20)]
        public string Telefon { get; set; }
        
        public DateTime DogumTarihi { get; set; }
        
        [Required]
        public string Sifre { get; set; }
        
        [Required]
        public string Rol { get; set; }
        
        public DateTime OlusturulmaTarihi { get; set; }
        
        public List<Randevu> Randevular { get; set; }
        public List<Abonelik> Abonelikler { get; set; }
        public List<Odeme> Odemeler { get; set; }
        public List<Ders> VerdigiDersler { get; set; }

        public Kullanici()
        {
            Randevular = new List<Randevu>();
            Abonelikler = new List<Abonelik>();
            Odemeler = new List<Odeme>();
            VerdigiDersler = new List<Ders>();
            OlusturulmaTarihi = DateTime.Now;
        }
    }
}
