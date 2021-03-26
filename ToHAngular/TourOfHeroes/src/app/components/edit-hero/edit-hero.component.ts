import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { hero } from 'src/app/models/hero';
import { HeroRESTService } from 'src/app/services/hero-rest.service';

@Component({
  selector: 'app-edit-hero',
  templateUrl: './edit-hero.component.html',
  styleUrls: ['./edit-hero.component.css']
})
export class EditHeroComponent implements OnInit {
  hero2Edit : hero;

  constructor(private route: ActivatedRoute, private heroService:HeroRESTService, private router: Router) { 
    this.hero2Edit =
      {
        heroName: '',
        hp: 0,
        elementType: 0,
        superPower:
        {
          name: '',
          description: '',
          damage: 0,
          id: 0,
          heroid: 0
        },
        id: 0
        
  
      }
    
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(
      params =>
      {
        this.heroService.GetHero(params.hero).subscribe(
          (hero) => {
            this.hero2Edit = hero;
          }
        )
      }
    )
  }

  onSubmit(): void {
    this.heroService.EditHero(this.hero2Edit).subscribe(
      () => {
        alert(`${this.hero2Edit.heroName}'s info was successfully edited`);
        this.router.navigate([''])
      }
    )
  }

}
