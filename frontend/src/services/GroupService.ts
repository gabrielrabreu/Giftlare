import { CreateGroupInterface } from "../interfaces/CreateGroupInterface";
import { PagedParameters } from "../interfaces/PagedParameters";
import { GroupInterface } from "../interfaces/GroupInterface";
import { PagedList } from "../interfaces/PagedList";
import ApiService from "./ApiService";

class GroupService extends ApiService {
  async paged(parameters: PagedParameters): Promise<PagedList<GroupInterface>> {
    const response = await this.get<PagedList<GroupInterface>>(
      "/v1/exchanges",
      { params: parameters },
    );
    return response;
  }

  async create(data: CreateGroupInterface): Promise<CreateGroupInterface> {
    return await this.post("/v1/exchanges", data);
  }
}

const groupService = new GroupService();

export default groupService;
