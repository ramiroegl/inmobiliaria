export interface PaginatedResult<T> {
    totalRecords: number;
    totalPages: number;
    pageSize: number;
    data: T[];
};

export interface CreatedResult {
    id: string;
}

export interface DeletedResult {
    ok: boolean;
    error?: string;
};
