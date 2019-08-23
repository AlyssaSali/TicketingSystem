import { Employee } from './employee.model';
import { Office } from './office.model';
import { CategoryList } from './categoryList.model';


export interface TicketMinor {
<<<<<<< HEAD
    ticketMinorid: number,
    assistByid: number,
    categoryid: number,
    requestDesc: string,
    dateRequested: Date,
    itStaff: string,
    isOpen: boolean,
    //dummyinputs
    requestedBy: string,
    office: string,
=======
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
