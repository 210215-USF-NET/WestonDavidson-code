import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { hero } from 'src/app/models/hero';
import { HeroRESTService } from 'src/app/services/hero-rest.service';

@Component({
  selector: 'app-hero-details',
  templateUrl: './hero-details.component.html',
  styleUrls: ['./hero-details.component.css']
})
export class HeroDetailsComponent implements OnInit {

  hero: hero;

  //an activated route allows us to unpack our route to get query parameters from our route string!
  // allows us to unpack the route, ie get route parameters sent
  constructor(private heroService : HeroRESTService, private route : ActivatedRoute) {
    this.hero =
    {
      heroName: '',
      hp: 0,
      elementType: 0,
      superPower:
      {
        name: '',
        description: '',
        damage: 0,
      }
      

    }
  }

  ngOnInit(): void {
    //we are getting the query parameters from the previous route
    this.route.queryParams
    .subscribe(
      //once we get the parameters, unpack them
      params => {
        //then get the value of the hero parameter
        //the gethero method is an observable we subscribe to
        this.heroService.GetHero(params.hero).subscribe
        (
          //then we unpack the gethero observable to pull the data out
          foundHero =>
          {
            //then we set our hero inside our component to the found hero!
            this.hero = foundHero;
          }
        )
      }
    );
  }

}
