﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class City
    {
        [Key]
        public string Code { get; set; }
        public string Title { get; set; }
        public List<Region> Regions { get; set; }
    }
}