import { Component } from '@angular/core';
import {HttpApiService} from '../app/providers/http-api.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'codingchallengeapp';
  salesData:any[] = [];

constructor(private http: HttpApiService) {
  
}
  load(){
    this.http.postRequest("User/LoadFileData",{fileName: "file1.csv"}).then(e=>{
      this.salesData = e.data;
    });
  }
}
