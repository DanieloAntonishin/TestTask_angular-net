import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { AppComponent } from './app.component';
import { AuthComponent } from './components/Auth/auth';
import { InfoComponent } from './components/Inforamation/info';
import { MainComponent } from './components/Main/main';

const routes: Routes = [
  { path: '', component: MainComponent },
  { path: 'auth', component: AuthComponent },
  { path: 'info', component: InfoComponent },
]


@NgModule({
  imports: [RouterModule.forRoot(routes, { anchorScrolling: 'disabled', scrollPositionRestoration: "enabled" })],
  exports: [RouterModule]
})
export class AppRoutingModule {
  constructor() {
  }
}
