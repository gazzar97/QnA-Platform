﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public BaseResponse(string message,bool success)
        {
            Success = success;
            Message = message;

        }
        public bool Success { get; set; }
        public string Message { get; set; }

        public List<string> ValidaitonErrors { get; set; }
    }
}
