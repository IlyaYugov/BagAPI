using System.Collections.Generic;

namespace DataAccess.Model
{
    public class BagType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public List<Bag> Bags { get; set; }
    }
}