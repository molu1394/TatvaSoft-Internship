import { Routes } from '@angular/router';
import { RegisterpageComponent } from './registerpage/registerpage.component'
import { LoginpageComponent } from './loginpage/loginpage.component'

export const routes: Routes = [
    {
        path:'loginpage',
        component: LoginpageComponent

    },
    {
        path:'registerpage',
        component:RegisterpageComponent
    },
    {
        path:'**',
        redirectTo:'loginpage'
    }
   
];