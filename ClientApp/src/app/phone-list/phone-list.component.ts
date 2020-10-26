import { Component, OnInit } from '@angular/core';
import { PhonesService } from '../phones.service';
import * as _ from 'underscore';
import { DatePipe } from '@angular/common';
import { SearchingText } from '../searchingText';

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
    purchaseDate: '',
    page: 1,
    pageSize: this.PAGE_SIZE
  };
  
  constructor(private phonesService: PhonesService, 
              private datepipe: DatePipe,
              private searchingText: SearchingText) { }

  async ngOnInit() {
    this.phones = <any[]> await this.phonesService.getAll();
    this.filteredPhones = this.phones;
    this.displayedPhones = _.take(this.filteredPhones, this.filter.pageSize);
  }

  resetFilter() {
    this.filter.phoneModel = '';
    this.filter.contactName = '';
    this.filter.purchaseDate = '';
    this.filter.page = 1;
    this.applyFiltering();
  }

  onPhoneChange(phoneModel: string) {
    this.filter.phoneModel = phoneModel;
    this.applyFiltering();
  }

  onContactChange(contactName: string) {
    this.filter.contactName = contactName;
    this.applyFiltering();
  }

  onDateChange(purchaseDate: string) {
    this.filter.purchaseDate = purchaseDate;
    this.applyFiltering();
  }

  private applyFiltering() {
    this.filteredPhones = this.phones;
    this.applySearchingByPhone();
    this.applySearchingByContact();
    this.applySearchingByPurchaseDate();
    this.applyPagination();
  }

  private applySearchingByPhone() {
    if (!this.filter.phoneModel) return; 
    this.filteredPhones = this.filteredPhones
      .filter( p => this.searchingText.hasAllCharsOf(p.name, this.filter.phoneModel ) );
  }


  private applySearchingByContact() {
    if (!this.filter.contactName) return;
    this.filteredPhones = this.filteredPhones
      .filter( p => this.searchingText.hasAllCharsOf(p.contact.name, this.filter.contactName ) );
  }

  private applySearchingByPurchaseDate() {
    if (!this.filter.purchaseDate) return;
    this.filteredPhones = this.filteredPhones
      .filter(p => {
        var purchaseDateString = this.datepipe.transform(p.purchaseDate);
        var hasDateStringFromFilter = this.searchingText.hasAllCharsOf(purchaseDateString, this.filter.purchaseDate);
        return hasDateStringFromFilter;
      }); 
  }

  applyPagination() {
    var startIndex  = (this.filter.page - 1) * this.PAGE_SIZE;
    this.displayedPhones = _.take(_.rest(this.filteredPhones, startIndex), this.PAGE_SIZE);
  }

}
