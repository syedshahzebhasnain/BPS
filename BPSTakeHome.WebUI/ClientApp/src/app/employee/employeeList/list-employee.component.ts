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

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.retrieveEmployee();
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
}
