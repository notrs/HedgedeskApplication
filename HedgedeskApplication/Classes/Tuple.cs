﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HedgedeskApplication.Classes
{
    public static class Tuple
    {
        public static Tuple<T1, T2> New<T1, T2>(T1 first, T2 second)
        {
            var tuple = new Tuple<T1, T2>(first, second);
            return tuple;
        }
    }
}


