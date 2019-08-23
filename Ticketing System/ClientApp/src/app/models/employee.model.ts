import { Office } from './office.model';
import { EmployeeType } from './employeetype.model';
import { Itgroupmember } from './itgroupmember.model';

export interface Employee {
    employeeID: string;
    firstName: string;
    lastName: string;
    formOfCommu: string;
    contactInfo: string;
    employeeTypeid: number;
    employeeType: EmployeeType;
    fullName: string;
    officeid: string;
    office: Office;
}
