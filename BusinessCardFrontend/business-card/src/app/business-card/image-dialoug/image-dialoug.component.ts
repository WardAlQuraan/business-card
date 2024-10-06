import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-image-dialoug',
  templateUrl: './image-dialoug.component.html',
  styleUrls: ['./image-dialoug.component.scss']
})
export class ImageDialougComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: { base64: string }) {}

  ngOnInit(): void {
  }

}
