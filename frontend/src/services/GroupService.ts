import { CreateGroupInterface } from "../interfaces/CreateGroupInterface";
import { PagedParameters } from "../interfaces/PagedParameters";
import { GroupInterface } from "../interfaces/GroupInterface";
import { PagedList } from "../interfaces/PagedList";
import ApiService from "./ApiService";

class GroupService extends ApiService {
  async getById(id: string): Promise<GroupInterface> {
    return await this.get<GroupInterface>(
      `/v1/exchanges/${id}`,
    );
  }

  async paged(parameters: PagedParameters): Promise<PagedList<GroupInterface>> {
    return await this.get<PagedList<GroupInterface>>(
      "/v1/exchanges",
      { params: parameters },
    );
  }

  async create(data: CreateGroupInterface): Promise<void> {
    return await this.post<void>("/v1/exchanges", data);
  }

  async invite(id: string): Promise<string> {
    return await this.post<string>(
      `/v1/exchanges/${id}:invite`,
    );
  }

  async acceptInvite(id: string, inviteToken: string): Promise<void> {
    return await this.post<void>(
      `/v1/exchanges/${id}:accept-invite`,
      null,
      { params: { token: inviteToken } },
    );
  }
}

const groupService = new GroupService();

export default groupService;
