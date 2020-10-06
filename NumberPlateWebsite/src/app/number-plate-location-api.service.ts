import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NumberplateModel } from './models/NumberplateModel';
import { NumberplateLocationModel } from './models/NumberplateLocationsModel';
import { map, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

// Class for calling an extern api to get stolen numberplates
export class NumberPlateLocationApiService {

  // The base url of the api
  apiUrl: string = "http://projektdns.westeurope.cloudapp.azure.com:81/api";

  constructor(private client: HttpClient) { }

  // Extracts the numberplate data from json object
  private extractNumberplateData(res: any[]): NumberplateModel {
    let model = new NumberplateModel();
    res.forEach(curModel => {
      let location = new NumberplateLocationModel();

      location.setX(curModel['xLocation']);
      location.setY(curModel['yLocation']);
      location.setSeen(new Date(curModel['timeSpotted']));

      model.addLocation(location);
    });

    return model;
  }

  // Handles the error thrown
  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error("An error occurred:", error.error.message);
    } else {
      // The backend returned an unsuccessful response code. The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` + `body was: ${error.error}`
      );
    }
    // return an observable with a user-facing error message
    return throwError(error);
  }

  // Gets the numberplate, given from a string of text
  public GetNumberPlate(numberplate: string): Observable<any> {
    return this.client.get(`${this.apiUrl}/numberplatelocations/${numberplate}`).
      pipe(
        map(this.extractNumberplateData),
        catchError(this.handleError)
    );
  }
}
