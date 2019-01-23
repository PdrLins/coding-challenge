import { Component, Input } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse, HttpHeaders } from '@angular/common/http';
@Component({
  selector: 'upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.scss']
})

export class UploadFileComponent {
  @Input('isMultiple') isMutiple: boolean = false;
  @Input('fileType') fileTypes: string;
  private endPoint: string = "http://localhost:5001/api/"
  public message: string;
  public progress: number;
  private header: HttpHeaders;
    // this.header = new HttpHeaders({
    //   'Access-Control-Allow-Origin': '*',
    //   'Access-Control-Allow-Headers': "Origin, X-Requested-With, Content-Type, Accept"
    // });
  constructor(private http: HttpClient) {

  }

  upload(files:any[]) {
    if (files.length == 0)
      return;

    const formData = new FormData();
    for (let file of files)
      formData.append(file.name, file)
  
    const uploadReq = new HttpRequest('POST', this.endPoint + 'user/UploadFile', formData, {
      reportProgress: true
    });
    this.http.request(uploadReq).subscribe((ev:any) => {
      if(ev.type === HttpEventType.UploadProgress){
        this.progress = Math.round(100*ev.loaded / ev.total);
      }
      else if(ev.type === HttpEventType.Response){
          this.message = ev.body.message.toString();
      }
    });
  }
}
