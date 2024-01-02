export class user
{
  id: number;
  login: string;
  password: string;
  isEmailConfirmed: boolean;
  rankId: number;
}

export type addUser =
{
  login: string;
  email: string;
  password: string;
}

export type login = {
  login: string;
  password: string;
}

export class rank {
  id: number;
  name: string;
}
