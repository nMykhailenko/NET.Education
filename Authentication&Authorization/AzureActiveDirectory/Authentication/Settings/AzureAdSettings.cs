namespace Authentication.Settings
{
    /// <summary>
    /// Azure Active Directory settings.
    /// </summary>
    public class AzureAdSettings
    {
        /// <summary>
        /// Gets or sets an instance.
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// Gets or sets a tenant id.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Gets or sets a client id.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets a client secret.
        /// </summary>
        public string ClientSecret { get; set; }
    }
}
