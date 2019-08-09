

export interface Ticket {
    id: number,
    myGuid: number,
    assistById: number,
    policyId: number,
    date: string,
    time: number,
    formOfCommu: string,
    emailAddress: string,
    requestTitle: string,
    requestDesc: string,
    severity: string,
    responseTime: string,
    resolveTime: string,
    technician: string,
    isUrgent: boolean,
    isOpen: boolean,
    trackingStatus: string,

    //dummyinputs
    requestedBy: string,
    office: string,
    requestCategory: string,
    requestSubCategory: string,
}
