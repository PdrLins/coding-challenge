import { Component } from '@angular/core';
import { HttpApiService } from '../app/providers/http-api.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
 

  constructor(private http: HttpApiService) {

  }

}
