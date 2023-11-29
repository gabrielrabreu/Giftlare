import { ExchangeDto } from "../interfaces/ExchangeDto";
import { PagedList } from "../interfaces/PagedList";
import ApiService from "./ApiService";

class ExchangeService extends ApiService {
  async paginate(): Promise<PagedList<ExchangeDto>> {
    const response = await this.get<PagedList<ExchangeDto>>("/v1/exchanges");
    return response;
  }
}

const exchangeService = new ExchangeService();

export default exchangeService;
