import { HttpErrorResponse } from "@angular/common/http";

export function getProblemMessage(error: HttpErrorResponse, fallback: string): string {
  const body = error.error;

  if (body?.errors) {
    const messages = Object.values(body.errors).flat() as string[];
    if (messages.length > 0) {
      return messages.join(' ');
    }
  }

  return body?.detail ?? fallback;
}
