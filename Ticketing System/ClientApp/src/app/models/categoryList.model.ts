import { Severity } from './severity.model';
import { Category } from './category.model';

export interface CategoryList {
    categoryListid:number;
    categoryListName: string;
    categoryid:number;
    categoryName: Category;
    severityid: number;
    severityCode: Severity;
    slaResponseTime: number;
    slaResolvedTime:  number;
    itGroup: string;
}
