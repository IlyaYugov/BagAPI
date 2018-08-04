using System.Collections.Generic;

namespace DataAccess.Model
{
    public class Bag
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Descriprion { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int Weight { get; set; }

        public BagType Type { get; set; }
        public List<Request> Requests { get; set; }
    }
}