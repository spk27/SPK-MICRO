import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent implements OnInit {
  title = "app";
  ngEl: HTMLElement;
  ngElContainer: HTMLElement;

  ngOnInit() {
    //this.ngEl = document.createElement("ng-el");
    //this.ngElContainer = document.getElementById("ng-container");

    //this.wrapElement();
  }

  wrapElement() {
    if (this.ngElContainer.children.length > 0) {
      this.ngElContainer.removeChild(this.ngElContainer.children[0]);
    }
    this.ngElContainer.appendChild(this.ngEl);
  }
}
