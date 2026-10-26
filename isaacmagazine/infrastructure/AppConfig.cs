namespace isaacmagazine.infrastructure
{
    public class AppConfig
    {
        public TinyMCE tinyMCE { get; set; } = new TinyMCE();
        public Company company { get; set; } = new Company();
        public Database database { get; set; } = new Database();
    }

    public class TinyMCE
    {
        public string? APIKey { get; set; }
    }

    public class Company
    {
        public string? CompanyName { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyPhoneShort { get; set; }
        public string? CompanyEmail { get; set; }
    }
    public class Database
    {
        public string? connectionString { get; set; }
    }
}
