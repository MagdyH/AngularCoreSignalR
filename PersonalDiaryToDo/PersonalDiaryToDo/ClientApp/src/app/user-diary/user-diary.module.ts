import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { OwlDateTimeModule, OwlNativeDateTimeModule,OwlDateTimeComponent } from 'ng-pick-datetime';
import { UserDiaryComponent} from './user-diary.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule 
  ],
  declarations: [
    UserDiaryComponent,
    OwlDateTimeComponent
  ]
})
export class UserDiaryModule { }
