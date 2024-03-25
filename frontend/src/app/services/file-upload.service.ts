import { Injectable } from '@angular/core';
import {AngularFireDatabase, AngularFireList} from "@angular/fire/compat/database";
import {AngularFireStorage} from "@angular/fire/compat/storage";
import {FileUpload} from "../models/file-upload.model";
import {finalize, Observable} from "rxjs";
import firebase from "firebase/compat";


@Injectable({
  providedIn: 'root'
})
export class FileUploadService {
  private basePath = '/uploads';
  urlLink: Observable<any>;

  constructor(private db: AngularFireDatabase, private storage: AngularFireStorage) { }

  pushFilesToStorage(fileUpload: FileUpload): Observable<number>{
    const filePath = `${this.basePath}/${fileUpload.file.name}`;
    const storageRef = this.storage.ref(filePath);
    const uploadTask = this.storage.upload(filePath, fileUpload.file);



    uploadTask.snapshotChanges().pipe(
      finalize(() => this.urlLink = storageRef.getDownloadURL())
    );

    return uploadTask.percentageChanges();
  }

  private saveFileData(fileUpload: FileUpload) {

    this.db.list(this.basePath).push({title: fileUpload.file.name});
  }

  getFiles(numberItems): AngularFireList<FileUpload>{
    return this.db.list(this.basePath, ref =>
    ref.limitToLast(numberItems));
  }

  deleteFile(fileUpload: FileUpload) {
    this.deleteFileDatabase(fileUpload.key)
      .then(() => {
        this.deleteFileStorage(fileUpload.name);
      })
      .catch(error => console.log(error));

  }

  private deleteFileDatabase(key: string): Promise<void>{
    return this.db.list(this.basePath).remove(key);
  }

  private deleteFileStorage(name: string) {
    const storageRef = this.storage.ref(this.basePath);
    storageRef.child(name).delete();
  }
}
