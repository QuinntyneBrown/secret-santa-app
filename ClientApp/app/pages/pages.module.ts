import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../shared/shared.module";

import { HomePageComponent } from "./home-page.component";
import { AdminPageComponent } from "./admin-page.component";
import { LoginPageComponent } from "./login-page.component";
import { SetTenantPageComponent } from "./set-tenant-page.component";
import { RegisterationPageComponent } from "./registeration-page.component";


export const PAGE_ROUTES: Routes = [{
    path: '',
    component: HomePageComponent,
    canActivate: [
    ]
},
{
    path: 'admin',
    component: AdminPageComponent,
    canActivate: [
    ]
    },
{
    path: 'login',
    component: LoginPageComponent,
    canActivate: [
    ]
},
{
    path: 'tenants/set',
    component: SetTenantPageComponent,
    canActivate: [
    ]
}, {
    path: "register",
    component: RegisterationPageComponent,
    canActivate: []
}];

const declarables = [
    HomePageComponent,
    AdminPageComponent,
    LoginPageComponent,
    SetTenantPageComponent
];

const providers = [];

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        ReactiveFormsModule,
        RouterModule.forChild(PAGE_ROUTES),
        SharedModule
        ],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class PagesModule { }
