
public class GlobalModels
{
    public static string LoginUserName { get; set; } = "admin";
    public static string LoginPassword { get; set; } = "Admin@#123";
    public static string JWTSecret { get; set; } = "321890@#$MSBCMS@#$321890";
    public static string JWTValidAudience { get; set; } = "http://localhost:5016";
    public static string JWTValidIssuer { get; set; } = "http://localhost:5016";
    public static string MonogoServer { get; set; } = "mongodb+srv://msb1993:Pokemon%40!32189@msbcluster.8adn2yj.mongodb.net/";
    public static string MonogoDB { get; set; } = "CapitalPlacementDB";



    //public static string LoginUserName { get; set; } = Convert.ToString(Environment.GetEnvironmentVariable("LoginUserName"));
    //public static string LoginPassword { get; set; } = Convert.ToString(Environment.GetEnvironmentVariable("LoginPassword"));
    //public static string JWTSecret { get; set; } = Convert.ToString(Environment.GetEnvironmentVariable("JWTSecret"));
    //public static string JWTValidAudience { get; set; } = Convert.ToString(Environment.GetEnvironmentVariable("JWTValidAudience"));
    //public static string JWTValidIssuer { get; set; } = Convert.ToString(Environment.GetEnvironmentVariable("JWTValidIssuer"));
    //public static string MonogoServer { get; set; } = Convert.ToString(Environment.GetEnvironmentVariable("MonogoServer"));
    //public static string MonogoDB { get; set; } = Convert.ToString(Environment.GetEnvironmentVariable("MonogoDB"));
   // public static string BaseURL { get; set; } = Convert.ToString(Environment.GetEnvironmentVariable("BaseURL"));
}

