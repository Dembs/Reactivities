using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity {get; set;}
        }

        public class Handler : IRequestHandler<Command>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
            _context = context;
                
            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);//We dont use the async version of ADD here because we dont touch the DB
                await _context.SaveChangesAsync();

            }
        }
    }
}