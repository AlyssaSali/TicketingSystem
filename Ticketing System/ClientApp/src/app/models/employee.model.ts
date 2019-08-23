import { Office } from './office.model';
import { EmployeeType } from './employeetype.model';

export interface Employee {
    employeeID: string;
    firstName: string;
    lastName: string;
<<<<<<< HEAD
    formOfCommu: string;
    contactInfo: string;
    employeeTypeid: number;
    employeeType: EmployeeType;
    officeid: number;
=======
    fullName: string;
    emailAddress: string;
    officeid: string;
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
    office: Office;

}
