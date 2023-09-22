import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// Angular Material
import { MatSliderModule } from '@angular/material/slider';
import {MatTableModule} from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    MatSliderModule,
    MatTableModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
  ], 
  exports: [
    MatSliderModule,
    MatTableModule,
    MatInputModule,
    MatPaginatorModule,
    MatIconModule,
  ]
})
export class SharedModule { }
