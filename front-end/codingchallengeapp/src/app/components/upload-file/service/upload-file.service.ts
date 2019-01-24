import { Injectable } from '@angular/core';
import { HttpApiService } from '../../../providers/http-api.service';

@Injectable()
export class UploadFileService {

  constructor(private http: HttpApiService) {

  }

  upload(formData: FormData) {
    return this.http.request('VehicleData/ImportSalesFromCsvFile', formData, {
      reportProgress: true
    });
  }

  load(fileName: string) {
   
  }
}
