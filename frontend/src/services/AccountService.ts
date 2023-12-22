import { LoginResponseInterface } from "../interfaces/LoginResponseInterface";
import { LoginInterface } from "../interfaces/LoginInterface";
import ApiService from "./ApiService";

class AccountService extends ApiService {
  async login(data: LoginInterface): Promise<LoginResponseInterface> {
    return await this.post<LoginResponseInterface>("/v1/accounts/signin", data);
  }
}

const accountService = new AccountService();

export default accountService;
