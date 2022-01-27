import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddRecipeComponent } from './add/add-recipe.component';



@NgModule({
  declarations: [
    AddRecipeComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    AddRecipeComponent
  ]
})
export class RecipesModule { }
