import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FiltersearchComponent } from './filtersearch/filtersearch.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    FiltersearchComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports:[
    FiltersearchComponent
  ]
})
export class SharedModule { }
