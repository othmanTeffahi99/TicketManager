import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Ticket } from '../common/models/ticket.model';
import { TicketService } from '../ticket.service';
import { TicketStatus } from '../common/enums/ticketStatus';



@Component({
  selector: 'app-ticket-form',
  templateUrl: './ticket-form.component.html',
  styleUrls: ['./ticket-form.component.css']
})
export class TicketFormComponent implements OnInit {
  @Input() ticket!: Ticket;
  ticketForm!: FormGroup;
  statusOptions = [
    { value: TicketStatus.open, label: 'Open' },
    { value: TicketStatus.Closed, label: 'Closed' }
  ];


  constructor(
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private ticketService: TicketService
  ) { }

  ngOnInit(): void {
    this.ticketForm = this.formBuilder.group({
      description: [this.ticket.description || '', Validators.required],
      status: [this.ticket.status || TicketStatus.open , Validators.required],
      creationDate: [this.ticket.creationDate || new Date().toISOString().split('T')[0], Validators.required]
    });
  }

  onSubmit(): void {
    if (this.ticketForm.valid) {
      const ticketData = { ...this.ticket, ...this.ticketForm.value };
      if (this.ticket.id) {
        this.ticketService.updateTicket(ticketData).subscribe(
          () => this.activeModal.close(true),
          error => console.error('Error updating ticket:', error)
        );
      } else {
        this.ticketService.createTicket(ticketData).subscribe(
          () => this.activeModal.close(true),
          error => console.error('Error creating ticket:', error)
        );
      }
    }
  }

  getStatusString(status: TicketStatus): string {
    return TicketStatus[status];
  }
  close(): void {
    this.activeModal.dismiss();
  }
}