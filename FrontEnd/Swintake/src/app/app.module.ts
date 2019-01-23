import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component'; 
import { CoreModule } from './core/core.module';
import { RoutingModule } from './routing/routing.module';
import { FeatureModule } from './feature/feature.module';
import { SharedModule } from './shared/shared.module';
import { HeaderComponent } from './header/header.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './core/authentication/helpers/authInterceptor';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FooterComponent } from './footer/footer.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
  ],
  
  imports: [
    BrowserModule,
    CoreModule,
    RoutingModule,
    FeatureModule,
    SharedModule,
    HttpClientModule,
    NgbModule,
  ],
  providers:[
    { provide: HTTP_INTERCEPTORS, 
      useClass: AuthInterceptor, 
      multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
