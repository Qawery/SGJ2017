﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.IdentificationLottery
{
    public static class Extensions
    {
            public static IList<T> Shuffle<T>(this IList<T> ts)
            {
                var count = ts.Count;
                var last = count - 1;
                for (var i = 0; i < last; ++i)
                {
                    var r = UnityEngine.Random.Range(i, count);
                    var tmp = ts[i];
                    ts[i] = ts[r];
                    ts[r] = tmp;
                }

                return ts;
            }
    }
}
