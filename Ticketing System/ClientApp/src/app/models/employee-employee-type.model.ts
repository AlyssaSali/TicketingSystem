import { Employee } from './employee.model';
import { EmployeeType } from './employeetype.model';

export interface EmployeeEmployeeType {
    employeeEmployeeTypeid: string;
    employeeID: string;
    employees:Employee[];
    employeerIdList:number[];
    employeeTypeid: string;
    employeeType: EmployeeType;
}
