import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import { UsersComponent } from './users/users.component';
import { SalesComponent } from './sales/components/sales.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { NotfoundComponent } from './shared/pages/notfound/notfound.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    UsersComponent,
    SalesComponent,
    HeaderComponent,
    NotfoundComponent,
    CommonModule,
    RouterOutlet,
    RouterLink, 
    RouterLinkActive
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Inmobiliaria.Web';
}
