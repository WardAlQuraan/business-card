import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatSelectChange } from '@angular/material/select';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { MatDialog } from '@angular/material/dialog';
import { IBusinessCard } from '../models/business-card';
import { BusinessCardParams } from '../models/business-card-params';
import { BusinessCardService } from 'src/app/services/business-card/business-card.service';
import { SnackbarService } from 'src/app/services/snackbar/snackbar.service';
import { environment } from 'src/environments/environment';
import { ImageDialougComponent } from '../image-dialoug/image-dialoug.component';
import { DeleteBusinessCardDialogComponent } from '../delete-business-card-dialog/delete-business-card-dialog.component';
import { FileType } from '../models/fileType';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-business-card-details',
  templateUrl: './business-card-details.component.html',
  styleUrls: ['./business-card-details.component.scss']
})
export class BusinessCardDetailsComponent implements OnInit {
  displayedColumns = ['id', 'name', 'gender', 'dob', 'email', 'phone', 'imagePath', 'qr-code', 'delete'];
  dataSource = new MatTableDataSource<IBusinessCard>();
  params: BusinessCardParams = { name: null, gender: null, dob: null, email: null, phone: null, sortColumn: null, sortDirection: null, fileType: null };
  pageIndex = 0;
  pageSize = 10;
  count = 0;
  host = environment.host;
  isLoading = false;
  businessCards: IBusinessCard[] = [];

  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private businessCardService: BusinessCardService,
    private snackBarService: SnackbarService,
    private dialog: MatDialog,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {
    this.getBusinessCards();
  }

  getBusinessCards() {
    this.isLoading = true;
    this.businessCardService.search(this.getParamsToSearch()).subscribe(
      res => {
        this.businessCards = res.data;
        this.dataSource.data = this.businessCards;
        this.dataSource.sort = this.sort;
        this.count = res.count;
        this.isLoading = false;
      },
      err => {
        this.snackBarService.showError(err.message);
        this.isLoading = false;
      }
    );
  }

  clearDob() {
    this.params.dob = null;  // Reset DOB field to null
  }
  
  getParamsToSearch() {

    let paramsToSearch = 
    {
      ...this.params,
      pageIndex: this.pageIndex,
      pageSize: this.pageSize,
      sortColumn: this.sort?.active,
      sortDirection: this.sort?.direction
    };
    if (paramsToSearch.dob) {
      paramsToSearch.dob = this.datePipe.transform(this.params.dob, 'dd/MM/yyyy');
    }
    return paramsToSearch;  
  }

  sortTable(event: any) {
    this.sort.active = event.active;
    this.sort.direction = event.direction;
  
    this.getBusinessCards();
  }
  

  onPageChange(event: any) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.getBusinessCards();
  }

  onDelete(id: any): void {
    const dialogRef = this.dialog.open(DeleteBusinessCardDialogComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.businessCardService.delete(id).subscribe(() => {
          this.snackBarService.showSuccess("Deleted successfully");
          this.getBusinessCards();
        }, err => this.snackBarService.showError("Can't delete"));
      }
    });
  }

  openImageDialog(base64: string) {
    this.dialog.open(ImageDialougComponent, { data: { base64 }, width: '80%' });
  }

  exportToXml() {
    this.exportFile(FileType.xml, 'businessCards', 'xml');
  }

  exportToCsv() {
    this.exportFile(FileType.csv, 'businessCards', 'csv');
  }

  exportFile(fileType: FileType, fileName: string, extension: string) {
    this.params.fileType = fileType;
    this.businessCardService.export(this.params).subscribe(response => {
      const blob = new Blob([response], { type: fileType === FileType.xml ? 'application/xml' : 'text/csv' });
      this.downloadFile(blob, fileName, extension);
    });
  }

  generateQrCode(businessCard: IBusinessCard) {
    this.businessCardService.generateQrCode(businessCard).subscribe(response => {
      const blob = new Blob([response], { type: 'image/png' });
      this.downloadFile(blob, `qr-code(${businessCard.name})`, 'png');
    }, () => this.snackBarService.showError("Can't generate QR code"));
  }

  downloadFile(blob: Blob, fileName: string, extension: string) {
    const url = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = `${fileName}.${extension}`;
    a.click();
    window.URL.revokeObjectURL(url);
  }
}
