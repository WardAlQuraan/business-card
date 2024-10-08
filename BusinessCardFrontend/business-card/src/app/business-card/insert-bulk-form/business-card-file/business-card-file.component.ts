import { Component, Input, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { IBusinessCard } from '../../models/business-card';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { FileType } from '../../models/fileType';
import { XmlService } from 'src/app/services/xml/xml.service';
import { CsvService } from 'src/app/services/csv/csv.service';
import { SnackbarService } from 'src/app/services/snackbar/snackbar.service';
import { MatDialog } from '@angular/material/dialog';
import { ImageDialougComponent } from '../../image-dialoug/image-dialoug.component';
import { BusinessCardService } from 'src/app/services/business-card/business-card.service';
import { Router } from '@angular/router';
import { QrCodeService } from 'src/app/services/qrCode/qr-code.service';

@Component({
  selector: 'app-business-card-file',
  templateUrl: './business-card-file.component.html',
  styleUrls: ['./business-card-file.component.scss']
})
export class BusinessCardFileComponent implements OnInit, AfterViewInit {

  displayedColumns: string[] = ['name', 'gender', 'dob', 'email', 'phone', 'imagePath'];
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;  // Paginator reference
  dataSource!: MatTableDataSource<IBusinessCard>;
  isLoading = false;
  businessCards!: IBusinessCard[];
  @Input() file!: File | undefined;
  @Input() fileType!: FileType | undefined;

  constructor(
    private router: Router,
    private csvService: CsvService,
    private xmlService: XmlService,
    private qrCodeService:QrCodeService,
    private businessCardService:BusinessCardService,
    private snackbarService: SnackbarService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.fetchData();
  }

  ngAfterViewInit(): void {
    // Assign paginator and sort to dataSource once view is initialized
    if (this.dataSource) {
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    }
  }

  fetchData() {
    debugger;
    if (this.file) {
      this.isLoading = true;
      if (this.fileType === FileType.csv) {
        this.csvService.getBusinessCard(this.file).subscribe(
          res => {
            this.businessCards = res;
            this.dataSource = new MatTableDataSource(this.businessCards);
            this.isLoading = false;
            this.assignPaginator();
          },
          err => {
            this.snackbarService.showError("Can't fetch data");
            this.isLoading = false;
          }
        );
      } else if (this.fileType === FileType.xml) {
        this.xmlService.getBusinessCard(this.file).subscribe(
          res => {
            this.businessCards = res;
            this.dataSource = new MatTableDataSource(this.businessCards);
            this.isLoading = false;
            this.assignPaginator();
          },
          err => {
            this.snackbarService.showError("Can't fetch data");
            this.isLoading = false;
          }
        );
      }else if (this.fileType === FileType.qrCode) {
        this.qrCodeService.getBusinessCard(this.file).subscribe(
          res => {
            this.businessCards =  [res] ;
            this.dataSource = new MatTableDataSource(this.businessCards);
            this.isLoading = false;
            this.assignPaginator();
          },
          err => {
            this.snackbarService.showError("Can't fetch data");
            this.isLoading = false;
          }
        );
      }
    }
  }

  assignPaginator() {
    // Ensure paginator is assigned after data fetch
    if (this.dataSource) {
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    }
  }

  openImageDialog(base64: string): void {
    this.dialog.open(ImageDialougComponent, {
      data: { base64 },
      width: '80%',
    });
  }

  insertBulk() {
    this.isLoading = true;
    this.businessCardService.insertBulk(this.businessCards).subscribe(
      res => {
        this.snackbarService.showSuccess("Inserted successfully");
        this.isLoading = false;
        this.router.navigate(["../"])
      }, err => {
        this.snackbarService.showError("Can't insert");
        this.isLoading = false;
      }
    )
  }
}
