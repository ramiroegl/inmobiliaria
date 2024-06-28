import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { LoginService } from '../../../login/services/login.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    RouterLink,
    RouterLinkActive
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {
  public isAdmin = false;
  
  constructor(private loginService: LoginService) {
  }

  ngOnInit(): void {
    this.isAdmin = this.loginService.getSession()?.user.role === 'Admin';
  }
}