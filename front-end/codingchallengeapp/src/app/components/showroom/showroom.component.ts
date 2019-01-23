import { Component } from '@angular/core';
import { HttpApiService } from '../../providers/http-api.service';

@Component({
  selector: 'app-showroom',
  templateUrl: './showroom.component.html',
  styleUrls: ['./showroom.component.scss']
})
export class ShowroomComponent {
  title = 'codingchallengeapp';
  public salesData: any[] = [];
  public autoLoad: boolean = true;
  constructor(private http: HttpApiService) {

  }
  changeData(data:any[]){
    this.salesData = data;
  }
}
