import { CreateGroupInterface } from "../../interfaces/CreateGroupInterface";
import { GroupInterface } from "../../interfaces/GroupInterface";
import { PagedList } from "../../interfaces/PagedList";
import { PagedParameters } from "../../interfaces/PagedParameters";

const mockPaged: PagedList<GroupInterface> = { data: [], totalPages: 0, totalItems: 0, currentPage: 1 };


export const mockGroupService = {
  paged: jest.fn(async (parameters: PagedParameters) => Promise.resolve(mockPaged)),
  create: jest.fn(async (data: CreateGroupInterface) => {}),
};
