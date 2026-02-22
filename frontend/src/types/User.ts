export interface User {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  role: string;
}

export interface UserCreateDto {
  firstName: string;
  lastName: string;
  email: string;
  role: string;
}
