using AutoMapper;
using Investimento.Domain._2._1_Interface;
using Investimento.Domain.Notifications;
using FluentValidation;
using FluentValidation.Results;



namespace Investimento.Application._1._2_AppService
{
    public class BaseService
    {
        private readonly IDomainNotificationHandler _notificator;
        protected readonly IMapper _mapper;


        protected BaseService(IDomainNotificationHandler notificator,
                              IMapper mapper)
        {
            _notificator = notificator;
            _mapper = mapper;
        }

        protected void NotifyError(string message)
        {
            _notificator.Handle(new DomainNotification(message));
        }

        protected void NotifyError(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                NotifyError(error.ErrorMessage);
            }
            
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : class
        {
            var validator = validation.Validate(entity);
            if (validator.IsValid) return true;
            NotifyError(validator);
            return false;
        }

    }
}
