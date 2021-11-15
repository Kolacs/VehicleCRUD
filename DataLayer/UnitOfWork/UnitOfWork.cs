using DataLayer.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public VehicleContext _context = new VehicleContext();

        public IGenericRepository<Vehicle> VehicleRepo { get; set; }
        public IGenericRepository<VehicleMake> VehicleMakeRepo { get; set; }
        public IGenericRepository<VehicleType> VehicleTypeRepo { get; set; }

        public UnitOfWork()
        {
            VehicleRepo = new GenericRepository<Vehicle>(_context);
            VehicleMakeRepo = new GenericRepository<VehicleMake>(_context);
            VehicleTypeRepo = new GenericRepository<VehicleType>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
