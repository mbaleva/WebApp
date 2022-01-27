import { Component } from '@angular/core';
import { Recipe } from '../recipe.model';
import { RecipesService } from '../recipes.service';

@Component({
    selector: 'app-all-recipes',
    templateUrl: './all.component.html',
    styleUrls: ['./all.component.css']
})


export class AllComponent {
    constructor(private recipesService: RecipesService) {
    }
}