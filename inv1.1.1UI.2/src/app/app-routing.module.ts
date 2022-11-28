import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { AuthComponent } from '../../auth/auth.component';
import { CustomersComponent } from './customers/customers.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { InventoryComponent } from './inventory/inventory.component';
import { PurchasesComponent } from './purchases/purchases.component';
import { SalesComponent } from './sales/sales.component';
import { SuppliersComponent } from './suppliers/suppliers.component';
import { TransactionsComponent } from './transactions/transactions.component';

const routes: Routes = [
  { path: '', component: AuthComponent },
  { path: 'auth', component: AuthComponent },
  { path: 'dash', component: DashboardComponent,
  children:[
    {
     path : 'customers',
     component: CustomersComponent,
   },
   {
    path : 'transactions',
    component: TransactionsComponent,
  },
   {
    path : 'inventory',
    component: InventoryComponent,
  },
  {
    path : 'purchases',
    component: PurchasesComponent,
  },
  {
    path : 'sales',
    component: SalesComponent,
  },
  {
   path : 'suppliers',
   component: SuppliersComponent,
 }] },
 { path: 'About', component: AboutComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
