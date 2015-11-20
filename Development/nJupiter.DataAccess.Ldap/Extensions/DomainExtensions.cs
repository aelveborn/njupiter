namespace nJupiter.DataAccess.Ldap.Extensions
{
    public static class DomainExtensions
    {
        public static string FilterDomain(this string accountName)
        {
            if (accountName.Contains("\\"))
            {
                var lastIndex = accountName.LastIndexOf('\\') + 1;
                return accountName.Substring(lastIndex, (accountName.Length - lastIndex));
            }
            return accountName;
        }
    }
}