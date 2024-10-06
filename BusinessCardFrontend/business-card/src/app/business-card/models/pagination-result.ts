export interface IPaginationResult<T>{
    data: T[];
    count:number;
    pageSize:number;
    pageIndex:number;
}