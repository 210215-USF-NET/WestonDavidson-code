import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { hero } from '../models/hero';

@Injectable({
  providedIn: 'root'
})
export class HeroRESTService {
  //this is where you set up your properties
  //Set up headers
  httpOptions = {
    headers: new HttpHeaders(
      {
        'Content-Type':'application/json'
      }
    )
  }
  //defines the URL we'll be querying
  url : string = 'https://localhost:44352/api/Hero';

  //this is where you inject your dependencies
  //the httpClient is what you'll be using to query the external REST API
  constructor(private http:HttpClient) { }

  //logic goes here
  //an observable is a stream of data
  //kind of like a promise, it's an async stream of data that can be subscribed to
  //an async operation that will result in some sort of data
  //unlike a promise though, if something changes on the endpoint/data, anything that is subscribed to that observable will just update
  //kind of like events in c#
  //if the property changes, objects subscribed to that observable will do something
  //an asynchronous stream of data which can be subscribed to, can be cancelled, can be resolved more than once
  //promises with the door left open
  GetAllHeroes():Observable<hero[]>
  {
    //here, we're just getting a set of data from a specific url and returning it!
    return this.http.get<hero[]>(this.url, this.httpOptions);
  }
  GetHero(heroName:string) : Observable<hero>
  {
    return this.http.get<hero>(`${this.url}/{${heroName}}`, this.httpOptions);
  }
  AddHero(hero2Add: hero):Observable<hero>
  {
    return this.http.post<hero>(this.url, hero2Add, this.httpOptions);
  }
}
//we need the httpclient module
