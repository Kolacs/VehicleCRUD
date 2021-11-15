using DataLayer.UnitOfWork;
using Entities;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class VehicleController
    {
        IUnitOfWork unitOfWork = new UnitOfWork();

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return unitOfWork.VehicleRepo.ReadAll();
        }

        public IEnumerable<VehicleType> GetAllVehicleTypes()
        {
            return unitOfWork.VehicleTypeRepo.ReadAll();
        }

        public IEnumerable<VehicleMake> GetAllVehicleMakes()
        {
            return unitOfWork.VehicleMakeRepo.ReadAll();
        }
        public Vehicle ReadVehicle(string RegNo)
        {
            return unitOfWork.VehicleRepo.Read(RegNo);
        }

        public void CreateVehicle(Vehicle vehicle)
        {
            unitOfWork.VehicleRepo.Create(vehicle);
        }

        public void DeleteVehicle(Vehicle Vehicle)
        {
            unitOfWork.VehicleRepo.Delete(Vehicle);
        }
        public void UpdateVehicle(Vehicle vehicle)
        {
            unitOfWork.VehicleRepo.Update(vehicle);
        }
    }
}
