﻿using System.Collections.Generic;

namespace DataAccess.Model
{
    public class RequestStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public List<BugRequest> Requests { get; set; }
    }
}