using DataLayer.Repository;
using Entities;
using System;

namespace DataLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<VehicleMake> VehicleMakeRepo { get; set; }
        IGenericRepository<Vehicle> VehicleRepo { get; set; }
        IGenericRepository<VehicleType> VehicleTypeRepo { get; set; }

    }
}