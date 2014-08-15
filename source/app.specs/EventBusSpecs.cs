 using app.bus;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(EventBus))]  
  public class EventBusSpecs
  {
    public abstract class concern : Observes<IPublishEvents,
      EventBus>
    {
        
    }

   
    public class when_an_event_is_published : concern
    {
        
      It  = () =>        
        
    }
  }
}
