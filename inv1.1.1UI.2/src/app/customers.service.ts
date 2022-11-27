import { HttpClient } from '@angular/common/http';
import {  Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customers } from './customers/customers';
import { Inventory } from './inventory/inventory';
import { Purchases } from './purchases/purchases';
import { Sales } from './sales/sales';
import { Suppliers } from './suppliers/suppliers';
import { Transactions } from './transactions/transactions';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {
  private apiServerUrl = 'https://localhost:44354/api';

  constructor(private http: HttpClient) {}
  
  //customers//
  public getCustomers(): Observable<any> {
    return this.http.get<any>(`${this.apiServerUrl}/customers`)
  }
  public createCustomers(data:Customers): Observable<any> {
    return this.http.post<any>(`${this.apiServerUrl}/customers`,data)
  }
  public updateCustomers(data:Customers): Observable<any> {
    return this.http.put<any>(`${this.apiServerUrl}/customers`,data)
  }
  public DeleteCustomers(data:any): Observable<any> {
    return this.http.delete<any>(`${this.apiServerUrl}/customers/`+data)
  }

  //transactions//
  public getTransactions(): Observable<any> {
    return this.http.get<any>(`${this.apiServerUrl}/transactions`)
  }
  public createTransactions(data:Transactions): Observable<any> {
    return this.http.post<any>(`${this.apiServerUrl}/transactions`,data)
  }
  public updateTransactions(data:Transactions): Observable<any> {
    return this.http.put<any>(`${this.apiServerUrl}/transactions`,data)
  }
  public DeleteTransactions(data:any): Observable<any> {
    return this.http.delete<any>(`${this.apiServerUrl}/transactions/`+data)
  }

  //inventory//
  public getInventory(): Observable<any> {
    return this.http.get<any>(`${this.apiServerUrl}/product`)
  }
  public createInventory(data:Inventory): Observable<any> {
    return this.http.post<any>(`${this.apiServerUrl}/product`,data)
  }
  public updateInventory(data:Inventory): Observable<any> {
    return this.http.put<any>(`${this.apiServerUrl}/product`,data)
  }
  public DeleteInventory(data:any): Observable<any> {
    return this.http.delete<any>(`${this.apiServerUrl}/product/`+data)
  }

  //purchases//
  public getPurchases(): Observable<any> {
    return this.http.get<any>(`${this.apiServerUrl}/purchases`)
  }
  public createPurchases(data:Purchases): Observable<any> {
    return this.http.post<any>(`${this.apiServerUrl}/purchases`,data)
  }
  public updatePurchases(data:Purchases): Observable<any> {
    return this.http.put<any>(`${this.apiServerUrl}/purchases`,data)
  }
  public DeletePurchases(data:any): Observable<any> {
    return this.http.delete<any>(`${this.apiServerUrl}/purchases/`+data)
  }

  //suppliers//
  public getSuppliers(): Observable<any> {
    return this.http.get<any>(`${this.apiServerUrl}/suppliers`)
  }
  public createSuppliers(data:Suppliers): Observable<any> {
    return this.http.post<any>(`${this.apiServerUrl}/suppliers`,data)
  }
  public updateSuppliers(data:Suppliers): Observable<any> {
    return this.http.put<any>(`${this.apiServerUrl}/suppliers`,data)
  }
  public DeleteSuppliers(data:any): Observable<any> {
    return this.http.delete<any>(`${this.apiServerUrl}/suppliers/`+data)
  }

  //sales//
  public getSales(): Observable<any> {
    return this.http.get<any>(`${this.apiServerUrl}/sales`)
  }
  public createSales(data:Sales): Observable<any> {
    return this.http.post<any>(`${this.apiServerUrl}/sales`,data)
  }
  public updateSales(data:Sales): Observable<any> {
    return this.http.put<any>(`${this.apiServerUrl}/sales`,data)
  }
  public DeleteSales(data:any): Observable<any> {
    return this.http.delete<any>(`${this.apiServerUrl}/sales/`+data)
  }
}
