import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AssuntoComponent } from './assunto/assunto.component';
import { AssuntoShowComponent } from './assunto/assunto-show/assunto-show.component';

@NgModule({
  declarations: [
    AppComponent,
    AssuntoComponent,
    AssuntoShowComponent
  ],
  imports: [
    BrowserModule, HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
