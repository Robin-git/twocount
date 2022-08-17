import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { CoreHeaderComponent } from './components/core-header/core-header.component';

@NgModule({
  declarations: [
    CoreHeaderComponent
  ],
  imports: [
    CommonModule,
    MatToolbarModule
  ],
  exports: [
    CoreHeaderComponent
  ]
})
export class CoreModule { }
