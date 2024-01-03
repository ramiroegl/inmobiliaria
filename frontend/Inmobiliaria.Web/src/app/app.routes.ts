import { Routes } from '@angular/router';
import { CustomersComponent } from './customers/pages/customers.component';
import { SalesComponent } from './sales/sales.component';
import { HomeComponent } from './shared/pages/home/home.component';
import { UsersComponent } from './users/users.component';
import { LoginComponent } from './login/login.component';
import { NotfoundComponent } from './shared/pages/notfound/notfound.component';
import { NewCustomerComponent } from './customers/pages/new-customer/new-customer.component';

export const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'customers', component: CustomersComponent },
    { path: 'customers/new', component: NewCustomerComponent },
    { path: 'login', component: LoginComponent },
    { path: 'sales', component: SalesComponent },
    { path: 'users', component: UsersComponent },
    { path: '**', component: NotfoundComponent }
];
