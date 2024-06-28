import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { LoginService } from '../../../login/services/login.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  public isAdmin = false;
  
  constructor(private loginService: LoginService) {
  }

  ngOnInit(): void {
    this.isAdmin = this.loginService.getSession()?.user.role === 'Admin';
  }
}
