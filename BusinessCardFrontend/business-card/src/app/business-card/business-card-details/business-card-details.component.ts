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

@Component({
  selector: 'app-business-card-details',
  templateUrl: './business-card-details.component.html',
  styleUrls: ['./business-card-details.component.scss']
})
export class BusinessCardDetailsComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['name', 'gender', 'dob', 'email', 'phone', 'image'];
  dataSource!: MatTableDataSource<IBusinessCard>;
  params!: BusinessCardParams;
  pageIndex = 0;
  pageSize = 10;

  businessCards: IBusinessCard[] = [];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  isLoading = false;

  constructor(private businessCardService: BusinessCardService , private snackBarService:SnackbarService) {}

  ngOnInit(): void {
    this.params = {
      email: null,
      phone: null,
      dob: null,
      gender: null,
      name: null,
      sortColumn: null,
      sortDirection: null,
      image: null
    };
    this.dataSource = new MatTableDataSource(this.businessCards);
    this.getBusinessCards();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator; // Initialize paginator here
    this.dataSource.sort = this.sort; // Initialize sort here
    this.sort.sortChange.subscribe(() => {
      this.pageIndex = 0; // Reset to first page when sorting
      this.getBusinessCards();
    });
  }

  getBusinessCards() {
    this.isLoading = true;
    let params = this.getParamsToSearch();
    this.businessCardService.search(params).subscribe(
      res => {
        this.businessCards = res; // Assigning the response to the businessCards array
        this.dataSource.data = this.businessCards; // Update dataSource with the new data
  
        this.isLoading = false;
      },
      err => {
        this.isLoading = false;
        this.snackBarService.showError(err.message)
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
      sortDirection: this.sort ? this.sort.direction : null
    };
  }

  applyFilter(event: Event | MatSelectChange | MatDatepickerInputEvent<any>, column: keyof IBusinessCard) {
    let filterValue: string | null = null;

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

    if (this.sort && this.sort.active) {
      this.params.sortColumn = this.sort.active;
      this.params.sortDirection = this.sort.direction;
    }
  }

  onPageChange() {
    this.pageIndex = this.paginator.pageIndex;
    this.pageSize = this.paginator.pageSize;
    this.getBusinessCards(); // Fetch new data on page change
  }
}
