import { UserDto } from "./UserDto";

export interface SignInResultDto {
  token: string;
  user: UserDto;
}
