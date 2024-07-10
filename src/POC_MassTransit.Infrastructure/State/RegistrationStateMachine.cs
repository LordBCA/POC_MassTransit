namespace POC_MassTransit.Infrastructure.State;

using MassTransit;
using POC_MassTransit.Application.Messaging.Events;

public class RegistrationStateMachine :
    MassTransitStateMachine<RegistrationState>
{
    public RegistrationStateMachine()
    {
        InstanceState(x => x.CurrentState);

        Event(() => RegistrationSubmitted, x => x.CorrelateById(m => m.Message.Id));

        Initially(
            When(RegistrationSubmitted)
                .Then(context =>
                {
                    context.Saga.RegistrationDate = DateTime.Now;
                    context.Saga.EventId = "";
                    context.Saga.MemberId = "";
                    //context.Saga.Payment = 12d;
                })
                .TransitionTo(Registered)
                //.Publish(context => new SendRegistrationEmail
                //{
                //    RegistrationId = context.Saga.CorrelationId,
                //    RegistrationDate = context.Saga.RegistrationDate,
                //    EventId = context.Saga.EventId,
                //    MemberId = context.Saga.MemberId
                //})
                //.If(context => context.Saga.Payment < 50m && context.GetRetryAttempt() == 0,
                //    fail => fail.Then(_ => throw new ApplicationException("Totally random, but you didn't pay enough for quality service")))
                //.Publish(context => new AddEventAttendee
                //{
                //    RegistrationId = context.Saga.CorrelationId,
                //    EventId = context.Saga.EventId,
                //    MemberId = context.Saga.MemberId
                //})
        );
    }

    //
    // ReSharper disable MemberCanBePrivate.Global
    public State Registered { get; } = null!;
    public Event<AssigmentCreatedEvent> RegistrationSubmitted { get; } = null!;
}