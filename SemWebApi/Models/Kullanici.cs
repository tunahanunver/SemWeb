using System.ComponentModel.DataAnnotations;

namespace SemWeb.Models
{
    public class Kullanici
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [Display(Name = "Ad")]
        [StringLength(50)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [Display(Name = "Soyad")]
        [StringLength(50)]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(50)]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        [Display(Name = "Email")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [Display(Name = "Telefon")]
        [StringLength(20)]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Doğum tarihi zorunludur.")]
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime DogumTarihi { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Rol seçimi zorunludur.")]
        [Display(Name = "Rol")]
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
