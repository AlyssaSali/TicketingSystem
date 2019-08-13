import { Office } from './office.model';

export interface Employee {
    employeeID: string;
    firstName: string;
    lastName: string;
    emailAddress: string;
    officeid: number;
    office: Office

}
