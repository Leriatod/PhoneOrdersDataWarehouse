import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PhonesService {

  constructor(private http: HttpClient) { }


  async getAll() : Promise<Object> {
    return await this.http.get("/api/phones").toPromise();
  }

  async reloadPhones() : Promise<Object> {
    return await this.http.post("/api/reload-phones", {}).toPromise();
  }


}
