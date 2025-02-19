namespace CRUDUsingADO
{
    public static class ConnectionString
    {
        private static string cs = "Server=DESKTOP-RBRS5GD\\SQLEXPRESS; Database=CrudADOdb; Trusted_Connection=True; TrustServerCertificate=True;";

        public static string dbcs { get => cs; }

    }
}
