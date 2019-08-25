import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {RestService} from '../services/rest.service';
import { SignalRService } from '../services/signal-r.service';
import { UserDiaryResult } from '../model/user-diary.model';

@Component({
  selector: 'app-user-diary',
  templateUrl: './user-diary.component.html',
  styleUrls: ['./user-diary.component.css']
})
export class UserDiaryComponent implements OnInit {
  public userDiaries: UserDiaryResult[];

  constructor(public rest:RestService,public signalRService: SignalRService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addTransferChartDataListener();
    this.getUserDiaries();
  }

  add() {
    this.router.navigate(['/add-user-diary']);
  }

  getUserDiaries(){
    this.rest.getAll().subscribe(result => {
      this.userDiaries = result;
    }, error => console.error(error))
  }


  deleteDiary(id) {
    this.rest.deleteDiary(id)
      .subscribe(res => {
          this.getUserDiaries();
        }, (err) => {
          console.log(err);
        }
      );
  }
}
