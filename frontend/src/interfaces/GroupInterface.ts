import { GroupMemberInterface } from "./GroupMemberInterface";

export interface GroupInterface {
  id: string;
  name: string;
  image: string;
  members: GroupMemberInterface[];
  totalMembers: number;
}
