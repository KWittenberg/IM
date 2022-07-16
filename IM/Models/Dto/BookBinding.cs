﻿using System.ComponentModel;

namespace IM.Models.Dto;

public enum BookBinding
{
    Hard = 1,
    Soft = 2,
    [Description("Soft With Flaps")]
    SoftWithFlaps = 3
}