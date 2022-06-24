//-----------------------------------------------------------------------
// <copyright file="ApiException.cs" company="AXA XL">
//     Copyright (c) AXA XL
// </copyright>
//-----------------------------------------------------------------------

namespace TestOpenApi
{
    /// <summary>
    ///   API Exception copied from NSwag generation.
    /// </summary>
    public partial class ApiException : System.Exception
    {
        /// <summary>Initializes a new instance of the <see cref="ApiException" /> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="response">The response.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="innerException">The inner exception.</param>
        public ApiException(
            string message,
            int statusCode, 
            string response, 
            System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, 
            System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            this.StatusCode = statusCode;
            this.Response = response;
            this.Headers = headers;
        }

        /// <summary>Gets the status code.</summary>
        /// <value>The status code.</value>
        public int StatusCode { get; private set; }

        /// <summary>Gets the response.</summary>
        /// <value>The response.</value>
        public string Response { get; private set; }

        /// <summary>Gets the headers.</summary>
        /// <value>The headers.</value>
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"HTTP Response: \n\n{this.Response}\n\n{base.ToString()}";
        }
    }
}
