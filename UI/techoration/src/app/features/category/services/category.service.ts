import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { Observable } from 'rxjs';
import { Category } from '../models/category.model';
import { environment } from 'src/environments/environment';
import { UpdateCategoryRequest } from '../models/update-category-request.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  addCategory(model: AddCategoryRequest): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseURL}/api/Categories`, model);
  }

  getAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${environment.apiBaseURL}/api/Categories`);
  }

  getCategoryById(id: string): Observable<Category> {
    return this.http.get<Category>(`${environment.apiBaseURL}/api/Categories/${id}`);
  }

  updateCategory(id: string, model: UpdateCategoryRequest): Observable<void> {
    return this.http.put<void>(`${environment.apiBaseURL}/api/Categories/${id}`, model);
  }
}
