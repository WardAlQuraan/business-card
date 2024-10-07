import { FileType } from "./fileType";

export interface BusinessCardParams{
    id?: string | null;
    name?: string | null;
    gender?: string| null;
    dob?: string| null; 
    email?: string| null;
    phone?: string| null;
    image?: string | null;
    sortColumn?: string | null;
    sortDirection?: string | null; 
    base64?: string | null;
    fileType:FileType | null;
}