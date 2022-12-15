﻿using System;

namespace Silky.Permission.Application.Contracts.Menu.Dtos;

public class GetMenuOutput : MenuDtoBase
{
    /// <summary>
    /// 主键id
    /// </summary>
    public long Id { get; set; }

    public DateTimeOffset CreatedTime { get; set; }

    public DateTimeOffset? UpdatedTime { get; set; }
}