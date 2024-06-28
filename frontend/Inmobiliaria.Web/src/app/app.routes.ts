import {Routes} from '@angular/router';
import {CustomersComponent} from './customers/pages/list-customers/customers.component';
import {HomeComponent} from './shared/pages/home/home.component';
import {UsersComponent} from './users/pages/list-users/users.component';
import {LoginComponent} from './login/pages/login.component';
import {NotfoundComponent} from './shared/pages/notfound/notfound.component';
import {NewCustomerComponent} from './customers/pages/new-customer/new-customer.component';
import {EditCustomerComponent} from './customers/pages/edit-customer/edit-customer.component';
import {NewSaleComponent} from './sales/pages/new-sale/new-sale.component';
import {ListSalesComponent} from './sales/pages/list-sales/list-sales.component';
import {EditSaleComponent} from './sales/pages/edit-sale/edit-sale.component';
import {AuthGuard} from "./login/services/auth-guard";
import { ListPropertiesComponent } from './properties/pages/list-properties/list-properties.component';
import { NewUserComponent } from './users/pages/new-user/new-user.component';

export const routes: Routes = [
    {path: '', redirectTo: '/home', pathMatch: 'full'},
    {path: 'home', component: HomeComponent, canActivate: [AuthGuard]},
    {path: 'customers', component: CustomersComponent, canActivate: [AuthGuard]},
    {path: 'customers/:id/detail', component: EditCustomerComponent, canActivate: [AuthGuard]},
    {path: 'customers/new', component: NewCustomerComponent, canActivate: [AuthGuard]},
    {path: 'login', component: LoginComponent},
    {path: 'sales', component: ListSalesComponent, canActivate: [AuthGuard]},
    {path: 'sales/new', component: NewSaleComponent, canActivate: [AuthGuard]},
    {path: 'sales/:id/detail', component: EditSaleComponent, canActivate: [AuthGuard]},
    {path: 'users', component: UsersComponent, canActivate: [AuthGuard]},
    {path: 'users/new', component: NewUserComponent, canActivate: [AuthGuard]},
    {path: 'properties', component: ListPropertiesComponent, canActivate: [AuthGuard]},
    {path: '**', component: NotfoundComponent, canActivate: [AuthGuard]}
];
