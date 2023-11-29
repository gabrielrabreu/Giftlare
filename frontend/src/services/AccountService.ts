import { SignInResultDto } from "../interfaces/SignInResultDto";
import { SignInDto } from "../interfaces/SignInDto";
import ApiService from "./ApiService";

class AccountService extends ApiService {
  async signIn(data: SignInDto): Promise<SignInResultDto> {
    return await this.post<SignInResultDto>("/v1/accounts/signin", data);
  }
}

const accountService = new AccountService();

export default accountService;
