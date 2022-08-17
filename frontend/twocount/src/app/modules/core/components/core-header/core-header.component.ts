import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

@Component({
  selector: 'tc-core-header',
  templateUrl: './core-header.component.html',
  styleUrls: ['./core-header.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CoreHeaderComponent implements OnInit {

  constructor() { }

  ngOnInit(): void { }

}
