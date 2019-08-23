import { Severity } from './severity.model';
import { Category } from './category.model';
import { Itgroup } from './itgroup.model';

export interface CategoryList {
    categoryListid: string;
    categoryListName: string;
    slaResponseTime: number;
    slaResponseTimeExt: string;
    slaResolvedTime:  number;
    slaResolvedTimeExt:  string;
    categoryType: string;
    categoryid:string;
    category: Category;
    severityid: string;
    severity: Severity;
    itGroupid: string;
    itGroup: Itgroup[];
}
