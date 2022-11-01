using Microsoft.AspNetCore.Mvc;

namespace Finance_fund.Controllers
{
    public class ApiController : ControllerBase
    {
        /// <summary>
        /// نتیجه ی عملیات موفق
        /// </summary>
        [NonAction]
        public IActionResult OkResult(string message)
        {
            return Ok(new ResponseMessage(message, null));
        }

        /// <summary>
        /// نتیجه ی عملیات موفق همراه با محتوا 
        /// </summary>
        [NonAction]
        public IActionResult OkResult(string message, object content)
        {
            return Ok(new ResponseMessage(message, content));
        }

        /// <summary>
        /// کد 400 همراه با پیام مورد نظر
        /// </summary>
        [NonAction]
        public IActionResult BadReq(string message)
        {
            return BadRequest(new ResponseMessage(message, null));
        }

        /// <summary>
        /// کد 400 همراه با پیام و محتوا 
        /// </summary>
        [NonAction]
        public IActionResult BadReq(string message, object content)
        {
            return BadRequest(new ResponseMessage(message, content));
        }

        public class ResponseMessage
        {
            public string Message { get; set; }

            public object Content { get; set; }

            public ResponseMessage(string message, object content)
            {
                Message = message;
                Content = content;
            }

        }
        public static class ApiMessage
        {
            public const string Ok = "عملیات با موفقیت انجام شد ";
            public const string Error = "خطا! ";
            public const string BadRequest = "عملیات با خطا مواجه شد";
            public const string ServiceUnAvailable = "سرویس سرور دردسترس نمیباشد";

        }
    }
}
