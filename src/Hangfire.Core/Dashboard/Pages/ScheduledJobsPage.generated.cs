﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hangfire.Dashboard.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 2 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
    using Hangfire.Common;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
    using Hangfire.Dashboard;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
    using Hangfire.Dashboard.Pages;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
    using Hangfire.Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class ScheduledJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");







            
            #line 7 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
  
    Layout = new LayoutPage { Title = "Scheduled Jobs" };

    int from, perPage;

    int.TryParse(Query("from"), out from);
    int.TryParse(Query("count"), out perPage);

    var monitor = Storage.GetMonitoringApi();
    Pager pager = new Pager(from, perPage, monitor.ScheduledCount())
    {
        BasePageUrl = LinkTo("/jobs/scheduled")
    };

    JobList<ScheduledJobDto> scheduledJobs = monitor.ScheduledJobs(pager.FromRecord, pager.RecordsPerPage);


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 24 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
 if (pager.TotalPageCount == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"alert alert-info\">\r\n        There are no scheduled jobs.\r\n    </d" +
"iv>\r\n");


            
            #line 29 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"js-jobs-list\">\r\n        <div class=\"btn-toolbar btn-toolbar-top\">" +
"\r\n            <button class=\"js-jobs-list-command btn btn-sm btn-primary\"\r\n     " +
"               data-url=\"");


            
            #line 35 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                         Write(LinkTo("/jobs/scheduled/enqueue"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                    data-loading-text=""Enqueueing..."">
                <span class=""glyphicon glyphicon-play""></span>
                Enqueue now
            </button>

            <button class=""js-jobs-list-command btn btn-sm btn-default""
                    data-url=""");


            
            #line 42 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                         Write(LinkTo("/jobs/scheduled/delete"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                    data-loading-text=""Deleting...""
                    data-confirm=""Do you really want to DELETE ALL selected jobs?"">
                <span class=""glyphicon glyphicon-remove""></span>
                Delete selected
            </button>

            ");


            
            #line 49 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
       Write(RenderPartial(new PerPageSelector(pager)));

            
            #line default
            #line hidden
WriteLiteral(@"
        </div>

        <table class=""table"">
            <thead>
                <tr>
                    <th class=""min-width"">
                        <input type=""checkbox"" class=""js-jobs-list-select-all"" />
                    </th>
                    <th class=""min-width"">Id</th>
                    <th>Enqueue</th>
                    <th>Job</th>
                    <th class=""align-right"">Scheduled</th>
                </tr>
            </thead>
");


            
            #line 64 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
             foreach (var job in scheduledJobs)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr class=\"js-jobs-list-row ");


            
            #line 66 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                                        Write(!job.Value.InScheduledState ? "obsolete-data" : null);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 66 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                                                                                                Write(job.Value.InScheduledState ? "hover" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                    <td>\r\n");


            
            #line 68 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                         if (job.Value.InScheduledState)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <input type=\"checkbox\" class=\"js-jobs-list-checkbox\" " +
"name=\"jobs[]\" value=\"");


            
            #line 70 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                                                                                                 Write(job.Key);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n");


            
            #line 71 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                    <td class=\"min-width\">\r\n          " +
"              <a href=\"");


            
            #line 74 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                            Write(LinkTo("/jobs/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            ");


            
            #line 75 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                       Write(HtmlHelper.JobId(job.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a>\r\n");


            
            #line 77 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                         if (!job.Value.InScheduledState)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <span title=\"Job\'s state has been changed while fetch" +
"ing data.\" class=\"glyphicon glyphicon-question-sign\"></span>\r\n");


            
            #line 80 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                    <td class=\"min-width\">\r\n          " +
"              <span data-moment=\"");


            
            #line 83 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                                      Write(JobHelper.ToTimestamp(job.Value.EnqueueAt));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            ");


            
            #line 84 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                       Write(job.Value.EnqueueAt);

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </span>\r\n                    </td>\r\n                   " +
" <td>\r\n                        <a class=\"job-method\" href=\"");


            
            #line 88 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                                               Write(LinkTo("/jobs/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            ");


            
            #line 89 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                       Write(HtmlHelper.DisplayJob(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a>\r\n                    </td>\r\n                    <t" +
"d class=\"align-right\">\r\n");


            
            #line 93 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                         if (job.Value.ScheduledAt != null)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <span data-moment=\"");


            
            #line 95 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                                          Write(JobHelper.ToTimestamp(job.Value.ScheduledAt.Value));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 96 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                           Write(job.Value.ScheduledAt);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n");


            
            #line 98 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                </tr>\r\n");


            
            #line 101 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </table>\r\n    </div>\r\n");


            
            #line 104 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"

    
            
            #line default
            #line hidden
            
            #line 105 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
Write(RenderPartial(new Paginator(pager)));

            
            #line default
            #line hidden
            
            #line 105 "..\..\Dashboard\Pages\ScheduledJobsPage.cshtml"
                                        
}

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
