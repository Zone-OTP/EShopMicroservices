using MediatR;


namespace BuildingBlocks.CQRS
{
   public interface ICommandHandler<in TCommand> :
        ICommandHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>
    {

    }

    public interface ICommandHandler<in Tcommand,TResponse>: IRequestHandler<Tcommand, TResponse>
        where Tcommand:ICommand<TResponse>
        where TResponse : notnull 
    {
         
    }
}
