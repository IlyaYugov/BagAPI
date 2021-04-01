namespace DataAccess.Model
{
    public class Bag
    {
        public int Id { get; set; }
        public string Descriprion { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
        public byte[] Photo { get; set; }  

        public BagRequest BagRequest { get; set; }
    }
}