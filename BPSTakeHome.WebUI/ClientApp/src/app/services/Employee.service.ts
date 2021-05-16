import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


var controllerName = "employee";
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  baseUrl: any;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl
  }

  getAll() {
    return this.http.get(this.baseUrl + controllerName);
  }

  get(id) {

    console.log(this.baseUrl)
    return this.http.get(`${this.baseUrl}${controllerName}/${id}`);
  }

  create(data) {
    return this.http.post(this.baseUrl + controllerName , data);
  }

  update(id, data) {
    return this.http.put(`${this.baseUrl}${controllerName}/${id}`, data);
  }

  delete(id) {
    return this.http.delete(`${this.baseUrl}${controllerName}/${id}`);
  }

  getPositions() {
    return this.http.get(this.baseUrl + controllerName + '/positions');

  }
}
