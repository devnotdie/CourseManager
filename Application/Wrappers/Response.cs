﻿using System.Collections.Generic;

namespace CourseManager.Application.Wrappers
{
    public class Response<TData>
    {
        public Response()
        {
        }

        public Response(TData data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public TData Data { get; set; }
    }
}