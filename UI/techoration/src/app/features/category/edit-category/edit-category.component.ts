import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CategoryService } from '../services/category.service';
import { Category } from '../models/category.model';
import { UpdateCategoryRequest } from '../models/update-category-request.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit, OnDestroy {

  id: string | null = null;
  paramsSubscription?: Subscription;
  editCategorySubscription?: Subscription;
  category?: Category;

  constructor(private route: ActivatedRoute, private categoryService: CategoryService, private router: Router, private toastr: ToastrService) {

  }
  
  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');
        if (this.id) {
          // Get the data for this id from API
          this.categoryService.getCategoryById(this.id).subscribe({
            next: (response) => {
              this.category = response;
            }
          })
        }
      },
    });
  }


  onFormSubmit(): void {
    const model: UpdateCategoryRequest = {
      name: this.category?.name ?? '',
      urlHandle: this.category?.urlHandle ?? ''
    };

    if (this.id) {
      this.editCategorySubscription = this.categoryService.updateCategory(this.id, model).subscribe({
        next: (response) => {
          console.log("Success");
          this.router.navigate(['/admin/categories']).then(nav => {this.toastr.success("Category updated successfully!")})
        },
        error: (err: any) => {
          console.log("Some error occurred");
          this.toastr.error("Some error occured!");
        }
      });
    }
  }

  
  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe;
    this.editCategorySubscription?.unsubscribe;
  }
}
