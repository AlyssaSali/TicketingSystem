import { Office } from './office.model';
import { Itgroupmember } from './itgroupmember.model';

export interface Employee {
    employeeID: string;
    firstName: string;
    lastName: string;
    fullName: string;
    emailAddress: string;
<<<<<<< HEAD
    fullName: string;
    officeid: number;
    office: Office
    
=======
    officeid: string;
    office: Office;

>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
}
