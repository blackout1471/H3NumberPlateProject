import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-front',
  templateUrl: './front.component.html',
  styleUrls: ['./front.component.css']
})
export class FrontComponent implements OnInit {

  constructor(private titleService: Title)
  {
    this.titleService.setTitle("Forside");
  }

  ngOnInit(): void {
  }

}
