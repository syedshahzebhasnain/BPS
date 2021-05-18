import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/services/Employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './list-employee.component.html',
  styleUrls: ['./list-employee.component.css']
})
export class EmployeeListComponent implements OnInit {

  employees: any;
  currentEmployee = null;
  currentAction = "Add";
  currentIndex = -1;
  title = '';
  empPositions: any;

  employee = {
    id: '',
    fullName: '',
    address: '',
    phoneNumber: '',
    positionId: 0,
    published: false
  };

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
    var result = this.empPositions.find(e => e.id == employeeIndex);
    return result.positionName;
  }

  delete(employee, i) {
    this.employeeService.delete(employee.id)
      .subscribe(
        data => {
          alert("Selected employee deleted");
          this.employees = this.employees.filter(emp => emp.id != employee.id);
        },
        error => {
          alert("Failure in delete operation");
          console.log(error);
        });
  }

  addEmployee() {
    this.currentEmployee = null;
    this.currentAction = 'Add';
    this.employee = {
      id: '',
      fullName: '',
      address: '',
      phoneNumber: '',
      positionId: 0,
      published: false
    }
  }

  saveEmployee(): void {
    const data = {
      id: "",
      fullName: this.employee.fullName,
      address: this.employee.address,
      phoneNumber: this.employee.phoneNumber,
      positionId: Number(this.employee.positionId)
    };

    console.log(this.employee.positionId)

    this.employeeService.create(data).subscribe(
      response => {
        console.log(response);
        this.employee = {
          id: '',
          fullName: '',
          address: '',
          phoneNumber: '',
          positionId: 0,
          published: false
        }
        alert("Add Successfull");
        this.retrieveEmployee();
      },
      error => {
        alert("Add operation failed");
        console.log(error);
      });
  }

  editEmployee(employee, index) {

    this.currentAction = 'Update';

    this.employee = employee;
    this.currentEmployee = null;

  }

  updateEmployee(employee) {

    var employeeUpdate = {
      id: employee.id,
      fullName: employee.fullName,
      address: employee.address,
      phoneNumber: employee.phoneNumber,
      positionId: Number(employee.positionId)
    };
    this.employeeService.update(employeeUpdate.id, employeeUpdate)
      .subscribe(
        response => {
          alert("Update Successfull");
          this.currentAction = 'Add'
          this.currentEmployee = employee;
          console.log(response);
        },
        error => {
          alert("Update operation failed");
          console.log(error);
        });
  }

  cancelUpdate(employee) {
    this.currentAction = 'Add'
    this.currentEmployee = employee;
  }

  cancelAdd() {
    this.currentAction = 'Add'
    this.retrieveEmployee();

  }
}
