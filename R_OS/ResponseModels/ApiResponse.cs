namespace R_OS.ResponseModels
{
    public class ApiResponse<T>
    {
        public string Version { get; set; } = "1.0.0";

        public bool ResultStatus { get; set; }

        public int ResultCode { get; set; }

        public string ResultMessage { get; set; }

        public T? ResultObject { get; set; }

        public ApiResponse(T resultObject, bool status = true, int resultCode = 200, string resultMessage = "Your operation has been completed successfully.")
        {
            ResultObject = resultObject;
            ResultStatus = status;
            ResultCode = resultCode;
            ResultMessage = resultMessage;
        }
    }
}
