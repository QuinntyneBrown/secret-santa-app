import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from "../app/pages/home-page.component";


export const RoutingModule = RouterModule.forRoot([
    { path: "", component: HomePageComponent }
]);