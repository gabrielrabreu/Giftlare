export interface PagedList<T> {
  data: T[];
  currentPage: number;
  totalItems: number;
  totalPages: number;
}
