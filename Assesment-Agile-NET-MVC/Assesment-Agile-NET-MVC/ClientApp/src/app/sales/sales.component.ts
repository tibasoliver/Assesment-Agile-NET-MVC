import { Component, OnInit } from '@angular/core';
import { SalesService } from '../sales.service';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit {

  categories: any[] = [];
  products: any[] = [];
  brands: any[] = [];
  selectedCategoryId: number = 0;
  selectedProductId: number = 0;
  selectedBrandId: number = 0;

  constructor(private salesService: SalesService) { }

  ngOnInit(): void {

    this.fetchAllCategories();
  }

  fetchAllCategories() {
    this.salesService.getAllCategories().subscribe(data => {
      console.log(data);
      this.categories = data.map(item => ({
        id: item.value,
        name: item.text
      }));
    });
  }

  loadCategories() {
  }

  onCategoryChange() {
    if (this.selectedCategoryId !== 0) {
      this.salesService.getProductsByCategory(this.selectedCategoryId).subscribe(data => {
        this.products = data.map(item => ({
          id: item.value,
          name: item.text
        }));
        this.brands = [];
        this.selectedBrandId = 0;
        this.selectedProductId = 0;
      });
    } else {
      // Limpe ambas as listas se a categoria não estiver selecionada
      //this.products = [];
      //this.brands = [];
      //this.selectedProductId = 0;
      //this.selectedBrandId = 0;
    }
  }

  onProductChange() {
    if (this.selectedProductId !== 0) {
      this.salesService.getBrandsByProduct(this.selectedProductId).subscribe(data => {
        this.brands = data.map(item => ({
          id: item.value,
          name: item.text
        }));
        this.selectedBrandId = 0;
      });
    } else {
      this.brands = [];
      this.selectedBrandId = 0;
    }
  }

  onBrandChange() {

  }
}
