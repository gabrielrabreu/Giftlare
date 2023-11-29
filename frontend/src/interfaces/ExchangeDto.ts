import { ExchangeMemberDto } from "./ExchangeMemberDto";

export interface ExchangeDto {
  id: string;
  name: string;
  members: ExchangeMemberDto[];
}
