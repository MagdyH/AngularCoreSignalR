import { Component, OnInit, Input  } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserDiary } from '../model/user-diary.model';
import {RestService} from '../services/rest.service';
import { AngularEditorConfig } from '@kolkov/angular-editor';

@Component({
  selector: 'app-add-user-diary',
  templateUrl: './add-user-diary.component.html',
  styleUrls: ['./add-user-diary.component.css']
})
export class AddUserDiaryComponent implements OnInit {

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
  }

  addUserDiaries(){
    this.rest.addDiary(this.userDiary).subscribe(result => {
      this.router.navigate(['/user-diary/']);
    }, error => console.error(error));
  }
}
