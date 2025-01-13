import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AppModule } from '../../app.module';
import { UrlService, UserService } from '../../app.service';
import { ChangeDetectorRef } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './main.html',
  styleUrls: ['./main.css']
})


export class MainComponent {
  public urls: UrlShortener[] = [];
  public errorMessage: string = "";
  private data = "";
  public userRole?: number;
  public user?: User | null
  public name: string = "empty";
  currentUrl: UrlShortener = { id: '3fa85f64-5717-4562-b3fc-2c963f66afa9', fullUrl: 'string', shortUrl: 'string', createdDate: "2025-01-10T18:33:33.066Z", userId: '3fa85f64-5717-4562-b3fc-2c963f66afa6' };
  currentUser: Auth = { Login: '', Password: '' };
  constructor(private http: HttpClient, private urlService: UrlService) {
    console.log(this.user)
  }
  loadUrls(): void {
    this.loadUserInfo();
    this.urlService.getUrls().subscribe({
      next: (data: ApiResponseUrl) => (this.urls = data.url),
      error: (err: any) => console.error('Error loading URLs:', err),
    });
  }
  AddUrl(): void {
    if (this.user == null) {
      this.errorMessage = "Unauthorized user"
    }
    else {
      this.currentUrl.userId = this.user.id;
      this.urlService.createUrl(this.currentUrl).subscribe({
        next: (newUrl) => {
          this.urls.push(newUrl); 
          this.loadUrls()
        },
        error: (err) => console.error('Error adding URL:', err),
      });
    }
  }
  deleteUrl(id: string): void {
    this.urlService.deleteUrl(id).subscribe({
      next: () => {
        this.urls = this.urls.filter((url) => url.id !== id); 
      },
      error: (err) => console.error('Error deleting URL:', err),
    });
  }
  deleteAllUrl(): void {
    this.urlService.deleteAllUrl().subscribe({
      next: () => {
        this.urls = []; //delete list of URLs
      },
      error: (err) => console.error('Error deleting All URL:', err),
    });
  }

  getUrl(url: UrlShortener): void {
    localStorage.setItem("currentUrl", JSON.stringify(url));
  }

  loadUserInfo(): void {
    this.data = localStorage.getItem("user") ?? "";
    if (this.data != null) {
      this.user = this.data ? JSON.parse(this.data) : null;
      this.userRole = this.user?.role;
    }
  }

  checkUserPolicy(id: string): boolean {
    if (this.user == null) {
      this.errorMessage = "Unauthorized user";
      return false;
    }
    if (this.userRole == 1) {
      return true;
    }
    if (this.user.id != id) {
      this.errorMessage = "Access denied";
      return false;
    }
    return true;
    
  }
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
