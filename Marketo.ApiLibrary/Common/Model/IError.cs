﻿namespace Marketo.ApiLibrary.Common.Model
{
    public interface IError
    {
        string Code { get; set; }
        string Message { get; set; }
    }
}