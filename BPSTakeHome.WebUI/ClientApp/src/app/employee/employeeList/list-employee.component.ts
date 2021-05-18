import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/services/Employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './list-employee.component.html',
})
export class EmployeeListComponent implements OnInit {

  employees: any;
  currentEmployee = null;
  currentIndex = -1;
  title = '';
  empPositions: any;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.retrieveEmployee();
    this.retrieveEmpPositions();
  }

  retrieveEmpPositions() {

    this.employeeService.getPositions()
      .subscribe(
        data => {
          this.empPositions = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });

  }

  retrieveEmployee() {
    this.employeeService.getAll()
      .subscribe(
        data => {
          this.employees = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  refreshList() {
    this.retrieveEmployee();
    this.currentEmployee = null;
    this.currentIndex = -1;
  }

  setActiveEmployee(employee, index) {
    this.currentEmployee = employee;
    this.currentIndex = index;
  }

  getEmployeePosition(employeeIndex) {

    if (employeeIndex === 0)
      return;
    var result =  this.empPositions.find( e => e.id == employeeIndex );
    return result.positionName;
  }

  delete(employee, i) {
    this.employeeService.delete(employee.id)
    .subscribe(
      data => {
        this.employees = this.employees.filter(emp => emp.id != employee.id);
      },
      error => {
        console.log(error);
      });
  }
}
