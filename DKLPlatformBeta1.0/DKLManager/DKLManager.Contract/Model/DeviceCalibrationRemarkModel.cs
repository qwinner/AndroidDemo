﻿using HYZK.FrameWork.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKLManager.Contract.Model
{
    [Serializable]
    [System.ComponentModel.DataAnnotations.Schema.Table("DeviceCalibrationRemarkModel")]

    public class DeviceCalibrationRemarkModel:ModelBase
    {
        [Key]
        public override int ID { set; get; }
        [Required(ErrorMessage = "不能为空")]
        public int DeviceId { get; set; }
        [Required(ErrorMessage = "不能为空")]
        public string CalibrationPerson { get; set; }
        [Required(ErrorMessage = "不能为空")]
        public DateTime CalibrationTime { get; set; }
        [Required(ErrorMessage = "不能为空")]
        public string Remark { get; set; }
        public DateTime CalibrationDate { get; set; }
        public DateTime CalibrationPeriod { get; set; }
    }
}
