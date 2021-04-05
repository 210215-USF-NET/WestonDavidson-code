import { HttpClient } from '@angular/common/http';
import { discardPeriodicTasks, TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { hero } from '../models/hero';

import { HeroRESTService } from './hero-rest.service';

// describe('HeroRESTService', () => {
//   let service: HeroRESTService;

//  every component in angular needs a module to exist/be compiled within
//  we'll put it in a special testing module, so that this will be a UNIT test
//   beforeEach(() => {
//     TestBed.configureTestingModule({});
//     service = TestBed.inject(HeroRESTService);
//   });

//   it('should be created', () => {
//     expect(service).toBeTruthy();
//   });
// });



describe('HeroRESTService', () =>{
  it('should be created', () => {
  const http = {} as HttpClient;
  const service = new HeroRESTService(http);
  expect(service).toBeTruthy();
});
it('should make the http request', () => {
  const expectedurl = `${environment.HEROES_REST}/bob`
  const expectedResult = of({} as hero);
  const http = {
    get(headers: any, url: string): Observable<hero> {
      if(url === expectedurl){
        return expectedResult;
      }
      throw new Error();
    }

  } as HttpClient;
  const service = new HeroRESTService(http);
  const result = service.GetHero('bob');
  expect(result).toBe(expectedResult);


});

});