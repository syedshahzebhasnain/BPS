import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const baseUrl = 'http://localhost:8080/api/tutorials';
var controllerName = "employee";
@Injectable({
  providedIn: 'root'
})
export class TutorialService {

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }

  getAll() {
    return this.http.get(baseUrl + controllerName);
  }

  get(id) {
    return this.http.get(`${baseUrl}/${controllerName}/${id}`);
  }

  create(data) {
    return this.http.post(baseUrl + controllerName , data);
  }

  update(id, data) {
    return this.http.put(`${baseUrl}/${controllerName}/${id}`, data);
  }

  delete(id) {
    return this.http.delete(`${baseUrl}/${controllerName}/${id}`);
  }
}
