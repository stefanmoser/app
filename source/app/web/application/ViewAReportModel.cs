﻿using app.web.core;

namespace app.web.application
{
    public class ViewAReportModel : IImplementAUseCase
    {
        IQueryReportModels query_engine;
        IDisplayReportModels response_engine;

        public ViewAReportModel(IQueryReportModels query_engine, IDisplayReportModels response_engine)
        {
            this.query_engine = query_engine;
            this.response_engine = response_engine;
        }

        public void process(IContainRequestInformation request)
        {
            response_engine.display(query_engine.query_for_report_model(request));
        }
    }
}