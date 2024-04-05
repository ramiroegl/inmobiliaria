import {ApplicationConfig} from '@angular/core';
import {provideRouter, withComponentInputBinding} from '@angular/router';

import {routes} from './app.routes';
import {provideHttpClient, withInterceptors} from '@angular/common/http';
import {AuthGuard} from "./login/services/auth-guard";
import {authInterceptor} from "./login/services/auth-interceptor";

export const appConfig: ApplicationConfig = {
    providers: [provideRouter(routes, withComponentInputBinding()), provideHttpClient(), AuthGuard, provideHttpClient(
        withInterceptors([authInterceptor]),
    )]
};
