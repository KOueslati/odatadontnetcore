//-----------------------------------------------------------------------
// <copyright file="ApiException{TResult}.cs" company="AXA XL">
//     Copyright (c) AXA XL
// </copyright>
//-----------------------------------------------------------------------

namespace TestOpenApi
{
    /// <summary>
    ///   The API exception
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public partial class ApiException<TResult> : ApiException
    {
        /// <summary>Initializes a new instance of the <see cref="ApiException{TResult}" /> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="response">The response.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="result">The result.</param>
        /// <param name="innerException">The inner exception.</param>
        public ApiException(
            string message, 
            int statusCode, 
            string response, 
            System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers,
            TResult result,
            System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            this.Result = result;
        }

        /// <summary>Gets the result.</summary>
        /// <value>The result.</value>
        public TResult Result { get; private set; }
    }
}
