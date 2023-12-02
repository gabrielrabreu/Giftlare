import { UserInterface } from "./UserInterface";

export interface LoginResponseInterface {
  token: string;
  user: UserInterface;
}
