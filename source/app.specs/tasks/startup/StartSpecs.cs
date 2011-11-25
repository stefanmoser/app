using Machine.Specifications;
using app.tasks.startup;
using developwithpassion.specifications.rhinomocks;

namespace app.specs.tasks.startup
{
  [Subject(typeof(Start))]
  public class StartSpecs
  {
     public class concern : Observes
     {
       public class when_we_will_name_this_later : concern
       {
         Because b = () =>
           result = Start.by<OurStartUpStep>();

         It should_create_a_builder_of_start_up_steps = () =>
           result.ShouldBeOfType<BuildStartUpSteps>();

         It should_have_the_step_in_its_list = () =>
            result.start_up_steps.ShouldContain(typeof(OurStartUpStep));

         static BuildStartUpSteps result;
       }

       public class OurStartUpStep : IRunAStartupStep
       {
         public void run()
         {
           throw new System.NotImplementedException();
         }
       }
     }
  }
}