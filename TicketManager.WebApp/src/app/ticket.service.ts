import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ticket } from './common/models/ticket.model';


@Injectable({
  providedIn: 'root'
})
export class TicketService {
  private apiUrl = 'api/tickets'; // Adjust this to match your API endpoint

  constructor(private http: HttpClient) { }

  getTickets(page: number, pageSize: number): Observable<any> {
   
    return this.http.get<any>(`${this.getUrl()}?pageNumber=${page}&pageSize=${pageSize}`);
  }

  getTicket(id: number): Observable<Ticket> {
    return this.http.get<Ticket>(`${this.getUrl()}/${id}`);
  }

  createTicket(ticket: Ticket): Observable<Ticket> {
    return this.http.post<Ticket>(this.getUrl(), { description: ticket.description, status: ticket.status});
  }

  updateTicket(ticket: Ticket): Observable<Ticket> {
    return this.http.put<Ticket>(`${this.getUrl()}`, { id:ticket.id  ,description: ticket.description, status: ticket.status});
  }

  deleteTicket(id: number): Observable<void> {
    return this.http.delete<void>(`${this.getUrl()}/${id}`);
  }


  private getUrl() : string{
     return `http://localhost:5014/${this.apiUrl}`;
  }

}