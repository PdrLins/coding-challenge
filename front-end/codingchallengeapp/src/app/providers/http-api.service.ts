import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class HttpApiService {
  private apiRoot: string = "http://localhost:5001/api"
  private header: HttpHeaders;
  constructor(private http: HttpClient) { 

  }

  public post(method: string, paramObject): Promise<any> {
    // let mergedParamObject = { ...paramObject, ...this.user };
    let mergedParamObject = { ...paramObject };
    return new Promise((resolve, reject) => {
      let url  = `${this.apiRoot}/${method}`
      // let token = localStorage.getItem('token');
      // if (token) {
      //   this.header = new HttpHeaders({
      //     'Content-Type': 'application/json',
      //     'Authorization': "Bearer " + token
      //   });
      // }
      this.http.post<any>(url, mergedParamObject, { headers: this.header }).subscribe(
        res => {
          resolve(res)
        },
        err => {
           reject(err)
           }
      );
    });
  }

  public get(method: string, param: any = null): Promise<any> {
    return new Promise((resolve, reject) => {
      // let token = localStorage.getItem('token');
      // if (token) {
      //   this.header = new HttpHeaders({
      //     'Content-Type': 'application/json',
      //     'Authorization': "Bearer " + token
      //   });
      // }
      let url  = `${this.apiRoot}${method}`
      this.http.get((url).concat(param != null ? "/" + param : ''), { headers: this.header }).subscribe(
        res => {
          resolve(res)
        },
        err => {
          reject(err)
        });
    });
  }

  public request(method:string, param:any, init?:any): Observable<any>{
    let url  = `${this.apiRoot}/${method}`
    
    const uploadReq = new HttpRequest('POST', url, param, init);
    return this.http.request(uploadReq);
  }
}
