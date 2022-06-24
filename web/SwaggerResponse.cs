//-----------------------------------------------------------------------
// <copyright file="SwaggerResponse.cs" company="AXA XL">
//     Copyright (c) AXA XL
// </copyright>
//-----------------------------------------------------------------------

namespace TestOpenApi
{
    /// <summary>
    ///   The Swagger response
    /// </summary>
    public partial class SwaggerResponse
    {
        /// <summary>Initializes a new instance of the <see cref="SwaggerResponse" /> class.</summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="headers">The headers.</param>
        public SwaggerResponse(
            int statusCode,
            System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers)
        {
            this.StatusCode = statusCode;
            this.Headers = headers;
        }

        /// <summary>Gets the status code.</summary>
        /// <value>The status code.</value>
        public int StatusCode { get; private set; }

        /// <summary>Gets the headers.</summary>
        /// <value>The headers.</value>
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }
    }
}