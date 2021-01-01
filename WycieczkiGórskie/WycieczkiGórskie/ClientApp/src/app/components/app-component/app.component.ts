import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'E-Commerce';

  constructor(private authService:AuthService)
  {

  }
  private tokenExpired(token: string) {
    const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
    return (Math.floor((new Date).getTime() / 1000)) >= expiry;
  }
  
  ngOnInit() {
    if(localStorage.getItem("JWT_TOKEN"))
    {

    
    if (this.tokenExpired(localStorage.getItem("JWT_TOKEN")))
    {
      this.authService.refreshToken().subscribe();
    }
    else
    {
     
    }
  }
  }
}
