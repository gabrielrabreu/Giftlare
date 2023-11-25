import { SignInResultDto } from "../interfaces/SignInResultDto";
import { SignInDto } from "../interfaces/SignInDto";
import ApiService from "./ApiService";

class AccountService extends ApiService {
  async signIn(data: SignInDto): Promise<SignInResultDto> {
    const response = await this.post("/v1/accounts/signin", data);
    return response as SignInResultDto;
  }
}

const accountService = new AccountService();

export default accountService;
