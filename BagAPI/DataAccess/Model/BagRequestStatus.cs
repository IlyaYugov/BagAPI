using System.Collections.Generic;

namespace DataAccess.Model
{
    public class BagRequestStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<BagRequest> Requests { get; set; }
    }
}