import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { HttpEventType } from '@angular/common/http';
import { UploadFileService } from './service/upload-file.service';

@Component({
  selector: 'upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.scss']
})

export class UploadFileComponent implements OnInit {
  @Output() dataValueChange = new EventEmitter();
  @Input() autoLoad: false;
  public message: string;
  public progress: number;
  public success:boolean;
  public fileName: string;

  constructor(private uploadFileService: UploadFileService) {
  }

  ngOnInit() {

  }

  upload(files: any[]) {
    this.dataValueChange.emit([]);
    if (files.length == 0)
      return;

    const formData = new FormData();
    for (let file of files) {
      formData.append(file.name, file)
      this.fileName = file.name;
    }


    this.uploadFileService.upload(formData).subscribe((ev: any) => {
      if (ev.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * ev.loaded / ev.total);
      }
      else if (ev.type === HttpEventType.Response) {
        this.message = ev.body.message.toString();
        this.success = ev.body.isSuccess;
        if (ev.body.isSuccess) {
          this.message = "Loading..."
          setTimeout(() => {
            this.dataValueChange.emit(ev.body)
            this.message = ""
          }, 500)
        }
      }
    });
  }

  load(fileName: string) {

  }
}
