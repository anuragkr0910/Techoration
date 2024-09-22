import { Component, OnDestroy } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { CategoryService } from '../services/category.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnDestroy {

  model: AddCategoryRequest;
  private addCategorySubscription?: Subscription;

  constructor(private categoryService: CategoryService, private router: Router, private toastr: ToastrService){
    this.model = {
      name: '',
      urlHandle: ''
    };
  }
  

  onFormSubmit() {
    this.addCategorySubscription = this.categoryService.addCategory(this.model).subscribe({
      next: (response) => {
        console.log("Success");
        this.router.navigate(['/admin/categories']).then(nav => {this.toastr.success("Category added successfully!")})
      },
      error: (err: any) => {
        console.log("Some error occurred");
        this.toastr.error("Some error occured!");
      }
    });
  }


  ngOnDestroy(): void {
    this.addCategorySubscription?.unsubscribe();
  }

}
