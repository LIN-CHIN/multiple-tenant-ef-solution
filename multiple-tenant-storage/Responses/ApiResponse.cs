namespace multiple_tenant_storage.Responses
{
    /// <summary>
    /// Api Response
    /// </summary>
    public class ApiResponse<T> : ResponseBase
    {
        /// <summary>
        /// 錯誤/成功代碼
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 回傳內容
        /// </summary>
        public T Content { get; set; }

        /// <summary>
		/// 取得結果
		/// </summary>
		/// <param name="content"></param>
		/// <param name="code"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static ApiResponse<T> GetResult(T content, int code = 0, string message = "")
        {
            return new ApiResponse<T>
            {
                Code = code,
                Message = message,
                Content = content
            };
        }
    }
}
