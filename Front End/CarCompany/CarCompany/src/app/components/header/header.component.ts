import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {


  id:number;

  constructor( private route: ActivatedRoute,
    private router: Router) { }




  ngOnInit(): void {
  }

  onSubmit() {
    console.log(this.id);
    this.router.navigateByUrl(`/dealers/${this.id}`);
  }

}
