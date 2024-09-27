import { Component, OnInit } from '@angular/core';
import { Property } from '../../../shared/models/property';
import { PropertyService } from '../../services/property.service';
import { RouterLink } from '@angular/router';
import { LoginService } from '../../../login/services/login.service';
import { LoginResult } from '../../../login/models/login-result';

@Component({
  selector: 'app-list-properties',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './list-properties.component.html',
  styleUrl: './list-properties.component.css'
})
export class ListPropertiesComponent implements OnInit {
  public search: string = '';
  public take: number = 10;
  public skip: number = 0;
  public properties: Property[] = [];
  public hasError: boolean = false;
  public errorMessage?: string;
  public session: LoginResult | null = null;

  constructor(private propertyService: PropertyService, private loginService: LoginService) { }

  ngOnInit(): void {
    this.propertyService
      .getPaginated(this.search, this.skip, this.take)
      .subscribe(result => {
        this.properties = result.data;
      });

    this.session = this.loginService
      .getSession();
  }

  delete(id: string) {
    this.propertyService
      .delete(id)
      .subscribe(result => {
        if (result.ok) {
          this.properties = this.properties.filter(property => property.id != id);
          this.hasError = false;
        } else {
          this.hasError = true;
          this.errorMessage = result.error;
        }
      });
  }
}
