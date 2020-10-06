import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { NumberplateModel } from '../models/NumberplateModel';
import { NumberPlateLocationApiService } from '../number-plate-location-api.service';
import { GeoApiService } from '../geo-api.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-numberplate-information',
  templateUrl: './numberplate-information.component.html',
  styleUrls: ['./numberplate-information.component.css']
})
export class NumberplateInformationComponent implements OnInit {

  // The string holds the latest location name, used in the gui
  latestLocationName: string;

  // The text of the numberplate used in gui
  numberPlateGui: string = "";

  // The latitude used by google maps
  lat: number = 51.678418;

  // The longitude used by google maps
  lng: number = 7.809007;

  // Whether the numberplate exists or not
  numberPlateExists: boolean = false;

  // Models
  numberPlate: NumberplateModel;

  constructor(private service: NumberPlateLocationApiService, 
    private geo: GeoApiService, 
    private route: ActivatedRoute, 
    private titleservice: Title)
  {
    this.numberPlate = new NumberplateModel();
    this.latestLocationName = "";
    this.titleservice.setTitle("Nummer Plade Information");
  }

  // Begin fetching the numberplate tjhat was given in the url
  ngOnInit(): void {
    let plateNumber: string;

    this.route.params.subscribe(params => {
      plateNumber = params['id'];
      this.numberPlate.setNumberplate(plateNumber);
      this.numberPlateGui = this.numberPlate.getNumberplate();

      this.fetchNumberplateData();
    });
  }

  // Fetches the numberplate data given from the id in the url link
  private fetchNumberplateData() {
    this.service.GetNumberPlate(this.numberPlate.getNumberplate())
      .subscribe(
        (res) => {
          this.numberPlate = res;
          this.getNameLocation();
          this.setMapLocation(this.numberPlate.getLatestLocation().getX(), this.numberPlate.getLatestLocation().getY());
          this.numberPlateExists = true;
        },
        (error) => {
          this.numberPlateExists = false;
        }
      );
  }

  // Fetches the name for the location that was fetched
  private getNameLocation() {
    this.geo.GetLocation(this.numberPlate.getLatestLocation().getX(), this.numberPlate.getLatestLocation().getY())
      .subscribe(res => this.latestLocationName = res);
  }

  // Sets the map location in the gui
  private setMapLocation(lat: number, long: number) {
    this.lat = lat;
    this.lng = long;
  }
}
