import { Employee } from './employee.model';
import { Office } from './office.model';
import { CategoryList } from './categoryList.model';


export interface TicketMinor {
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
    dateAccomplished: string;
}
