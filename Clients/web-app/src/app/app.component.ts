import { Component, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  constructor(){
    
    setTimeout(() => {
      this.data = {name: 'new name'};
      console.log('data was changed');
    }, 5000);
  }
  title = 'web-app';

  data = {name: 'THIS IS DEFAULT NAME'};
}
