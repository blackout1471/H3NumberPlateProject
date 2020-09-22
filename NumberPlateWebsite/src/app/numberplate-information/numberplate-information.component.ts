import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-numberplate-information',
  templateUrl: './numberplate-information.component.html',
  styleUrls: ['./numberplate-information.component.css']
})
export class NumberplateInformationComponent implements OnInit {

  lat = 51.678418;
  lng = 7.809007;

  constructor() { }

  ngOnInit(): void {
  }

}
