import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthComponent } from './components/Auth/auth';
import { InfoComponent } from './components/Inforamation/info';
import { MainComponent } from './components/Main/main';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    AuthComponent,
    InfoComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, FormsModule, AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
