import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { ListedSale } from '../../models/listed-sales';
import { SaleService } from '../../services/sale.service';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-list-sales',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './list-sales.component.html',
  styleUrl: './list-sales.component.css'
})
export class ListSalesComponent implements OnInit {
  public take: number = environment.DEFAULT_PAGE_SIZE;
  public skip: number = 0;
  public sales: ListedSale[] = [];

  constructor(private saleService: SaleService) { }

  ngOnInit(): void {
    this.saleService
      .getSales(this.skip, this.take)
      .subscribe(result => {
        this.sales = result.data;
      });
  }

  delete(id: string) {
    this.saleService
    .deleteSale(id)
    .subscribe(_ => {
      this.sales = this.sales.filter(sale => sale.id != id);
    });
  }
}
