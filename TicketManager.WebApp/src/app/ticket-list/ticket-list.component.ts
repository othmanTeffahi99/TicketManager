import { Component, OnInit } from '@angular/core';

import { TicketFormComponent } from '../ticket-form/ticket-form.component';
import { Ticket } from '../common/models/ticket.model';
import { TicketService } from '../ticket.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TicketStatus } from '../common/enums/ticketStatus';

@Component({
  selector: 'app-ticket-list',
  standalone: false,
  templateUrl: './ticket-list.component.html',
  styleUrl: './ticket-list.component.css'
})

export class TicketListComponent implements OnInit {
  
  currentPage = 0;
  pageSize = 10;
  totalItems = 0;

  tickets: Ticket[] = [];
  filteredTickets: Ticket[] = [];
  searchTerm: string = '';
  sortColumn: SortableColumn = 'id';
  sortDirection: 'asc' | 'desc' = 'asc';

  constructor(
    private ticketService: TicketService,
    private modalService: NgbModal
  ) {}

  ngOnInit() {
    this.currentPage = 0;
    this.pageSize = 10;
    this.filteredTickets = [];
    this.searchTerm = '';
    this.loadTickets();
  }

  loadTickets() {
    this.ticketService.getTickets(this.currentPage , this.pageSize).subscribe(
      (tickets: Ticket[]) => {
        this.tickets = tickets;
        this.applyFilter();
      },
      error => console.error('Error loading tickets:', error)
    );
  }

  openTicketForm(ticket?: Ticket) {
    const modalRef = this.modalService.open(TicketFormComponent);
    modalRef.componentInstance.ticket = ticket || {} as Ticket;
    modalRef.result.then((result) => {
      if (result) {
        this.loadTickets();
      }
    }).catch((error) => {});
  }

  deleteTicket(id: number) {
    if (confirm('Are you sure you want to delete this ticket?')) {
      this.ticketService.deleteTicket(id).subscribe(
        () => {
          this.loadTickets();
        },
        error => console.error('Error deleting ticket:', error)
      );
    }
  }

  applyFilter() {
    this.filteredTickets = this.tickets.filter(ticket =>
      ticket.id.toString().includes(this.searchTerm) ||
      ticket.description.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      this.getStatusString(ticket.status).toLocaleLowerCase().includes(this.searchTerm.toLowerCase()) 
    );
    this.sort(this.sortColumn);
  }
  
  getStatusString(status: TicketStatus): string {
    return TicketStatus[status];
  }
  sort(column: SortableColumn) {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'asc';
    }

    this.filteredTickets.sort((a, b) => {
      let aValue = a[column];
      let bValue = b[column];

      if (column === 'status') {
        aValue = this.getStatusString(a.status);
        bValue = this.getStatusString(b.status);
      }
      if (aValue < bValue) return this.sortDirection === 'asc' ? -1 : 1;
      if (aValue > bValue) return this.sortDirection === 'asc' ? 1 : -1;
      return 0;
    });
  }

  getDate(dateString: string): Date {
    return new Date(dateString);
  }

  getSortIcon(column: SortableColumn): string {
    if (this.sortColumn === column) {
      return this.sortDirection === 'asc' ? 'bi-arrow-up' : 'bi-arrow-down';
    }
    return '';
  }

  onPageChange(page: number): void {
    console.log(page);
    this.currentPage = page;
    this.loadTickets();
  }
}
type SortableColumn = 'id' | 'description' | 'status' | 'creationDate';