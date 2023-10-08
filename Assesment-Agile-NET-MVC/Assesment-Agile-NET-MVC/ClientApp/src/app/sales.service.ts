import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SalesService {

  private apiUrl = 'https://localhost:7033/Sales';

  constructor(private http: HttpClient) { }

  getAllCategories(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/GetCategories`);
  }

  getProductsByCategory(categoryId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/GetProductsByCategory?id=${categoryId}`);
  }

  getBrandsByProduct(productId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/GetBrandsByProduct?id=${productId}`);
  }

  getSalesDataByBrand(brandId: number) {
    return this.http.get<any[]>(`${this.apiUrl}/GetSalesData?brandId=${brandId}`);
  }

}
