export class user
{
  id: number;
  login: string;
  email: string;
}

export type userInfo =
{
  id: number;
  login: string;
  email: string;
  role: string;
  userRank: number;
}

export type sessionInfo =
{
  userId: number;
  username: string;
  email: string;
  userRank: number;
}

export type addUser =
{
  login: string;
  email: string;
  password: string;
}

export type updateUser =
{
  login: string;
  email: string;
  currentPassword?: string;
  newPassword?: string;
}

export type login = {
  login: string;
  password: string;
}
