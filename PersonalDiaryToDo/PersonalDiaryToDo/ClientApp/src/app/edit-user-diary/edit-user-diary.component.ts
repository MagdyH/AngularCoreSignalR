import { Component, OnInit,Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserDiary } from '../model/user-diary.model';
import {RestService} from '../services/rest.service';
import { AngularEditorConfig } from '@kolkov/angular-editor';

@Component({
  selector: 'app-edit-user-diary',
  templateUrl: './edit-user-diary.component.html',
  styleUrls: ['./edit-user-diary.component.css']
})
export class EditUserDiaryComponent implements OnInit {

  htmlContent = {};

  config: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    height: '15rem',
    minHeight: '5rem',
    placeholder: 'Enter text here...',
    translate: 'no',
    toolbarPosition: 'top',
    defaultFontName: 'Times New Roman',
    customClasses: [
      {
        name: "quote",
        class: "quote",
      },
      {
        name: 'redText',
        class: 'redText'
      },
      {
        name: "titleText",
        class: "titleText",
        tag: "h1",
      },
    ]
  };

  @Input() userDiary:UserDiary = { userDiaryId:0,userId:0,diaryTitle:'',diaryDataTime:'',insertionDate:'',diaryContent:'' };
  constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.rest.getDiary(this.route.snapshot.params['id']).subscribe((data) => {
      console.log(data);
      this.userDiary = data[0];
    });
  }


  updateDiary() {
    this.rest.updateDiary(this.route.snapshot.params['id'], this.userDiary).subscribe((result) => {
      this.router.navigate(['/user-diary/']);
    }, (err) => {
      console.log(err);
    });
  }
}
