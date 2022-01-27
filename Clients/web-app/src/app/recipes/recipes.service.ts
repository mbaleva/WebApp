import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from './category.model';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Recipe } from './recipe.model';
import { AnySoaRecord } from 'dns';

@Injectable({
    providedIn: 'root'
})

export class RecipesService { 
    recipesPath: string = 'https://localhost:5002/api/recipes';

    constructor(private http: HttpClient, private router: Router) { }

    getCategories(): Observable<Array<Category>> {
        return this.http.get<Array<Category>>(this.recipesPath + '/getallcategories');
    }
    create(data: FormGroup) {
        this.http.post(this.recipesPath + '/create', data).subscribe(res => {
            this.router.navigateByUrl('');
        })
    }
    all(): Observable<AnySoaRecord> {
        return this.http.get(`${this.recipesPath}/all`);
    }
}