import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { NgModule } from '@angular/core';
import { MatPaginatorModule } from '@angular/material/paginator';
import { CdkTableModule } from '@angular/cdk/table';
import {MatIconModule} from '@angular/material/icon'

@NgModule({
	imports: [
		MatTableModule, 
		MatButtonModule,
		MatPaginatorModule,
		MatIconModule
	],
	exports: [
		MatTableModule,
		MatButtonModule,
		MatPaginatorModule,
		MatIconModule
	]
})
export class MaterialModule { }