<<<<<<< HEAD
﻿using System;
 public interface IReport
{
    string Generate();
}
public class SalesReport : IReport
{
    public string Generate() => "sales Report data";
}
public class UserReport : IReport
{
    public string Generate() => "User Report data";
}
public abstract class ReportDecorator : IReport
{
    protected IReport _report;

    protected ReportDecorator(IReport report)
    {
        _report = report;
    }
    public virtual string Generate()
    {
        return _report.Generate();
    }
}
=======
﻿
>>>>>>> 220fc327a47931ed0c0b81b38d9ed5c6bd0ef0cf
