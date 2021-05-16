import { AbstractControl, ValidatorFn } from "@angular/forms";

export function phoneValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const regexp = new RegExp(/\+\d{12}/);
    const valid = regexp.test(control.value);

    if (control.pristine) {
        return null;
    }

    return !valid ? { 'noMatch': true } : null;
}