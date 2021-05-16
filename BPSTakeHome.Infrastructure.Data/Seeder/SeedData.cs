using BPSTakeHome.Domain.Models;
using BPSTakeHome.Infrastructure.Data.Context;
using System;
using System.ComponentModel;
using System.Linq;

namespace BPSTakeHome.Infrastructure.Data.Seeder
{
    public class SeedData
    {
        public enum Positions
        {
            [Description("Project Manager")]
            ProjectManager = 1,
            [Description("Production Manager")]
            ProductionManager = 2,
            [Description("General Manager")]
            GeneralManager = 3,
            [Description("HR Director")]
            HRDirector = 4,
            [Description("Senior Editor")]
            SeniorEditor = 5,
            [Description("Editor")]
            Editor = 6
        }
        public static void RunSeeder(EmployeeDBContext context, IServiceProvider sericeProvider)
        {
            try
            {
                context.Database.EnsureCreated();
                if (!context.EmployeePosition.Any())
                {
                    context.EmployeePosition.Add(entity: new EmployeePosition() { PositionName = Positions.ProjectManager.ToString() });
                    context.EmployeePosition.Add(entity: new EmployeePosition() { PositionName = Positions.ProductionManager.ToString() });
                    context.EmployeePosition.Add(entity: new EmployeePosition() { PositionName = Positions.GeneralManager.ToString() });
                    context.EmployeePosition.Add(entity: new EmployeePosition() { PositionName = Positions.HRDirector.ToString() });
                    context.EmployeePosition.Add(entity: new EmployeePosition() { PositionName = Positions.SeniorEditor.ToString() });
                    context.EmployeePosition.Add(entity: new EmployeePosition() { PositionName = Positions.Editor.ToString() });

                    context.SaveChanges();
                }
                var result = context.Employees;
                if (!context.Employees.Any())
                {
                    context.Employees.Add(entity: new Employee() { Id = Guid.NewGuid(), FullName = "John Doe", Address = "", PhoneNumber = "", PositionId = (int)Positions.ProjectManager, CreatedOn = DateTime.Now });
                    context.Employees.Add(entity: new Employee() { Id = Guid.NewGuid(), FullName = "Roger Flynn", Address = "", PhoneNumber = "", PositionId = (int)Positions.ProductionManager, CreatedOn = DateTime.Now });
                    context.Employees.Add(entity: new Employee() { Id = Guid.NewGuid(), FullName = "Alex Virasamy", Address = "", PhoneNumber = "", PositionId = (int)Positions.GeneralManager, CreatedOn = DateTime.Now });
                    context.Employees.Add(entity: new Employee() { Id = Guid.NewGuid(), FullName = "Kyle Pitt", Address = "", PhoneNumber = "", PositionId = (int)Positions.HRDirector, CreatedOn = DateTime.Now });
                    context.Employees.Add(entity: new Employee() { Id = Guid.NewGuid(), FullName = "Elizabeth James", Address = "", PhoneNumber = "", PositionId = (int)Positions.SeniorEditor, CreatedOn = DateTime.Now });
                    context.Employees.Add(entity: new Employee() { Id = Guid.NewGuid(), FullName = "Shelly Bell", Address = "", PhoneNumber = "", PositionId = (int)Positions.Editor, CreatedOn = DateTime.Now });
                    context.Employees.Add(entity: new Employee() { Id = Guid.NewGuid(), FullName = "Martin Ziberman", Address = "", PhoneNumber = "", PositionId = (int)Positions.Editor, CreatedOn = DateTime.Now });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

