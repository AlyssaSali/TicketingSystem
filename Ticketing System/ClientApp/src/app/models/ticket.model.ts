import { Employee } from './employee.model';
import { Office } from './office.model';


export interface Ticket {
    ticketid: number,
    requestedBy: string,
    date: string,
    time: string,
    requestTitle: string,
    requestDesc: string,

    //dummyinputs
    employeeID: string,
    employee: Employee,
    officeid: number,
    office: Office
}
