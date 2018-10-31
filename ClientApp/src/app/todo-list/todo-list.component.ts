import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TodoList } from '../todo-list.model';

@Component({
  selector: 'todo-list',
  templateUrl: 'todo-list.component.html',
  styleUrls: ['todo-list.component.css']
})

export class TodoListComponent implements OnChanges {
  public tasks: Task[];
  public newTask: Task = { title: '' };

  @Input() public list: TodoList;

  constructor(private http: HttpClient) { }

  ngOnChanges(changes: SimpleChanges) {
    if (changes.list) {
      this.getTasks();
    }
  }

  addTask() {
    let listTask: Task = {
      ...this.newTask,
      todoListId: this.list.id
    };

    this.http.post<Task>('api/tasks', listTask)
      .subscribe(this.taskAdded);
  }

  toggleTask(task: Task) {
    task.isDone = !task.isDone;
    this.http
      .put(`api/tasks/${task.id}`, task)
      .subscribe()
  }

  private getTasks() {
    let params = { listId: '' + this.list.id };

    this.http.get<Task[]>('api/tasks', { params })
      .subscribe(tasks => this.tasks = tasks);
  }

  private taskAdded = (task: Task) => {
    this.tasks.push(task);
    this.newTask.title = '';
  }
}

interface Task {
  id?: number;
  title: string;
  isDone?: boolean;
  todoListId?: number;
}
