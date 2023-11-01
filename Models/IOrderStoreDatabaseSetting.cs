namespace RebarProject.Models
{
    public interface IOrderStoreDatabaseSetting
    {
        string OrderCollectionName { get; set; }
        string ConnectionString {  get; set; }
        string DatabaseName { get; set; }
    }
}
