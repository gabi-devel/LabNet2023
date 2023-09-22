import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryDto } from 'src/app/core/Models/CategoryDto';
import { Environment } from 'src/app/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryServiceService {
  apiUrl: string=Environment.apiLab;

  constructor(private http: HttpClient) { }

  getAllCategories(): Observable<CategoryDto[]> {
    let url = `${this.apiUrl}CategoriesApi`;
    return this.http.get<CategoryDto[]>(url);
  }
}
