import { Component, OnInit } from '@angular/core';
import { PhonesService } from '../phones.service';

@Component({
  selector: 'app-phone-list',
  templateUrl: './phone-list.component.html',
  styleUrls: ['./phone-list.component.css']
})
export class PhoneListComponent implements OnInit {
  phones : any[];
  filteredPhones: any[];

  filter: any = {
    phoneName: '',
    buyerName: ''
  }

  constructor(private phonesService: PhonesService) { }

  async ngOnInit() {
    this.phones = <any[]> await this.phonesService.getAll();
    this.filteredPhones = this.phones;
    console.log(this.filteredPhones);
  }

  onPhoneChange(query: string) {
    this.filter.phoneName = query.toLowerCase();
    this.applyFiltering();
  }

  onBuyerChange(query: string) {
    this.filter.buyerName = query.toLowerCase();
    this.applyFiltering();
  }

  private applyFiltering() {
    this.filteredPhones = this.phones;
    this.applySearchingByPhone();
    this.applySearchingByBuyer();
  }

  private applySearchingByPhone() {
    if (!this.filter.phoneName) return; 
    this.filteredPhones = this.filteredPhones
      .filter(p => p.name.toLowerCase().includes(this.filter.phoneName));
  }

  private applySearchingByBuyer() {
    if (!this.filter.buyerName) return;
    this.filteredPhones = this.filteredPhones
      .filter(p => p.contact.name.toLowerCase().includes(this.filter.buyerName));
  }

}
