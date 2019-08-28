import { Office } from './office.model';
import { EmployeeType } from './employeetype.model';



export interface Employee {
    employeeID: string;
    firstName: string;
    lastName: string;
    formOfCommu: string;
    contactInfo: string;
    fullName: string;
    officeid: string;
    office: Office;
    // employeeTypeid: string;
    // employeeType: EmployeeType;


}
