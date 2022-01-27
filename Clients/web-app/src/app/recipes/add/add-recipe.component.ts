import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { Category } from '../category.model';
import { Recipe } from '../recipe.model';
import { RecipesService } from '../recipes.service';

@Component({
    selector: 'app-add-recipe',
    templateUrl: './add-recipe.component.html',
    styleUrls: ['./add-recipe.component.css']
})

export class AddRecipeComponent implements OnInit {
    categories!: Array<Category>;
    recipeForm!: FormGroup; 
    constructor(
        private fb: FormBuilder,
        private router: Router,
        private recipesService: RecipesService) {
            this.recipesService.getCategories().subscribe(res => {
                this.categories = res;
            console.log(this.categories);
            })

        }

    ngOnInit(): void {
        this.recipeForm = this.fb.group({
            name: [null, Validators.required],
            instructions: [null, Validators.required],
            preparationTime: [null, Validators.required],
            cookingTime: [null, Validators.required],
            portionsCount: [null, Validators.required],
            image: [null, Validators.required],
            category: [null, Validators.required]
        })
    }
    addRecipeSubmitHandler(){
        console.log(this.recipeForm.value);
        this.recipesService.create(this.recipeForm.value);
    }
}