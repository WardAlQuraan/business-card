import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IBusinessCard } from 'src/app/business-card/models/business-card';
import { BusinessCardParams } from 'src/app/business-card/models/business-card-params';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BusinessCardService {

  path = environment.host + environment.businessCardApi;
  constructor(private http:HttpClient) { }

  search(params: BusinessCardParams): Observable<IBusinessCard[]> {
    let httpParams = this.getHttpParams(params);
    return this.http.get<IBusinessCard[]>(this.path, { params: httpParams });
  }

  insert(businessCard: FormData):Observable<IBusinessCard>
  {
    return this.http.post<IBusinessCard>(this.path,businessCard);
  }

  getHttpParams(params:any){
    let httpParams = new HttpParams();
    Object.keys(params).forEach((key) => {
      const value = (params as any)[key];
      if (value !== null && value !== undefined) { // Ensure only valid values are added
        httpParams = httpParams.set(key, value.toString());
      }
    });
    return httpParams;
  }
  
}
