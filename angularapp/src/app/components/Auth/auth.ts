import { Component, OnInit } from '@angular/core';
import { ApiResponseUser, Auth, User } from '../../app.component';
import { UserService } from '../../app.service';
import { Router } from '@angular/router';

@Component({
  selector: 'auth',
  templateUrl: './auth.html',
  styleUrls: ['./auth.css']
})
export class AuthComponent implements OnInit {
  public user?: User;
  public name: string = "empty";
  currentUser: Auth = { Login: '', Password: '' };
  constructor(private userService: UserService, private router: Router) { }

  Authentication(): void {
    this.userService.authentication(this.currentUser).subscribe({
      next: (auth: ApiResponseUser) => {
        this.user = auth.user; // add new URL 
        localStorage.setItem("user", JSON.stringify(this.user));
        this.router.navigate(['/']);
      },
      error: (err: any) => console.error('Error Authentication:', err),
    });
    
  }
  ngOnInit(): void {
  }

}
