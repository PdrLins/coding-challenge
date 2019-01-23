import { Injectable } from '@angular/core';
import { HttpApiService } from '../../../providers/http-api.service';

@Injectable()
export class UploadFileService {

  constructor(private http: HttpApiService) {

  }

  upload(formData: FormData) {
    return this.http.request('components/UploadFile', formData, {
      reportProgress: true
    });
  }

  load(fileName: string) {
    return this.http.post("components/LoadFile", { fileName: fileName });
  }
}
