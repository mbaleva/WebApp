import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AddRecipeComponent } from './add/add-recipe.component';



@NgModule({
  declarations: [
    AddRecipeComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    AddRecipeComponent
  ]
})
export class RecipesModule { }
