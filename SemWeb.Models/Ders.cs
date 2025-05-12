namespace SemWeb.Models
{
    public class Ders
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public int MaxKatilimci { get; set; }
        public int EgitmenId { get; set; }
        public Kullanici Egitmen { get; set; }
        public List<Randevu> Randevular { get; set; }

        public Ders()
        {
            Randevular = new List<Randevu>();
        }
    }
}
