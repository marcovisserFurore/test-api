/* 
 * Copyright (c) 2019, Rachid (thisdoesnt@exist.com) and contributors
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/ewoutkramer/fhir-net-api/master/LICENSE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RAC.Vuur.Support
{
    public static class GuidExtensions
    {
        public static string ToFhirId(this System.Guid me)
        {
            return me.ToString("n");
        }

        public static string ToFhirId(this System.Guid? me)
        {
            if (me.HasValue)
                return me.Value.ToString("n");
            return null;
        }
    }
}