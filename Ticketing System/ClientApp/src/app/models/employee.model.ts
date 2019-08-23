import { Office } from './office.model';

export interface Employee {
    employeeID: string;
    firstName: string;
    lastName: string;
    fullName: string;
    emailAddress: string;
    officeid: string;
    office: Office;

}
