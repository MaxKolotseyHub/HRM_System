import { AbstractControl, ValidatorFn } from "@angular/forms";
import { JobDto } from "../models/jobs/jobDto";

export function passwordValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const password = control.get('Password');
    const confirmPassword = control.get('ConfirmPassword');

    if (password.pristine || confirmPassword.pristine) {
        return null;
    }

    return password && confirmPassword && password.value != confirmPassword.value ? { 'misMatch': true } : null;
}

export function passwordLengthValidator(length: number): ValidatorFn {

    return (control: AbstractControl): { [key: string]: boolean } | null => {
        return control.value.length == length ? null : { 'minLength': true };
    };
}

export function newSalaryValidator(jobs: JobDto[]): ValidatorFn {

    return (control: AbstractControl): { [key: string]: boolean } | null => {
        console.log(jobs);
        console.log(control.get('selectedJob').value);

        const job = jobs.find(i => i.Id == control.get('selectedJob').value);
        console.log(job);

        const selectedSalary = control.get('Salary').value
        console.log(selectedSalary);

        return job && selectedSalary && (selectedSalary >= job.MinSalary && selectedSalary <= job.MaxSalary) ? null : { 'maxSalaryError': true };
    };
}

export function vacationStartValidator(control: AbstractControl): { [key: string]: boolean } | null {

    if (control.pristine) {
        return null;
    }

    return control.value && Date.now() <= Date.parse(control.value) ? null : { 'wrongStartDate': true };
}

export function vacationDatesOrderValidator(control: AbstractControl): { [key: string]: boolean } | null {


    const startDate = control.get('StartDate');
    const endDate = control.get('EndDate');
    if (startDate?.pristine || endDate?.pristine) {
        return null;
    }

    return endDate && startDate && Date.parse(endDate.value) < Date.parse(startDate.value) ? { 'wrongDatesOrder': true } : null;
}

export function vacationValidator(count: number): ValidatorFn {
    return (control: AbstractControl): { [key: string]: boolean } | null => {
        const startDate = control.get('StartDate');
        const endDate = control.get('EndDate');
        const one_day = 1000 * 60 * 60 * 24;
        if (startDate?.pristine || endDate?.pristine) {
            return null;
        }

        return endDate && startDate && Math.round((Date.parse(endDate?.value) - Date.parse(startDate?.value)) / one_day) <= count ? null : { 'vacationError': true };
    };
}

export function jobMaxSalaryValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const minSalary = control.get('MinSalary');
    const maxSalary = control.get('MaxSalary');

    if (minSalary.pristine || maxSalary.pristine) {
        return null;
    }

    return minSalary && maxSalary && minSalary.value >= maxSalary.value ? { 'misMatch': true } : null;
}