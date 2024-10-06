import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IBusinessCard } from 'src/app/business-card/models/business-card';
import { BusinessCardParams } from 'src/app/business-card/models/business-card-params';
import { FileType } from 'src/app/business-card/models/fileType';
import { IPaginationResult } from 'src/app/business-card/models/pagination-result';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BusinessCardService {

  path = environment.host + environment.businessCardApi;
  constructor(private http:HttpClient) { }

  search(params: BusinessCardParams): Observable<IPaginationResult<IBusinessCard>> {
    let httpParams = this.getHttpParams(params);
    return this.http.get<IPaginationResult<IBusinessCard>>(this.path, { params: httpParams });
  }

  insert(businessCard: FormData):Observable<IBusinessCard>
  {
    return this.http.post<IBusinessCard>(this.path,businessCard);
  }
  delete(id:number):Observable<boolean>
  {
    let httpParams = this.getHttpParams({id:id});
    return this.http.delete<boolean>(this.path, {params : httpParams});
  }


  export(fileType:FileType) {
    let httpParams = this.getHttpParams({fileType});

    return this.http.get(`${this.path}export`, {params: httpParams , responseType: 'blob' });
  }

  import(file: File, fileType: FileType): Observable<any> {
    const formData: FormData = new FormData();
    formData.append('file', file);
    formData.append('fileType', fileType.toString());


    return this.http.post(this.path + 'import', formData);
  }

  generateQrCode(businessCard:IBusinessCard):Observable<any>{
    return this.http.post(`${this.path}GenerateQrCode`, businessCard, { responseType: 'blob' });

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
