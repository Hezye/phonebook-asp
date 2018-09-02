import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { catchError } from 'rxjs/operators';

@Injectable()
export class PhoneService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  pagedList(pageSize: number, pageIndex: number = 1): Observable<PhoneEntry[]> {
    const options = { params: new HttpParams().set('PageIndex', pageIndex.toString()).set('PageSize', pageSize.toString()) };
    return this.http.get<PhoneEntry[]>(this.baseUrl + 'api/phone', options);
  }

  add(entry: PhoneEntry) {
    const url = this.baseUrl + `api/phone/`;
    return this.http.post<PhoneEntry>(url, entry).pipe(
      catchError(err => {
        console.log(err);
        return err;
      })
    );
  }

  delete(id: string) {
    const url = this.baseUrl + `api/phone/${id}`;
    return this.http.delete<void>(url).pipe(
      catchError(err => {
        console.log(err);
        return err;
      })
    );
  }
}
