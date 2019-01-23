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
  changeData(data: any[]) {
    let group = this.groupBy(data, 'vehicle');
    this.salesData = data;
  }
  
  private groupBy(collection: any[], property: string) {
    var groupByName = {};

    collection.forEach(function (a) {
      groupByName[a[property]] = groupByName[a[property]] || [];
      groupByName[a[property]].push(a);
    });
    return groupByName;
  }
}
