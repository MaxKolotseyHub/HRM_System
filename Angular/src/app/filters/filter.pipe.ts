// filter.pipe.ts

import { Pipe, PipeTransform } from '@angular/core';
import { EmployeeDto } from '../models/employeeDto';

@Pipe({ name: 'appFilter' })
export class FilterPipe implements PipeTransform {
    /**
     * Transform
     *
     * @param {any[]} items
     * @param {string} searchText
     * @returns {any[]}
     */
    transform(items: EmployeeDto[], search: string): EmployeeDto[] {
        if (!items) {
            return [];
        }
        if (!search) {
            return items;
        }
        search = search.toLocaleLowerCase();
        console.log(search);

        return items.filter(it => {
            console.log(it.FullName + ' ' + search);

            return it.FullName.toLowerCase().includes(search);
        });
    }
}