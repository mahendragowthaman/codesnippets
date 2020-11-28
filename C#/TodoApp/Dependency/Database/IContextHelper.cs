namespace TodoApp.Data
{
    public interface IContextHelper
    {
        DbContext GetDbContext();
    }
}