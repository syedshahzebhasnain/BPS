using BPSTakeHome.Application.ViewModel;
using BPSTakeHome.Domain.Models;
using System;

namespace BPSTakeHome.Application.Mapper
{
    public static class EmployeeMapping
    {

        public static EmployeeViewModel ToViewModel(this Employee model)
        {
            return new EmployeeViewModel()
            {
                FullName = model.FullName,
                Address = model.Address,
                Id = model.Id.ToString(),
                PhoneNumber = model.PhoneNumber,
                PositionId = model.PositionId
            };
        }

        public static Employee ToDomainModel(this EmployeeViewModel model)
        {
            return new Employee()
            {
                FullName = model.FullName,
                Address = model.Address,
                Id = new Guid(model.Id),
                PhoneNumber = model.PhoneNumber,
                PositionId = model.PositionId
            };
        }
        public static Employee ToCreateDomainModel(this EmployeeViewModel model)
        {
            return new Employee()
            {
                FullName = model.FullName,
                Address = model.Address,
                Id = Guid.NewGuid(),
                PhoneNumber = model.PhoneNumber,
                PositionId = model.PositionId,
                CreatedOn = DateTime.Now,

            };
        }
    }
}
