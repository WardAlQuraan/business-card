import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { IBusinessCard } from '../models/business-card';
import { BusinessCardParams } from '../models/business-card-params';
import { MatSelectChange } from '@angular/material/select';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { BusinessCardService } from 'src/app/services/business-card/business-card.service';
import { SnackbarService } from 'src/app/services/snackbar/snackbar.service';
import { environment } from 'src/environments/environment';
import { MatDialog } from '@angular/material/dialog';
import { ImageDialougComponent } from '../image-dialoug/image-dialoug.component';
import { DeleteBusinessCardDialogComponent } from '../delete-business-card-dialog/delete-business-card-dialog.component';
import { FileType } from '../models/fileType';

@Component({
  selector: 'app-business-card-details',
  templateUrl: './business-card-details.component.html',
  styleUrls: ['./business-card-details.component.scss']
})
export class BusinessCardDetailsComponent implements OnInit {
  displayedColumns: string[] = ['name', 'gender', 'dob', 'email', 'phone', 'imagePath', 'qr-code' ,'delete' ];
  dataSource!: MatTableDataSource<IBusinessCard>;
  params!: BusinessCardParams;
  pageIndex = 0;
  pageSize = 10;
  count = 0;
  host = environment.host;

  businessCards: IBusinessCard[] = [];
  @ViewChild(MatSort) sort!: MatSort;

  isLoading = false;

  constructor(
    private businessCardService: BusinessCardService,
    private snackBarService: SnackbarService,
    private dialog: MatDialog) { 
      this.dataSource = new MatTableDataSource();
      debugger;
    }

  ngOnInit(): void {
    this.params = {
      email: null,
      phone: null,
      dob: null,
      gender: null,
      name: null,
      sortColumn: null,
      sortDirection: null,
      fileType: null
    };
    this.getBusinessCards();
  }


  getBusinessCards() {
    this.isLoading = true;
    const params = this.getParamsToSearch();
  
    this.businessCardService.search(params).subscribe(
      res => {
        this.businessCards = res.data; 
        this.dataSource = new MatTableDataSource(this.businessCards);
        this.dataSource.sort = this.sort; 
        this.pageIndex = res.pageIndex;
        this.pageSize = res.pageSize;
        
        // Ensure `count` is updated correctly
        this.count = res.count; // Total count for paginator
        console.log("Total Count:", this.count); // Log the count for debugging
  
        this.isLoading = false;
      },
      err => {
        this.isLoading = false;
        this.snackBarService.showError(err.message);
      }
    );
  }
  

  getParamsToSearch() {
    return {
      name: this.params.name,
      gender: this.params.gender,
      dob: this.params.dob,
      email: this.params.email,
      phone: this.params.phone,
      pageIndex: this.pageIndex,
      pageSize: this.pageSize,
      sortColumn: this.sort ? this.sort.active : null,
      sortDirection: this.sort ? this.sort.direction : null,
      fileType : this.params.fileType
    };
  }

  sortTable(event:any){
      this.sort.active = event.active;
      this.sort.direction = event.direction;
      this.getBusinessCards();
  }

  applyFilter(event: Event | MatSelectChange | MatDatepickerInputEvent<any>, column: keyof IBusinessCard) {
    let filterValue: string | null = null;
    debugger;

    if (event instanceof MatSelectChange) {
      filterValue = event.value;
    } else if (event instanceof MatDatepickerInputEvent) {
      if (event.value) {
        const utcDate = new Date(Date.UTC(
          event.value.getUTCFullYear(),
          event.value.getUTCMonth(),
          event.value.getUTCDate()
        ));
        filterValue = utcDate.toISOString();
      } else {
        filterValue = null;
      }
    } else if ((event as any).target && (event.target as HTMLInputElement).value) {
      filterValue = (event.target as HTMLInputElement).value.trim().toLowerCase();
    }

    this.params[column] = filterValue;

    
  }

  onPageChange(event:any) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.getBusinessCards();
  }

  onDelete(id: any): void {
    const dialogRef = this.dialog.open(DeleteBusinessCardDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.isLoading = true;
        this.businessCardService.delete(id).subscribe(res => {
          if (res) {
            this.snackBarService.showSuccess("Deleted successfully");
          } else {
            this.snackBarService.showError("Can't delete");
          }
          this.isLoading = false;
          this.getBusinessCards();
        }, err => {
          this.snackBarService.showError("Can't delete");
          this.isLoading = false;
        });
      }
    });
  }

  openImageDialog(base64: string): void {
    this.dialog.open(ImageDialougComponent, {
      data: { base64 },
      width: '80%',
    });
  }


  exportToXml() { 
    this.params.fileType = FileType.xml;
    this.businessCardService.export(this.params).subscribe(response => {
      const blob = new Blob([response], { type: 'application/xml' });
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = 'businessCards.xml';
      a.click();
      window.URL.revokeObjectURL(url);
    });
  }
  exportToCsv() { 
    this.params.fileType = FileType.csv;
    
    this.businessCardService.export(this.params).subscribe(response => {
      const blob = new Blob([response], { type: 'text/csv' });
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = 'businessCards.csv';
      a.click();
      window.URL.revokeObjectURL(url);
    });
  }

  generateQrCode(businessCard:IBusinessCard) { 
    
    this.businessCardService.generateQrCode(businessCard).subscribe(response => {
      const blob = new Blob([response]);
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = `qr-code(${businessCard.name}).png`;
      a.click();
      window.URL.revokeObjectURL(url);
    },err=>{
      this.snackBarService.showError("Can't Generate Qr code")
    });
  }

}
