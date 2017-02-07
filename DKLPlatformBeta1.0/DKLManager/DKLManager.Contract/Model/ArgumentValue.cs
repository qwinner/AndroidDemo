﻿using HYZK.FrameWork.Common;
using HYZK.FrameWork.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKLManager.Contract.Model
{
    [Serializable]
    [System.ComponentModel.DataAnnotations.Schema.Table("ArgumentValue")]
    public class ArgumentValue : ModelBase
    {
       public override int ID { get; set; }
       public string Argument { get; set; }
       public string SampleRegisterNumber { get; set; }
       public string ArgumentPrice{ get; set; }
       public int ParameterState { get; set; }
    }
    public enum EnumParameterState
    {
        [EnumTitle("分析人提交")]
        NewParameter = 1,
        [EnumTitle("实验室审核")]
        OldParameter = 2,
        [EnumTitle("实验室编制")]
        SysB = 3,
    }
}
