﻿using System.Collections.Generic;
using MarketoApiLibrary.Model;

namespace MarketoApiLibrary.Response
{
    public interface IBaseMarketoResponse
    {
        List<IError> Errors { get; set; }
        string RequestId { get; set; }
        bool Success { get; set; } 
        List<string> Warnings { get; set; }
    }
}