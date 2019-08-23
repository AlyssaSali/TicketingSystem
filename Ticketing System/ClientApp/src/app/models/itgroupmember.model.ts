import { Employee } from './employee.model';
import { Itgroup } from './itgroup.model';

export interface Itgroupmember {
    itGroupMemberid: string;
    employeeID: string;
    employees:Employee[];
    employeerIdList:number[];
    itGroupid: string;
    itgroup: Itgroup;
    // itgroupIdList:number[];
    // itGroupCode:string;
    // itGroupName:string;
   
    
}
