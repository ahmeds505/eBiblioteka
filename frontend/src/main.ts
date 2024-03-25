import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { Component, Inject } from '@angular/core';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment-config';


if (environment.production) {
  enableProdMode();
}


platformBrowserDynamic().bootstrapModule(AppModule, {
  providers: [
    { provide: 'APP_CONFIG', useValue: environment }
  ]
})
  .catch(err => console.error(err));

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
