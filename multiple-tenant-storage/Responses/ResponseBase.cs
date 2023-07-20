namespace multiple_tenant_storage.Responses
{
    /// <summary>
    /// 回傳格式的基底
    /// </summary>
    public abstract class ResponseBase
    {
        /// <summary>
        /// 錯誤/成功代碼
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }
    }
}
