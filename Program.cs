
﻿using System;
using System.ComponentModel.Design;

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
public class DateFilterDecorator : ReportDecorator
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;

    public DateFilterDecorator(IReport report, DateTime startDate, DateTime endDate) : base(report)
    {
        _startDate = startDate;
        _endDate = endDate;
    }

    public override string Generate()
    {
        return $@"{base.Generate()} filtered by date from
{_startDate.ToShortDateString()} to {_endDate.ToShortDateString()}";
    }

}
public class SortingDecorator : ReportDecorator
{ 
    private readonly string _sortBy;

    public SortingDecorator(IReport report, string sortBy) : base(report)
    {
        _sortBy = sortBy;
    }
    public override string Generate()
    {
        return base.Generate();
    }
}

public class CsvExportDecorator : ReportDecorator
{
    public CsvExportDecorator(IReport report) : base(report) { }

    public override string Generate()
    {
        return base.Generate();
    }
}
public static class ReportClient
{
    public static void GenerateReport()
    { 
    IReport report = new SalesReport();
        report = new DateFilterDecorator(report, DateTime.Now.AddMonths(-1), DateTime.Now);
        report = new SortingDecorator(report, "date");
        report = new CsvExportDecorator(report);

        Console.WriteLine(report.Generate());
    }
}
public interface IIternalDeliveryService
{
    void DeliverOrder(string orderId);
    string GetDeliveryStatus(string orderId);
}
public class InternalDeliveryService : IInheritanceService
{
    public void DeliverOrder(string orderId)
    {
        Console.WriteLine($"Delivering order {orderId} via internal service.");

    }
    public string GetDeliveryStatus(String orderId)
    {
        return $"Order {orderId} status: Delivered (internal)";

    }
}

