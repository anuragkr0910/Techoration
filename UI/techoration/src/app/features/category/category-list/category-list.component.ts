import { Component, OnDestroy, OnInit } from '@angular/core';
import { CategoryService } from '../services/category.service';
import { Category } from '../models/category.model';
import { ToastrService } from 'ngx-toastr';
import { isEmpty, Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit, OnDestroy {
  categoryListSubscription?: Subscription;
  categories?: Category[];

  constructor(private categoryService: CategoryService, private toastr: ToastrService) {

  }
  

  ngOnInit(): void {

    this.categoryListSubscription = this.categoryService.getAllCategories().subscribe({
      next: (response) => {
        this.categories = response;
        if (this.categories == null) {
          this.toastr.success("Database Connection Successful! List is empty.")
        } else {
          this.toastr.success("List Updated Successfully!");
        }        
      },
      error: (err: any) => {
        this.toastr.error("Something went wrong! List not updated.");
      }
    })
  }
  

  ngOnDestroy(): void {
    this.categoryListSubscription?.unsubscribe();
  }

}
