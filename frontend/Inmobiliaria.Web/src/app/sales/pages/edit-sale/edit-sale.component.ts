import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-edit-sale',
  standalone: true,
  imports: [],
  templateUrl: './edit-sale.component.html',
  styleUrl: './edit-sale.component.css'
})
export class EditSaleComponent {
  @Input('id') id: string = '';

}
