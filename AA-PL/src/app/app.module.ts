import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {MatButtonModule} from '@angular/material/button';
import { AppComponent } from './app.component';
import { CategoryService } from './category.service';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TrialComponent } from './trial/trial.component';
import { RouterModule } from '@angular/router';
import { TestComponent } from './test/test.component';
import { OAuthModule } from 'angular-oauth2-oidc';



@NgModule({
  declarations: [
    AppComponent,
    TrialComponent,
    TestComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    OAuthModule.forRoot(),
    FormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    RouterModule.forRoot([
      {path: 'test', component: TestComponent},
      {path: 'trial', component: TrialComponent},
    ]),
  ],
  providers: [CategoryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
