namespace PomoćniProjekatGamingHub.EntityModels
{
    public class IgraKonzola
    {
        public int IgraID { get; set; }
        public Igra Igra { get; set; }
        public int KonzolaID { get; set; }
        public Konzola Konzola { get; set; }
    }
}