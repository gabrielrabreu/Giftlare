import { LoginResponseInterface } from "../../interfaces/LoginResponseInterface";
import { LoginInterface } from "../../interfaces/LoginInterface";

const mockLoginResponse: LoginResponseInterface = {
  token: "token",
  user: {
    id: "user id",
    name: "user name",
    email: "user email",
    language: "user language",
  },
};

export const mockAccountService = {
  login: jest.fn(async (parameters: LoginInterface) =>
    Promise.resolve(mockLoginResponse),
  ),
};
