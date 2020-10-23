import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PhonesService {

  constructor(private http: HttpClient) { }




  async reloadPhones() : Promise<Object> {
    return await this.http.post("/api/reload-phones", {}).toPromise();
  }


}
