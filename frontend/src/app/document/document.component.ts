import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.css']
})
export class DocumentComponent implements OnInit {

  DocumentId: number;
  DocumentName: string;
  DocumentContent: string;
  ContentType: string;

  constructor() { }

  ngOnInit(): void {
  }

}
