import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const baseUrl = 'http://localhost:8080/api/tutorials';
var controllerName = "employee";
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }

  getAll() {
   this.http.get(baseUrl + controllerName).subscribe(result => {
     return result
    }, error => console.error(error));;
  }

  get(id) {
    this.http.get(`${baseUrl}/${controllerName}/${id}`).subscribe(result => {
      return result;
    }, error => console.error(error));;
  }

  create(data) {
    this.http.post(baseUrl + controllerName, data).subscribe(result => {
      return result;
    }, error => console.error(error));;
  }

  update(id, data) {
    this.http.put(`${baseUrl}/${controllerName}/${id}`, data).subscribe(result => {
      return result;
    }, error => console.error(error));;
  }

  delete(id) {
    this.http.delete(`${baseUrl}/${controllerName}/${id}`).subscribe(result => {
      return result;
    }, error => console.error(error));;
  }
}
