import { Office } from './office.model';
import { Itgroupmember } from './itgroupmember.model';

export interface Employee {
    employeeID: string;
    firstName: string;
    lastName: string;
    emailAddress: string;
    fullName: string;
    officeid: number;
    office: Office
    
}
