import { Component, OnInit } from '@angular/core';
import { PhonesService } from '../phones.service';
import * as _ from 'underscore';

@Component({
  selector: 'app-phone-list',
  templateUrl: './phone-list.component.html',
  styleUrls: ['./phone-list.component.css']
})
export class PhoneListComponent implements OnInit {
  private readonly PAGE_SIZE = 5;

  phones : any[];
  filteredPhones: any[];
  displayedPhones: any[];

  filter : any = {
    phoneModel: '',
    contactName: '',
    page: 1,
    pageSize: this.PAGE_SIZE
  };

  constructor(private phonesService: PhonesService) { }

  async ngOnInit() {
    this.phones = <any[]> await this.phonesService.getAll();
    this.filteredPhones = this.phones;
    this.displayedPhones = _.take(this.filteredPhones, this.filter.pageSize)
  }

  resetFilter() {
    this.filter.phoneModel = '';
    this.filter.contactName = '';
    this.filter.page = 1;
    this.applyFiltering();
  }

  onPhoneChange(query: string) {
    this.filter.phoneModel = query;
    this.applyFiltering();
  }

  onBuyerChange(query: string) {
    this.filter.contactName = query;
    this.applyFiltering();
  }

  private applyFiltering() {
    this.filteredPhones = this.phones;
    this.applySearchingByPhone();
    this.applySearchingByBuyer();
    this.applyPagination();
  }

  private applySearchingByPhone() {
    if (!this.filter.phoneModel) return; 
    this.filteredPhones = this.filteredPhones
      .filter( p => p.name.toLowerCase().includes( this.filter.phoneModel.toLowerCase() ) );
  }

  private applySearchingByBuyer() {
    if (!this.filter.contactName) return;
    this.filteredPhones = this.filteredPhones
      .filter( p => p.contact.name.toLowerCase().includes( this.filter.contactName.toLowerCase() ) );
  }

  applyPagination() {
    var startIndex  = (this.filter.page - 1) * this.PAGE_SIZE;
    this.displayedPhones = _.take(_.rest(this.filteredPhones, startIndex), this.PAGE_SIZE);
  }

}
