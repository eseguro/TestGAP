import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


//core functionality
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';

//3rd libraries
import { MaterialModule } from './material.module';
import { MatFormFieldModule, MatInputModule, DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS, MatDatepickerModule, MatDialogModule, MatButtonModule } from '@angular/material';

//Components
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ListInsuranceComponent } from './insurance-policy/list/list-insurance-policy.component';
import { EditInsurancePolicyComponent } from './insurance-policy/edit/edit-insurance-policy.component';
import { CreateInsurancePolicyComponent } from './insurance-policy/create/create-insurance-policy.component';
import { FormInsurancePolicyComponent } from './insurance-policy/form-insurance-policy/form-insurance-policy.component';

//services
import { InsurancePolicyService } from './shared/services/insurance-policy.service';
import { RiskTypeService } from './shared/services/risk-type.service';
import { MomentDateAdapter, MAT_MOMENT_DATE_FORMATS } from '@angular/material-moment-adapter';
import { ConfirmationDialogComponent } from './shared/components/confirmation-dialog/confirmation-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ListInsuranceComponent,
    EditInsurancePolicyComponent,
    CreateInsurancePolicyComponent,
    FormInsurancePolicyComponent,
    ConfirmationDialogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'insurance', component: ListInsuranceComponent },
      { path: 'insurance/:id/edit', component: EditInsurancePolicyComponent},
      { path: 'insurance/new', component: CreateInsurancePolicyComponent},
    ]),
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatDialogModule,
    MatButtonModule
  ],
  entryComponents: [
    ConfirmationDialogComponent
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
    InsurancePolicyService,
    RiskTypeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
