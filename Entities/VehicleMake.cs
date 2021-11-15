﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VehicleMake
    {
        [Key]
        public int MakeId { get; set; }
        public string Description { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
