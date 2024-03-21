import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, BrowserModule, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  albums: Array<Album> = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<Array<Album>>('/albums').subscribe((data) => {
      this.albums = data;
    })
  }
}

interface Album {
  id: number,
  name: string
}