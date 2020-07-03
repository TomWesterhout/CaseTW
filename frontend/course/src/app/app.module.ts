import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTableModule } from '@angular/material/table';
import { AppRoutingModule } from './app-routing.module';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { CursusComponent } from './cursus/cursus.component';
import { CursusInstantieComponent } from './cursus-instantie/cursus-instantie.component';
import { CursusInstantieAddComponent } from './cursus-instantie-add/cursus-instantie-add.component';

import { CursusInstantieService } from './shared/api/cursus-instantie.service';
import { CursusService } from './shared/api/cursus.service';

const cursusWeek: number = 28; // gebaseerd op de week waarin de opdracht wordt beoordeeld.
const cursusYear: number = 2020;
const examinationDateUrl: string = `cursusinstantie-overzicht/${cursusWeek}/${cursusYear}`;

const appRoutes: Routes = [
  { 
    path: '', 
    redirectTo: '/cursusinstantie-overzicht', 
    pathMatch: 'full' 
  },
  { 
    path: 'cursusinstantie-overzicht', 
    component: CursusInstantieComponent 
  },
  {
    path: 'cursusinstantie-overzicht/:cursusweek/:cursusyear',
    component: CursusInstantieComponent
  },
  {
    path: 'cursusinstantie-upload',
    component: CursusInstantieAddComponent
  }
];

@NgModule({
  declarations: [
    AppComponent,
    CursusComponent,
    CursusInstantieComponent,
    CursusInstantieAddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatListModule,
    MatToolbarModule,
    MatTableModule,
    BrowserAnimationsModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    ReactiveFormsModule
  ],
  providers: [CursusInstantieService, CursusService],
  bootstrap: [AppComponent]
})
export class AppModule { }