﻿namespace Silky.Hero.Common;

public class RegularExpressionConsts
{
    public const string MobilePhone = "^((13[0-9])|(14[5|7])|(15([0-3]|[5-9]))|(18[0,5-9]))\\d{8}$";

    public const string TelPhone = "^(0\\d{2}-\\d{8}(-\\d{1,4})?)|(0\\d{3}-\\d{7,8}(-\\d{1,4})?)$";

    public const string Password = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";

    public const string RoleName = "^\\w+$";

    public const string UserName = "^\\w+$";

    public const string JobNumber = "^\\w+$";

    public const string Http = "^https?:\\/\\/";
}