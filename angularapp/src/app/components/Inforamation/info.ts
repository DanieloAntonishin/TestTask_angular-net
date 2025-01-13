import { Component, OnInit } from '@angular/core';
import { Auth, UrlShortener, User } from '../../app.component';
import { UrlService, UserService } from '../../app.service';

@Component({
  selector: 'info',
  templateUrl: './info.html',
  styleUrls: ['./info.css']
})
export class InfoComponent implements OnInit {
  public user: User | undefined;
  private data: string | null =  localStorage.getItem("currentUrl");
  public url: UrlShortener = JSON.parse(this.data!);
  constructor(private urlService: UrlService, private userService: UserService) {
    this.userService.getUserById(this.url.userId).subscribe((data) => {
      this.user = data.user 
    },
      (error) => console.error('Error loading User::', error)
    );
  }
  ngOnInit(): void {
  }

}
