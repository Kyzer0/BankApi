using CostumeResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBankingFunctionality.Helpers
{
    /// <summary>
    /// Create Testing reusable result
    /// </summary>
    public class AsserApiHelpers
    {
        /// <summary>
        /// Reusable Result for all testing
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="expectedMessage"></param>
        /// <param name="expectedError"></param>
        public void AsserApiError<T>(ApiResponse<T> result, string expectedMessage, string expectedError)
        {
            Assert.False(result.isSuccess);
            Assert.Equal(expectedMessage, result.Message);
            Assert.Contains(expectedError, result.Errors);
        }
    }
}
