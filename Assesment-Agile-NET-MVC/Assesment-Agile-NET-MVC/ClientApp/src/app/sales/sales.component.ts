import { Component, OnInit, Renderer2, ElementRef } from '@angular/core';
import { SalesService } from '../sales.service';

declare var CanvasJS: any;

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

  constructor(private salesService: SalesService, private renderer: Renderer2, private el: ElementRef) { }

  ngOnInit(): void {
    this.addScript();
    this.fetchAllCategories();
    this.renderChart();
  }

  addScript() {
    let script = this.renderer.createElement('script');
    script.type = `text/javascript`;
    script.src = `https://cdn.canvasjs.com/canvasjs.min.js`;
    script.onload = this.loadCallback.bind(this);
    this.renderer.appendChild(this.el.nativeElement, script);
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

  loadCallback() {
    this.renderChart();
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

  renderChart(): void {
    let chart = new CanvasJS.Chart("chartContainer", {
      animationEnabled: true,
      theme: "light2",
      title: {
        text: "Sales By Month for Example"
      },
      axisX: {
        valueFormatString: "MMM"
      },
      data: [{
        type: "line",
        indexLabelFontSize: 16,
        dataPoints: [
          { y: 50, label: "Janeiro" },
          { y: 500, label: "Fevereiro" },
          { y: 300, label: "Março" },
          { y: 25, label: "Abril" }
        ]
      }]
    });
    chart.render();
  }

  onBrandChange() {
    if (this.selectedBrandId !== 0) { 
      const selectedBrandName = this.brands.find(brand => brand.id === this.selectedBrandId).name;
      this.salesService.getSalesDataByBrand(this.selectedBrandId).subscribe(data => {
      this.updateChart(data, selectedBrandName);
      });
    }
  }

  updateChart(data: any[], brandName: string) {

    var dataPoints = [];
    for (var i = 0; i < data.length; i++) {
      dataPoints.push({ y: data[i].amount, label: data[i].month });
    }

    let chart = new CanvasJS.Chart("chartContainer", {
      animationEnabled: true,
      theme: "light2",
      title: {
        text: "Sales By Month for " + brandName
      },
      axisX: {
        valueFormatString: "MMM"
      },
      data: [{
        type: "line",
        indexLabelFontSize: 16,
        dataPoints: dataPoints
      }]
    });
    chart.render();
  }
}
