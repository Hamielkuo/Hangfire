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
    
    #line 2 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    using System.Linq;
    using System.Text;
    
    #line 5 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
    using Hangfire.Common;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
    using Hangfire.Dashboard;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
    using Hangfire.Dashboard.Pages;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
    using Hangfire.Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class EnqueuedJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");










            
            #line 10 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
  
    Layout = new LayoutPage
        {
            Title = Queue.ToUpperInvariant(),
            Subtitle = "Enqueued jobs",
            Breadcrumbs = new Dictionary<string, string>
                {
                    { "Queues", LinkTo("/jobs/enqueued") }
                }
        };

    int from, perPage;

    int.TryParse(Query("from"), out from);
    int.TryParse(Query("count"), out perPage);

    var monitor = Storage.GetMonitoringApi();
    Pager pager = new Pager(from, perPage, monitor.EnqueuedCount(Queue))
    {
        BasePageUrl = LinkTo("/jobs/enqueued/" + Queue)
    };

    JobList<EnqueuedJobDto> enqueuedJobs = monitor
        .EnqueuedJobs(Queue, pager.FromRecord, pager.RecordsPerPage);


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 36 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
 if (pager.TotalPageCount == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"alert alert-info\">\r\n        The queue is empty.\r\n    </div>\r\n");


            
            #line 41 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"js-jobs-list\">\r\n        <div class=\"btn-toolbar btn-toolbar-top\">" +
"\r\n            <button class=\"js-jobs-list-command btn btn-sm btn-default\"\r\n     " +
"               data-url=\"");


            
            #line 47 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                         Write(LinkTo("/jobs/enqueued/delete"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                    data-loading-text=""Deleting...""
                    data-confirm=""Do you really want to DELETE ALL selected jobs?"">
                <span class=""glyphicon glyphicon-remove""></span>
                Delete selected
            </button>

            ");


            
            #line 54 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
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
                    <th class=""min-width"">State</th>
                    <th>Job</th>
                    <th class=""align-right"">Enqueued</th>
                </tr>
            </thead>
            <tbody>
");


            
            #line 70 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                 foreach (var job in enqueuedJobs)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <tr class=\"js-jobs-list-row hover ");


            
            #line 72 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                                  Write(!job.Value.InEnqueuedState ? "obsolete-data" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                        <td>\r\n                            <input type=\"checkb" +
"ox\" class=\"js-jobs-list-checkbox\" name=\"jobs[]\" value=\"");


            
            #line 74 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                                                                                 Write(job.Key);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n                        </td>\r\n                        <td class=\"min-width" +
"\">\r\n                            <a href=\"");


            
            #line 77 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                Write(LinkTo("/jobs/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 78 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                           Write(HtmlHelper.JobId(job.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </a>\r\n");


            
            #line 80 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                             if (!job.Value.InEnqueuedState)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <span title=\"Job\'s state has been changed while f" +
"etching data.\" class=\"glyphicon glyphicon-question-sign\"></span>\r\n");


            
            #line 83 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                        <td class=\"min-width\">\r\n  " +
"                          <span class=\"label label-default\" style=\"");


            
            #line 86 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                                                 Write(JobHistoryRenderer.ForegroundStateColors.ContainsKey(job.Value.State) ? String.Format("background-color: {0};", JobHistoryRenderer.ForegroundStateColors[job.Value.State]) : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 87 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                           Write(job.Value.State);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                        </td>\r\n           " +
"             <td>\r\n                            <a class=\"job-method\" href=\"");


            
            #line 91 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                                   Write(LinkTo("/jobs/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 92 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                           Write(HtmlHelper.DisplayJob(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </a>\r\n                        </td>\r\n              " +
"          <td class=\"align-right\">\r\n");


            
            #line 96 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                             if (job.Value.EnqueuedAt.HasValue)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <span data-moment=\"");


            
            #line 98 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                              Write(JobHelper.ToTimestamp(job.Value.EnqueuedAt.Value));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                    ");


            
            #line 99 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                               Write(job.Value.EnqueuedAt);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </span>\r\n");


            
            #line 101 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                            }
                            else
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <em>n/a</em>\r\n");


            
            #line 105 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                    </tr>\r\n");


            
            #line 108 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");


            
            #line 112 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
    
            
            #line default
            #line hidden
            
            #line 112 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
Write(RenderPartial(new Paginator(pager)));

            
            #line default
            #line hidden
            
            #line 112 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                        
}

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
