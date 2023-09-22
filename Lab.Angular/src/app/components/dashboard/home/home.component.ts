import { AfterViewInit, Component, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { CategoryServiceService } from '../../service/category.service.service';
import { CategoriesModel } from 'src/app/core/Models/Categories_models';
import { CategoryDto } from 'src/app/core/Models/CategoryDto';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements AfterViewInit {
    displayedColumns: string[] = ['CategoryID', 'CategoryName', 'Description', 'botones'];
    dataSource: MatTableDataSource<CategoryDto>;

    listCategories:CategoriesModel[] = [];

    @ViewChild(MatPaginator) paginator!: MatPaginator;

    constructor (private _categoryService: CategoryServiceService) {
      this.dataSource = new MatTableDataSource<CategoryDto>([]);
    }

    ngOnInit(): void {
      this.getAllCategories();
    }

    ngAfterViewInit() {
      this.dataSource.paginator = this.paginator;
    }

    applyFilter(event: Event) {
      const filterValue = (event.target as HTMLInputElement).value;
      this.dataSource.filter = filterValue.trim().toLowerCase();
    }

    editUser(userName: string) {
      //console.log('Edit: ', userName);
    }

    deleteUser(userName: string) {
      //console.log('Delete: ', userName);
    }

    getAllCategories() {
      this._categoryService.getAllCategories().subscribe({
        next: (resultado: CategoryDto[]) => {
            this.dataSource = new MatTableDataSource<CategoryDto>(resultado);
        },
        error: (e) => { console.log(e); },
      });
  }
}