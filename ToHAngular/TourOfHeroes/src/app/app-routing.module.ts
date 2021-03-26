import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@auth0/auth0-angular';
import { AddHeroComponent } from './components/add-hero/add-hero.component';
import { EditHeroComponent } from './components/edit-hero/edit-hero.component';
import { GetHeroesComponent } from './components/get-heroes/get-heroes.component';
import { HeroDetailsComponent } from './components/hero-details/hero-details.component';
//this module gets scaffolded when you say to include routing in your angular app
//this property is where you define which routes/routerlinks goes to certain components
//you need two things to define a route: path (endpoint-ish thing) and component that it's routing to
const routes: Routes = [
  {
    path: 'get-heroes',
    component: GetHeroesComponent,
    canActivate:[AuthGuard]

  },
  {
    path: 'add-hero',
    component: AddHeroComponent,
    canActivate:[AuthGuard]
  },
  {
    path: 'hero-details',
    component: HeroDetailsComponent,
    canActivate:[AuthGuard]
  },
  {
    path: 'edit-hero',
    component: EditHeroComponent,
    canActivate:[AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
