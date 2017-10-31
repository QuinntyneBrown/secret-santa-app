import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BrowserModule} from '@angular/platform-browser';
import {RouterModule} from '@angular/router';
import {HttpModule} from '@angular/http';
import {FormsModule} from '@angular/forms';

import {PagesModule} from "../app/pages/pages.module";
import {SharedModule} from "../app/shared";
import {UsersModule} from "../app/users/users.module";
import {TenantsModule} from "../app/tenants/tenants.module";

import {AppComponent} from './app.component';

import { RoutingModule } from "./app.routing";

const declarables = [
    AppComponent
];

const providers = [];

@NgModule({
    imports: [
        RoutingModule,
        BrowserModule,
        HttpModule,
        CommonModule,
        FormsModule,
        RouterModule,

        PagesModule,
        SharedModule,
        TenantsModule,
        UsersModule

    ],
    providers: providers,
    declarations: [declarables],
    exports: [declarables],
    bootstrap: [AppComponent]
})
export class AppModule { }

