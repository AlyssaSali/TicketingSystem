import { Employee } from './employee.model';
import { Office } from './office.model';


export interface Ticket {
    ticketid: number,
    //assistByid: number,
    categoryid: number,
    dateRequested: Date;
    formOfCommu: string,
    contactInfo: string,
    requestTitle: string,
    requestDesc: string,
    severity: string,
    responseTime: string,
    resolveTime: string,
    itGroup: string,
    isUrgent: boolean,
    isOpen: boolean,
    trackingStatus: string,

    //dummyinputs
    employeeID: string,
    employee: Employee,
    officeid: number,
    office: Office
}
