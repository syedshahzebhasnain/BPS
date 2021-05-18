import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/services/Employee.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html'
})

export class AddEmployeeComponent implements OnInit {
  employee = {
    id:'',
    fullName: '',
    address: '',
    phoneNumber: '',
    positionId : 0,
    published: false
  };
  submitted = false;

  public empPositions: any;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
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
  saveEmployee(): void {
    const data = {
      id: "ABC",
      fullName: this.employee.fullName,
      address: this.employee.address,
      phoneNumber: this.employee.phoneNumber,
      positionId: Number(this.employee.positionId)
    };

    this.employeeService.create(data).subscribe(
        response => {
          console.log(response);
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }

  newEmployee(): void {
    this.submitted = false;
    this.employee = {
      id:'',
      fullName: '',
      address: '',
      phoneNumber: '',
      positionId:0,
      published: false
    };
  }

}
