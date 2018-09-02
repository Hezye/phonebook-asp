import { Component, OnInit, TemplateRef } from '@angular/core';
import { PhoneService } from './phone.service';
import { Observable } from 'rxjs/Observable';
import { tap, catchError, map } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-phones',
  templateUrl: './phones.component.html',
  styleUrls: ['./phones.component.css']
})
export class PhonesComponent implements OnInit {
  public phoneEntries: PhoneEntry[];
  modalRef: BsModalRef;
  newEntry: PhoneEntry;

  constructor(private service: PhoneService,
    private modalService: BsModalService) { }

  ngOnInit() {
    this.initEntries();
  }

  private initEntries() {
    this.service.pagedList(10, 1).subscribe(p => this.phoneEntries = p);
  }

  openModal(template: TemplateRef<any>) {
    this.newEntry = { firstName: '', lastName: '', phoneNumber: '' };
    this.modalRef = this.modalService.show(template);
  }

  add() {
    this.service.add(this.newEntry).subscribe(r => {
      this.initEntries();
      this.modalRef.hide();
    });
  }

  delete(entry: PhoneEntry) {
    this.service.delete(entry.phoneNumber).subscribe(x => {
      const index = this.phoneEntries.indexOf(entry);
      if (index > -1) {
        this.phoneEntries.splice(index, 1);
      }
    });
  }
}
