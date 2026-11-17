import { AbstractControl, ValidationErrors } from "@angular/forms";

export const passwordPolicyHint = 'At least 8 characters, including a digit, a lowercase and an uppercase letter.';

export function passwordPolicyValidator(control: AbstractControl): ValidationErrors | null {
  const value: string = control.value ?? '';
  if (!value) {
    return null;
  }

  const isValid = value.length >= 8
    && /[0-9]/.test(value)
    && /\p{Ll}/u.test(value)
    && /\p{Lu}/u.test(value);

  return isValid ? null : { passwordPolicy: true };
}
