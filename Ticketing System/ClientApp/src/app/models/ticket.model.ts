

export interface Ticket {
    ticketid: number,
    assistByid: number,
    categoryid: number,
    date: string,
    time: number,
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
    requestedBy: string,
    office: string,
}
