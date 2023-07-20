using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using multiple_tenant_solution.Responses;
using Npgsql;

namespace multiple_tenant_solution.Controllers
{
    /// <summary>
	/// 處理所有Exception的controller，此controller會在Program.cs由UseExceptionHandler註冊
	/// </summary>
	[Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        /// <summary>
        /// 處理所有Exception的controller constructor，IoC container會由此注入
        /// </summary>
        /// <param name="logger"></param>
        public ErrorController()
        {
        }

        /// <summary>
        /// Error handling
        /// </summary>
        /// <returns></returns>
        public ActionResult<ApiResponse<string>> Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context!.Error;

            ApiResponse<string> apiErrorMessage = new ApiResponse<string>();

            if (exception.GetBaseException() is PostgresException)
            {
                apiErrorMessage = HandlePostgresException((PostgresException)exception.GetBaseException());
            }
            else
            {
                apiErrorMessage = new ApiResponse<string>()
                {
                    Code = 10001,
                    Message = "系統錯誤",
                    Content = exception.ToString()
                };
            }

            return StatusCode(StatusCodes.Status200OK, apiErrorMessage);
        }

        /// <summary>
        /// 專門處理PostgresException
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        private ApiResponse<string> HandlePostgresException(PostgresException exception)
        {
            ApiResponse<string> apiErrorMessage = new ApiResponse<string>();

            if (exception.SqlState == "23505")
            {
                apiErrorMessage = new ApiResponse<string>()
                {
                    Code = 20001,
                    Message = "資料庫key相關的錯誤",
                    Content = exception.ToString()
                };
            }
            else
            {
                apiErrorMessage = new ApiResponse<string>()
                {
                    Code = 20000,
                    Message = "資料庫相關的錯誤",
                    Content = exception.ToString()
                };
            }
            return apiErrorMessage;
        }
    }
}
