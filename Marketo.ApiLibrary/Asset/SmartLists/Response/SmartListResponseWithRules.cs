﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Asset.SmartLists.Response
{
    public class SmartListResponseWithRules:SmartListResponse
    {
        public SmartListRules Rules { get; set; }
    }
}
