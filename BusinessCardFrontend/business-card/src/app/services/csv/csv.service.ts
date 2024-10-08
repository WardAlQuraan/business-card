import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBusinessCard } from 'src/app/business-card/models/business-card';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CsvService {
  path = environment.host + environment.csvApi;
  constructor(private http:HttpClient) { }

  getBusinessCard(file:File){
    const formData: FormData = new FormData();
    formData.append('file', file);

    return this.http.post<IBusinessCard[]>(this.path + "GetBusinessCards" , formData);
  }
}
