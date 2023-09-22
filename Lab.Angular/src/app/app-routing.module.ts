import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  {path: '', pathMatch:'full', redirectTo:'login'},
  {path: 'login', component: LoginComponent}, // redirecciona cualquier ruta a login component
  { path: 'dashboard',
    loadChildren: () => import('./components/dashboard/dashboard.module')
                  .then((x) => x.DashboardModule)
  }, // carga pasiva 
  { path: '**', pathMatch: 'full', redirectTo: 'dashboard'} // Acá podríamos poner una página 404 para cuando escriban cualquier ruta que no exista
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    [RouterModule.forRoot(routes)],
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
