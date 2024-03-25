import { NgModule } from '@angular/core';
import {MatMenuModule} from "@angular/material/menu";
import {MatExpansionModule} from "@angular/material/expansion";
import {MatButtonModule} from "@angular/material/button";
import {MatDividerModule} from "@angular/material/divider"
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from "@angular/material/core";

const MaterialComponents = [
  MatMenuModule,
  MatExpansionModule,
  MatButtonModule,
  MatDividerModule,
  MatSidenavModule,
  MatDatepickerModule,
  MatNativeDateModule
];


@NgModule({
  imports: [MaterialComponents],
  exports:[MaterialComponents]
})
export class MaterialModule { }
