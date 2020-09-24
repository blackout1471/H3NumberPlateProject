import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NumberPlateLocationApiService {

  apiUrl: string = "http://projektdns.westeurope.cloudapp.azure.com/api";

  constructor(private client: HttpClient)
  {
    
  }

  public GetNumberPlate() {
    this.client.get(`${this.apiUrl}/numberplatelocations/ABCDE`).subscribe((res => {
      console.log(res);
    }));
  }
}
