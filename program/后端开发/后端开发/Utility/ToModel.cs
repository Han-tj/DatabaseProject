﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace 后端开发.Utility
{
    public static class ToModel
    {
        public static T DtToModel<T>(this DataRow dr)
        {
            Type t = typeof(T);
            T md = (T)Activator.CreateInstance(t);
            var props = t.GetProperties();
            foreach(var prop in props)
            {
                if(dr.Table.Columns.Contains(prop.Name))
                {
                    prop.SetValue(md, dr[prop.Name]);
                }
            }
            return md;
        }
    }
}
