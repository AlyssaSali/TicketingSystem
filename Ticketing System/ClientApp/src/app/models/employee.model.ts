import { Office } from './office.model';
<<<<<<< HEAD
import { EmployeeType } from './employeetype.model';
=======
import { Itgroupmember } from './itgroupmember.model';
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad

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
<<<<<<< HEAD
    fullName: string;
    officeid: number;
    office: Office
    
=======
    officeid: string;
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
    office: Office;

>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
}
