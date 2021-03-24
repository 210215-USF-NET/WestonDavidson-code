import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { hero } from 'src/app/models/hero';
import { HeroRESTService } from 'src/app/services/hero-rest.service';

@Component({
  selector: 'app-get-heroes',
  templateUrl: './get-heroes.component.html',
  styleUrls: ['./get-heroes.component.css']
})
export class GetHeroesComponent implements OnInit {
  //this is where we put our properties
  heroes: hero[] = [];

  //where you inject dependencies
  //inject the heroRest service to gain access to the data access methods of the service
  constructor(private heroService: HeroRESTService, private router:Router) { }

  //lifecycle hook
  //components have a lifecycle
  // on initialization of this particular component, what do you want to do?
  //in the get heroes component, we want to get the heroes and initialize our heroes list
  ngOnInit(): void {
    //we call the hero service, grab the getallhero observable, then subscribe to it
    //then, when the result is sent from the observable, we assign our heroes property to the result data
    this.heroService.GetAllHeroes().subscribe(
      (result) =>
      {
        this.heroes = result;
      }
    )
  }

  GetHero(heroName: string)
  {
    //this is a way to pass data between components!
    //we are navigating to the other component, and passing data to the component from this component!
    this.router.navigate(['hero-details'], {queryParams: {hero:heroName}})

    //you can also pass data between components by using services!
    // above, we used query parameters, but services work that have been injected into two different components as well

  }

}
