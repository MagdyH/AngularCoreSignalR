import { Injectable,Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { UserDiary } from '../model/user-diary.model';

@Injectable({
  providedIn: 'root'
})
export class RestService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

   }
 
   httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };
    // Rest Items Service: Read all REST Items
    getAll() {
      return this.http
        .get<any[]>(this.baseUrl+ 'api/UserDiary/GetUserDiaries')
        .pipe(map(data => data));
    }

    getDiary(id) {
      return this.http
        .get<any[]>(this.baseUrl+ 'api/UserDiary/GetUserDiary/'+ id)
        .pipe(map(data => data));
    }

    addDiary(userDiary:UserDiary) {
      return this.http
        .post(this.baseUrl+ 'api/UserDiary/AddUserDiary',JSON.stringify(userDiary),this.httpOptions)
        .pipe(data => data);     
    }

    updateDiary (id, userDiary:UserDiary) {
      return this.http.put(this.baseUrl+ 'api/UserDiary/UpdateUserDiary' + id, JSON.stringify(userDiary),this.httpOptions)
      .pipe(data => data);
    }
    
    deleteDiary (id): Observable<any> {
      return this.http.delete<any>(this.baseUrl+ 'api/UserDiary/DeleteUserDiary' + id,this.httpOptions)
      .pipe(data => data);
    }
}
