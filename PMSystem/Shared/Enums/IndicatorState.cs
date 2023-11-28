using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSystem.Shared.Enums
{
    public enum IndicatorState
    {
        待添加,
        待上级审核,
        待上上级审核,
        待人事科确认,
        待分管领导审核,
        待部门领导审核,
        待院长审核,
        审核通过,
        审核未通过
    }
}
