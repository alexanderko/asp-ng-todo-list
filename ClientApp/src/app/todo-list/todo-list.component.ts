import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'todo-list',
  templateUrl: 'todo-list.component.html'
})

export class TodoListComponent implements OnInit {
  public tasks: Task[];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http
      .get<Task[]>('api/tasks')
      .subscribe(tasks => this.tasks = tasks);
  }
}

interface Task {
  title: string;
  isDone: boolean;
}
