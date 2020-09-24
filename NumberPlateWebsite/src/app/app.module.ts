import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { FrontComponent } from './front/front.component';
import { NumberplateInformationComponent } from './numberplate-information/numberplate-information.component';
import { AgmCoreModule } from '@agm/core';

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    FrontComponent,
    NumberplateInformationComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyDh4YQ0lsnGxVjgFpP_ny7idDxw66bhQgE'
    })
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
