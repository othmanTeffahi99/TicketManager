import { TicketStatus } from "../enums/ticketStatus";

export interface Ticket {
    id: number;
    description: string;
    status: TicketStatus;
    creationDate: string;
  }