import { Employee } from './employee.model';
import { Office } from './office.model';
import { CategoryList } from './categoryList.model';


export interface TicketMinor {
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD

    assistByid: number
=======
<<<<<<< HEAD
    ticketMinorid: number,
    assistByid: number,
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
    categoryid: number,
    requestDesc: string,
    dateRequested: Date,
    itStaff: string,
    isOpen: boolean,
    //dummyinputs
    requestedBy: string,
<<<<<<< HEAD
=======
    office: string,
=======
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
    ticketMinorid: string;
    agentid: number,
    description: string,
    status: string,
    workDone: string,
    dateOfRequest: string,
    timeOfRequest: string,
    officeid: string;
    office: Office;
    requesterid: string;
    workByid: string;
    employee: Employee;
    categoryListid: string;
    categoryList: CategoryList;
<<<<<<< HEAD
=======
    dateAccomplished: string;
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
}
