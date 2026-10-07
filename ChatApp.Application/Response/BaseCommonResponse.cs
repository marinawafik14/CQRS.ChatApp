using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Response
{
    public sealed class BaseCommonResponse
    {
       public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; } = new List<string>();


    }
}
