import { Employee } from './employee.model';
import { Office } from './office.model';
import { CategoryList } from './categoryList.model';


export interface TicketMinor {
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
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
}
