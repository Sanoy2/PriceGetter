﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Infrastructure.Settings
{
    public class LoggerSettings : ISettings
    {
        public string LogFilepath { get; set; }
    }
}