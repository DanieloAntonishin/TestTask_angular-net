import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponseUrl, ApiResponseUser, Auth, UrlShortener, User } from './app.component';

@Injectable({
  providedIn: 'root',
})

export class UserService {

  constructor(private http: HttpClient) { }

  // GET: get user by ID
  getUserById(id: string): Observable<ApiResponseUser> {
    return this.http.get<ApiResponseUser>(`/user/getById?userId=${id}`);
  }

  // POST: authentication
  authentication(auth: Auth): Observable<ApiResponseUser> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<ApiResponseUser>(`/user/authentication`, auth, { headers });
  }

}
@Injectable({
  providedIn: 'root',
})

export class UrlService {

  constructor(private http: HttpClient) { }

  // GET: list of URLs
  getUrls(): Observable<ApiResponseUrl> {
    return this.http.get<ApiResponseUrl>('/urlshortener')
  }
  
  // GET: URL by ID
  getUrlById(id: string): Observable<UrlShortener> {
    return this.http.get<UrlShortener>(`/urlshortener/${id}`);
  }

  // POST
  createUrl(url: UrlShortener): Observable<UrlShortener> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<UrlShortener>(`/urlshortener`, url, { headers });
  }

  // PUT
  updateUrl(id: number, url: UrlShortener): Observable<UrlShortener> {
    return this.http.put<UrlShortener>(`/urlshortener/${id}`, url);
  }

  // DELETE: URL by ID
  deleteUrl(id: string): Observable<void> {
    return this.http.delete<void>(`/urlshortener?sUrlId=${id}`);
  }
  // DELETE: all URLs
  deleteAllUrl(): Observable<void> {
    return this.http.delete<void>(`/urlshortener/all`);
  }
}

