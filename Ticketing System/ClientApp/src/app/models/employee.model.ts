import { Office } from './office.model';
<<<<<<< HEAD
import { EmployeeType } from './employeetype.model';


=======
<<<<<<< HEAD
import { EmployeeType } from './employeetype.model';
=======
import { Itgroupmember } from './itgroupmember.model';
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4

export interface Employee {
    employeeID: string;
    firstName: string;
    lastName: string;
<<<<<<< HEAD
    formOfCommu: string;
    contactInfo: string;
=======
<<<<<<< HEAD
    formOfCommu: string;
    contactInfo: string;
    employeeTypeid: number;
    employeeType: EmployeeType;
    officeid: number;
=======
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
    fullName: string;
    officeid: string;
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
    office: Office;
    // employeeTypeid: string;
    // employeeType: EmployeeType;


}
