﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP_TextAnalyzer.Filter
{
    public interface IFilter
    {
        bool Verify(String[] words);
    }
}
