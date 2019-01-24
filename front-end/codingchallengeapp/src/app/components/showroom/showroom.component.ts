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
  public mostSold: any = null;
  constructor(private http: HttpApiService) {

  }
  changeData(data: any) {
    if (data.hasOwnProperty('data'))
      this.salesData = data.data;

    if (data.hasOwnProperty('mostSold'))
      this.mostSold = data.mostSold;
  }
}
