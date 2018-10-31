import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TodoList } from '../todo-list.model';

@Component({
  selector: 'app-todo-app',
  templateUrl: './todo-app.component.html',
  styleUrls: ['./todo-app.component.css']
})
export class TodoAppComponent implements OnInit {
  selectedList: TodoList;
  todoLists: TodoList[];
  public newList: TodoList = { title: ''};

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get<TodoList[]>('api/todolist')
      .subscribe(lists => this.todoLists = lists);
  }

  selectList(list: TodoList) {
    this.selectedList = list;
  }

  addList() {
    this.http.post<TodoList>('api/todolist', this.newList)
      .subscribe(this.listAdded);
  }

  private listAdded = (list: TodoList) => {
    this.todoLists.push(list);
    this.newList.title = '';
  }

}
