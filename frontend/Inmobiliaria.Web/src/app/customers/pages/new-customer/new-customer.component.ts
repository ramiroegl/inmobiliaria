import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-customer',
  standalone: true,
  imports: [],
  templateUrl: './new-customer.component.html',
  styleUrl: './new-customer.component.css'
})
export class NewCustomerComponent {
  constructor(private router: Router) {
  }

  refresh(): void {
    this.router.navigate(['/customers'])
  }
}
