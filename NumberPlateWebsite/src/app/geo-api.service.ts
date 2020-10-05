import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

// Service class for getting the name of the of a location
// From the x and y location or longitude and langitude
export class GeoApiService {

  apiUrl = "http://open.mapquestapi.com/geocoding/v1/reverse?key=m4Z4gFHItGwP9FW5IuHCfeMpcVWUdWq5&";

  // Extracts the data from the json data, from api call
  private extractLocation(res: any[]): string {
    let location = "";
    location = res['results'][0]['locations'][0]['street'];

    if (location == "")
      location = "Unknown";
    return location;
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

  constructor(private client: HttpClient) { }

  // Gets name of a location from given x and y
  public GetLocation(x: number, y: number) {
    return this.client.get(`${this.apiUrl}location=${x},${y}`).
      pipe(
        map(this.extractLocation),
        catchError(this.handleError)
      );
  }
}
