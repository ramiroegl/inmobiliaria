import { ApplicationConfig } from '@angular/core';
import { provideRouter, withComponentInputBinding, withHashLocation } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { AuthGuard } from "./login/services/auth-guard";
import { authInterceptor } from "./login/services/auth-interceptor";

export const appConfig: ApplicationConfig = {
    providers: [
        provideRouter(routes, withHashLocation(), withComponentInputBinding()),
        provideHttpClient(),
        AuthGuard,
        provideHttpClient(withInterceptors([authInterceptor]))
    ]
};
