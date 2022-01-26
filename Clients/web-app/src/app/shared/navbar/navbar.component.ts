import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.css']
})

export class NavbarComponent implements OnInit {
    authToken: string | null | undefined;
    constructor() { }
    ngOnInit() {
        this.getAuthToken();
    }
    getAuthToken(){
        this.authToken = localStorage.getItem('authToken');
    }
    logout(): void {
        localStorage.removeItem('authToken');
    }
}