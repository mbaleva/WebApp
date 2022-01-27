import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddRecipeComponent } from './add/add-recipe.component';

const routes: Routes = [
    {path: 'create', component: AddRecipeComponent}
];


@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})

export class RecipesRoutingModule { }