import { SignInResultDto } from "../interfaces/SignInResultDto";
import { SignInDto } from "../interfaces/SignInDto";

import ApiService from "./ApiService";

class AccountService extends ApiService {
  async signIn(data: SignInDto): Promise<SignInResultDto> {
    try {
      const response = await this.api.post("/v1/accounts/sign-in", data);
      return response.data as SignInResultDto;
    } catch (error: any) {
      throw new Error(error.message);
    }
  }
}

const accountService = new AccountService();

export default accountService;
