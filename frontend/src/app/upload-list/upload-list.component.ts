import { Component, OnInit } from '@angular/core';
import {FileUploadService} from "../services/file-upload.service";
import {map} from "rxjs";

@Component({
  selector: 'app-upload-list',
  templateUrl: './upload-list.component.html',
  styleUrls: ['./upload-list.component.css']
})
export class UploadListComponent implements OnInit {

  fileUploads: any[];

  constructor(private uploadService: FileUploadService) { }

  ngOnInit(): void {
    this.uploadService.getFiles(6).snapshotChanges().pipe(
      map(changes => changes.map(c => ({key: c.payload.key, ...c.payload.val()}))))
      .subscribe(fileUploads => {
        this.fileUploads = fileUploads;
      })
  }

}
