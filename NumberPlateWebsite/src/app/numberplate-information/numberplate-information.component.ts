import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { NumberplateModel } from '../models/NumberplateModel';
import { NumberPlateLocationApiService } from '../number-plate-location-api.service';
import { GeoApiService } from '../geo-api.service';

@Component({
  selector: 'app-numberplate-information',
  templateUrl: './numberplate-information.component.html',
  styleUrls: ['./numberplate-information.component.css']
})
export class NumberplateInformationComponent implements OnInit {

  latestLocationName: string;
  numberPlateGui: string = "";
  lat: number = 51.678418;
  lng: number = 7.809007;
  numberPlateExists: boolean = false;

  // Models
  numberPlate: NumberplateModel;

  constructor(private service: NumberPlateLocationApiService, private geo: GeoApiService, private route: ActivatedRoute)
  {
    this.numberPlate = new NumberplateModel();
    this.latestLocationName = "";
  }

  ngOnInit(): void {
    let plateNumber: string;
    this.route.params.subscribe(params => {
      plateNumber = params['id'];
      this.numberPlate.setNumberplate(plateNumber);
      this.numberPlateGui = this.numberPlate.getNumberplate();

      this.fetchNumberplateData();
    });
  }

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

  private getNameLocation() {
    this.geo.GetLocation(this.numberPlate.getLatestLocation().getX(), this.numberPlate.getLatestLocation().getY())
      .subscribe(res => this.latestLocationName = res);
  }

  private setMapLocation(lat: number, long: number) {
    this.lat = lat;
    this.lng = long;
  }
}
