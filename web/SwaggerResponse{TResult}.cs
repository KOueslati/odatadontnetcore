//-----------------------------------------------------------------------
// <copyright file="SwaggerResponse.cs" company="AXA XL">
//     Copyright (c) AXA XL
// </copyright>
//-----------------------------------------------------------------------

using web;

namespace SwaggerGenOpenApi
{
    /// <summary>The Swagger response for specific type</summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public partial class SwaggerResponse<TResult> : SwaggerResponse
    {
        /// <summary>Initializes a new instance of the <see cref="SwaggerResponse{TResult}" /> class.</summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="result">The result.</param>
        public SwaggerResponse(
            int statusCode,
            System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>>
                headers,
            TResult result)
            : base(statusCode, headers)
        {
            this.Result = result;
        }

        /// <summary>Gets the result.</summary>
        /// <value>The result.</value>
        public TResult Result { get; private set; }
    }
}