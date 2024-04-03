import {Identity} from "./identity";

export interface Customer {
    id: string;
    names: string;
    lastNames: string;
    email: string;
    identity: Identity;
    salary: number;
    phoneNumber: string;
    civilStatus: string;
}

