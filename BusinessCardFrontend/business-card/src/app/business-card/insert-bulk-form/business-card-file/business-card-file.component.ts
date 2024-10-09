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
import { BusinessCardService } from 'src/app/services/business-card/business-card.service';
import { Router } from '@angular/router';
import { QrCodeService } from 'src/app/services/qrCode/qr-code.service';
import { ImageDialougComponent } from '../../image-dialoug/image-dialoug.component';

@Component({
  selector: 'app-business-card-file',
  templateUrl: './business-card-file.component.html',
  styleUrls: ['./business-card-file.component.scss']
})
export class BusinessCardFileComponent implements OnInit, AfterViewInit {

  displayedColumns: string[] = ['name', 'gender', 'dob', 'email', 'phone', 'imagePath'];
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  dataSource!: MatTableDataSource<IBusinessCard>;
  businessCards!: IBusinessCard[];
  isLoading = false;
  @Input() file!: File | undefined;
  @Input() fileType!: FileType | undefined;

  constructor(
    private router: Router,
    private csvService: CsvService,
    private xmlService: XmlService,
    private qrCodeService: QrCodeService,
    private businessCardService: BusinessCardService,
    private snackbarService: SnackbarService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.fetchData();
  }

  ngAfterViewInit(): void {
    this.assignPaginator();
  }

  fetchData() {
    if (!this.file) return;
    this.isLoading = true;

    if (this.fileType === FileType.csv) {
      this.csvService.getBusinessCard(this.file).subscribe(
        (res: IBusinessCard[]) => {  // CSV returns an array
          this.initializeDataSource(res);
        },
        () => {
          this.errorFetch()
        }
      );
    } else if (this.fileType === FileType.xml) {
      this.xmlService.getBusinessCard(this.file).subscribe(
        (res: IBusinessCard[]) => {  
          this.initializeDataSource(res);
        },
        () => {
          this.errorFetch();
        }
      );
    } else if (this.fileType === FileType.qrCode) {
      this.qrCodeService.getBusinessCard(this.file).subscribe(
        (res: IBusinessCard) => {  
          this.initializeDataSource([res]);
        },
        () => {
          this.errorFetch();
        }
      );
    }
  }

  errorFetch() {
    this.snackbarService.showError("Can't fetch data");
    this.isLoading = false;
  }

  initializeDataSource(businessCards:IBusinessCard[]) {
    this.businessCards = businessCards;
    this.dataSource = new MatTableDataSource(this.businessCards);
    this.assignPaginator();
    this.isLoading = false;
  }



  assignPaginator() {
    if (this.dataSource) {
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    }
  }

  openImageDialog(base64: string): void {
    this.dialog.open(ImageDialougComponent, { data: { base64 }, width: '80%' });
  }

  insertBulk() {
    this.isLoading = true;
    this.businessCardService.insertBulk(this.businessCards).subscribe(
      () => {
        this.snackbarService.showSuccess("Inserted successfully");
        this.isLoading = false;
        this.router.navigate(["../"]);
      },
      () => {
        this.snackbarService.showError("Can't insert");
        this.isLoading = false;
      }
    );
  }
}
