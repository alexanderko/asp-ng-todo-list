import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'todo-list',
  templateUrl: 'todo-list.component.html'
})

export class TodoListComponent implements OnInit {
  public tasks: Task[];
  public newTask: Task = { title: '' };

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http
      .get<Task[]>('api/tasks')
      .subscribe(tasks => this.tasks = tasks);
  }

  addTask() {
    this.http
      .post<Task>('api/tasks', this.newTask)
      .subscribe(this.taskAdded);
  }

  private taskAdded = (task: Task) => {
    this.tasks.push(task);
    this.newTask.title = '';
  }
}

interface Task {
  title: string;
  isDone?: boolean;
}
