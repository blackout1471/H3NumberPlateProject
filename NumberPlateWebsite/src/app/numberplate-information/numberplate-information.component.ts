import { Component, OnInit } from '@angular/core';
import { NumberplateModel } from '../models/NumberplateModel';
import { NumberPlateLocationApiService } from '../number-plate-location-api.service';

@Component({
  selector: 'app-numberplate-information',
  templateUrl: './numberplate-information.component.html',
  styleUrls: ['./numberplate-information.component.css']
})
export class NumberplateInformationComponent implements OnInit {

  lat = 51.678418;
  lng = 7.809007;

  numberPlate: NumberplateModel;
  apiService: NumberPlateLocationApiService;

  constructor(private service: NumberPlateLocationApiService)
  {
    this.apiService = service;
  }

  ngOnInit(): void {
    this.numberPlate = new NumberplateModel(new Date(), "Hello");
    this.apiService.GetNumberPlate();
  }

}
