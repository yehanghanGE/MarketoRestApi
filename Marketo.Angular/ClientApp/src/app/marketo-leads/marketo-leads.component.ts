import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-marketo-leads',
  templateUrl: './marketo-leads.component.html',
  styleUrls: ['./marketo-leads.component.css']
})
export class MarketoLeadsComponent {

  public leadAttributes: LeadAttribute[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    http.get<LeadAttribute[]>(baseUrl + 'marketoleads').subscribe(result => {
      this.leadAttributes = result;
    }, error => console.error(error));
  }
}

interface LeadAttribute {
   displayName: string;
   dataType: string;
   id: number;
   length: number;
}
