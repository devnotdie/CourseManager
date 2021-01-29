namespace CourseManager.Application.Wrappers
{
    public class PagedResponse<TData> : Response<TData>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedResponse(TData data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
        }
    }
}