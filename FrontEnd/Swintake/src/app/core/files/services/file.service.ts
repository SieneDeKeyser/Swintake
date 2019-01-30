import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiUrl } from '../../CommonUrl/CommonUrl';
import { UploadFile } from '../classes/uploadFile';
import { headersToString } from 'selenium-webdriver/http';





@Injectable({
  providedIn: 'root'
})



export class FileService {
  

  constructor(private http: HttpClient) {
   

   }

  uploadFile(fileDto: UploadFile, formData: FormData): Observable<any> {
  
    const httpOptions = {
      headers: new HttpHeaders({ 
        'fileDto':  JSON.stringify(fileDto)
      }
      )
    };

    return this.http.post(ApiUrl.urlFiles, formData, httpOptions, );
  }

}
