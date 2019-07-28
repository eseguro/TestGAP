import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { NgModule } from '@angular/core';
import { MatPaginatorModule } from '@angular/material/paginator';
@NgModule({
	imports: [
		MatTableModule, 
		MatButtonModule,
		MatPaginatorModule
	],
	exports: [
		MatTableModule,
		MatButtonModule,
		MatPaginatorModule
	]
})
export class MaterialModule { }