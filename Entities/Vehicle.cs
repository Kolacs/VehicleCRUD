using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Vehicle
    {
        [Key]
        public string RegistrationId { get; set; }
        public string Description { get; set; }

        public int TypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        public int MakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
    }
}
