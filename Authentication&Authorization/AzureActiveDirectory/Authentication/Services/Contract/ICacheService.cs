namespace Authentication.Services.Contract
{
    /// <summary>
    /// Cache service
    /// </summary>
    public interface ICacheService<T> where T: class, new()
    {
        /// <summary>
        /// Try to get value from cache.
        /// </summary>
        /// <param name="key">Cache key.</param>
        /// <returns>Value which referancial to key.</returns>
        T TryGetValue(object key);

        /// <summary>
        /// Set value to cache.
        /// </summary>
        /// <param name="key">Cache key.</param>
        /// <param name="value">Cache value.</param>
        void SetValue(object key, T value);
    }
}
