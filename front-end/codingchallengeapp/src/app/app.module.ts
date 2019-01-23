import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpApiService } from './providers/http-api.service';
import { UploadFileService } from './components/upload-file/service/upload-file.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UploadFileComponent } from './components/upload-file/upload-file.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { ShowroomComponent } from './components/showroom/showroom.component';

@NgModule({
  declarations: [
    AppComponent,
    UploadFileComponent,
    WelcomeComponent,
    ShowroomComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [HttpApiService, UploadFileService],
  bootstrap: [AppComponent]
})
export class AppModule { }
