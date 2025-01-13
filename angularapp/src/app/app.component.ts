import { Component } from '@angular/core';




@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent {
  constructor() {  }
  title = 'angularapp';
}

export interface UrlShortener {
  id: string;
  fullUrl: string;
  shortUrl: string;
  createdDate: string;
  userId: string;
}

export interface ApiResponseUrl {
  url: UrlShortener[];
}

export interface ApiResponseUser {
  user: User;
}

export interface User {
  id: string;
  login: string;
  password: string;
  role: number;
  shortenerUrls?: UrlShortener[];
}

export interface Auth {
  Login: string;
  Password: string;
}
