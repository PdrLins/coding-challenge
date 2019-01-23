import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class HttpApiService {
  private endPoint: string = "http://localhost:5001/api/"
  private header: HttpHeaders;
  constructor(private http: HttpClient) { 

  }

  public postRequest(method: string, paramObject): Promise<any> {
    // let mergedParamObject = { ...paramObject, ...this.user };
    let mergedParamObject = { ...paramObject };
    return new Promise((resolve, reject) => {
      // let token = localStorage.getItem('token');
      // if (token) {
      //   this.header = new HttpHeaders({
      //     'Content-Type': 'application/json',
      //     'Authorization': "Bearer " + token
      //   });
      // }
      this.http.post<any>(this.endPoint + method, mergedParamObject, { headers: this.header }).subscribe(
        res => {
          resolve(res)
        },
        err => {
           reject(err)
           }
      );
    });
  }

  public getRequest(method: string, param: any = null): Promise<any> {
    return new Promise((resolve, reject) => {
      // let token = localStorage.getItem('token');
      // if (token) {
      //   this.header = new HttpHeaders({
      //     'Content-Type': 'application/json',
      //     'Authorization': "Bearer " + token
      //   });
      // }
      this.http.get((this.endPoint + method).concat(param != null ? "/" + param : ''), { headers: this.header }).subscribe(
        res => {
          resolve(res)
        },
        err => {
          reject(err)
        });
    });
  }
}
