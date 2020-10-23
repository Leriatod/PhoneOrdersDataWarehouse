import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PhonesService } from '../phones.service';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private phonesService: PhonesService,
              private toastrService: ToastrService) {}

  async reloadPhones() {
    if (!confirm("Are you sure you want to reload phones data?")) return;
    await this.phonesService.reloadPhones();
    this.toastrService.success("Phones reloaded successfuly!", "Updating phones");
  }
}
