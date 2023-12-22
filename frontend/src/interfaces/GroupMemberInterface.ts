import { MemberRoles } from "./../enums/MemberRoles";

export interface GroupMemberInterface {
  name: string;
  role: typeof MemberRoles[keyof typeof MemberRoles];
  roleDescription: string;
}
