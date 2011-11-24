using Machine.Specifications;
using app.web.application;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(ViewAReportModel))]
    public class ViewAReportModelSpecs
    {
        public abstract class concern : Observes<IImplementAUseCase,
                                          ViewAReportModel>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
                {
                    request = fake.an<IContainRequestInformation>();
                    report_model = new object();

                    response_engine = depends.on<IDisplayReportModels>();
                    query_engine = depends.on<IQueryReportModels>();
                    query_engine.setup(x => x.query_for_report_model(request)).Return(report_model);
                };

            Because b = () =>
                sut.process(request);

            It should_query_for_the_report_model = () =>
                query_engine.received(x => x.query_for_report_model(request));

            It should_display_the_report_model = () =>
              response_engine.received(x => x.display(report_model));

            static IQueryReportModels query_engine;
            static IContainRequestInformation request;
            static IDisplayReportModels response_engine;
            static object report_model;
        }
    }
}