namespace Pokedex.Core.Common
{
    /// <summary>
    /// Internal operation result wrapper
    /// </summary>
    public class OperationResult<T>
    {
        /// <summary>
        /// Request result
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Request success indicator
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Error code
        /// </summary>
        public string ErrorCode { get; set; }

        protected internal OperationResult(bool success, string error, string errorCode = default, T data = default)
        {
            Success = success;
            Error = error;
            ErrorCode = errorCode;
            Data = data;
        }
    }

    public class OperationResult : OperationResult<string>
    {
        protected OperationResult(bool success, string error, string errorCode = null, string data = default) : base(success, error, errorCode, data) { }



        /// <summary>
        /// Returns failure result
        /// </summary>
        /// <returns><see cref="OperationResult{T}"/></returns>
        public static OperationResult Fail(string error, string errorCode)
        {
            return new OperationResult(false, error, errorCode);
        }

        /// <summary>
        /// Returns failure result
        /// </summary>
        /// <returns><see cref="OperationResult{T}"/></returns>
        public static OperationResult<TResult> Fail<TResult>()
        {
            return new OperationResult<TResult>(false, null);
        }

        /// <summary>
        /// Returns failure result
        /// </summary>
        /// <param name="error">Error message</param>
        /// <returns><see cref="OperationResult{T}"/></returns>
        public static OperationResult<TResult> Fail<TResult>(string error)
        {
            return new OperationResult<TResult>(false, error);
        }

        /// <summary>
        /// Returns success result
        /// </summary>
        /// <param name="data">Result data</param>
        /// <returns><see cref="OperationResult{T}"/></returns>
        public static OperationResult<TResult> Ok<TResult>(TResult data = default)
        {
            return new OperationResult<TResult>(true, null, null, data);
        }
    }
}