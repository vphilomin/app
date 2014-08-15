 using System.Web.UI;
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
        Establish context = () =>
        {
            the_message = new SomeMessage();

            subscribers = depends.on<IReceiveEvents>();
        };

        Because of = () => sut.publish(the_message);

        It should_notify_its_subscribers = () =>
            subscribers.received(x => x.Notify<Message>(the_message));

        static SomeMessage the_message;
    }

    public class SomeMessage
    {
    }
  }

    public interface IReceiveEvents
    {
        void Notify<Message>(Message message);
    }
}
