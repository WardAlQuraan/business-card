import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  isCollapsed = false; // Track sidebar state
  isToggled = false;
  constructor() { }

  ngOnInit(): void {
  }

  toggleSidebar() {
    this.isToggled = !this.isToggled; // Toggle the state
    const body = document.body; // Reference to the body element
    const sidebar = document.querySelector('.sidebar'); // Reference to the sidebar element

    if (this.isToggled) {
      body.classList.add('sidebar-toggled'); // Add class to body
      if (sidebar) {
        sidebar.classList.add('toggled'); // Add class to sidebar
      }
    } else {
      body.classList.remove('sidebar-toggled'); // Remove class from body
      if (sidebar) {
        sidebar.classList.remove('toggled'); // Remove class from sidebar
      }
    }
  }

  get toggleIcon(): string {
    return this.isCollapsed ? 'chevron_right' : 'chevron_left'; // Change icon based on state
  }


}
