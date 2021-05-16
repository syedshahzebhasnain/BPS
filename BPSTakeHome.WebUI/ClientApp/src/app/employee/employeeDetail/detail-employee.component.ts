import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/services/Employee.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-employee-details',
  templateUrl: './detail-employee.component.html'
})
export class EmployeeDetailsComponent implements OnInit {
  currentEmployee = null;
  message = '';

  constructor(
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.message = '';
    this.getEmployee(this.route.snapshot.paramMap.get('id'));
  }

  getEmployee(id) {
    this.employeeService.get(id)
      .subscribe(
        data => {
          this.currentEmployee = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  updatePublished(status) {
    const data = {
      fullName: this.currentEmployee.fullName,
      address: this.currentEmployee.address,
      phoneNumber: this.currentEmployee.phoneNumber,
      position: this.currentEmployee.position,
      published: status
    };

    this.employeeService.update(this.currentEmployee.id, data)
      .subscribe(
        response => {
          this.currentEmployee.published = status;
          console.log(response);
        },
        error => {
          console.log(error);
        });
  }

  updateEmployee() {
    this.employeeService.update(this.currentEmployee.id, this.currentEmployee)
      .subscribe(
        response => {
          console.log(response);
          this.message = 'The employees details was updated successfully!';
        },
        error => {
          console.log(error);
        });
  }

  deleteEmployee() {
    this.employeeService.delete(this.currentEmployee.id)
      .subscribe(
        response => {
          console.log(response);
          this.router.navigate(['/employee-list']);
        },
        error => {
          console.log(error);
        });
  }
}
