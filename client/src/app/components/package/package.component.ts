import {Component, OnInit} from '@angular/core';
import {PageEvent} from '@angular/material';
import {CommmentsService} from '../../services/commments.service';
import {PackageGet} from '../../models/PackageGet';
import {PackageService} from '../../services/package.service';
import {Destination} from '../../models/Destination';

@Component({
  selector: 'app-package',
  templateUrl: './package.component.html',
  styleUrls: ['./package.component.scss']
})
export class PackageComponent implements OnInit {
  destinations: Destination [] = [];
  expeditor: any;
  length: number;
  pageSize = 5;
  pageSizeOptions: number[] = [5, 10, 25, 100];

  public packages: PackageGet [] = [];
  public displayedColumns: string[] = ['id', 'CountryDestination', 'CountryExpedition', 'Sender', 'Receiver', 'Cost', 'Adress', 'Tracking'];
  public displayedColumns1: string[] = ['id', 'name', 'cost'];
  pageEvent: PageEvent;
  activePageDataChunk = [];

  constructor(private packagesService: PackageService) {
    // this.getAllExpenses(null, null, null);
    // this.activePageDataChunk = this.expenses.slice(0, this.pageSize);
    // console.log(this.activePageDataChunk);
    // console.log(this.expenses);
  }

  ngOnInit() {
    this.getAllPackages();


  }

  setPageSizeOptions(setPageSizeOptionsInput: string) {
    this.pageSizeOptions = setPageSizeOptionsInput.split(',').map(str => +str);
  }

  onPageChanged(e) {
    const firstCut = e.pageIndex * e.pageSize;
    const secondCut = firstCut + e.pageSize;
    this.activePageDataChunk = this.packages.slice(firstCut, secondCut);
  }

  getAllPackages() {
    // this.flowers = []
    this.packagesService.getPackages().then(f => {
      this.packages = f;
      this.length = this.packages.length;
      this.activePageDataChunk = this.packages.slice(0, this.pageSize);
      console.log(f);
      console.log(this.packages);
      console.log(this.activePageDataChunk);
    });
  }

  FilterType(expeditor?: string) {
    this.packagesService.getByExpeditor(this.expeditor).then(f => {
      this.packages = f;
      this.length = this.packages.length;
      this.activePageDataChunk = this.packages.slice(0, this.pageSize);
      console.log(this.expeditor);
      console.log(f);
      console.log(this.packages);
      console.log(this.activePageDataChunk);
    });
  }

  Filtru() {
    this.packagesService.getFiltru().then(f => {
      this.destinations = f;
      this.length = this.destinations.length;
      this.activePageDataChunk = this.destinations.slice(0, this.pageSize);

      console.log(f);
      console.log(this.destinations);
      console.log(this.activePageDataChunk);
    });
  }
}
