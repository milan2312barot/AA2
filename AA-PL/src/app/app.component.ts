import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Observer } from 'rxjs';
import { CategoryService } from './category.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'AA-PL';
  categories;
  categoryById;
  categoryId;
  categoryName;
  buttonPressed = false;
  arr;

  userName:string;
  userEmail:string;
  userPhoto:string;

  constructor(private categoryService: CategoryService){ }

  ngOnInit(){
    this.userName = localStorage.getItem("lsName");
    this.userEmail = localStorage.getItem('lsEmail');
    this.userPhoto = localStorage.getItem('lsPicture');
  }
  GetAllCategories(){
    this.categoryService.getAllCategories().subscribe(data=>{
      if(data){
        this.categories = data;
      }
    });
  }
  GetAllCategoryById(id){
    this.categoryService.getCategoryById(id).subscribe(data=>{
      if(data){
        this.categoryById = data;
      }
    });
  }
  UpdateCategory(id,name){
    const category = {
      "categoryId":id,
      "categoryName":name
     }





    this.categoryService.updateCategory(category).subscribe(data=>{
      if(data){
        this.GetAllCategories();
      }
    });
  }
  DeleteCategory(id){
    this.categoryService.deleteCategory(id).subscribe(data=>{
      if(data){
        this.GetAllCategories();
      }
    });
  }
  AddCategory(categoryName:string){
    const category = {
     "categoryName":categoryName
    }
    this.categoryService.addCategory(category).subscribe(data=>{
      if(data){
        this.GetAllCategories();
      }
    });
  }
}

