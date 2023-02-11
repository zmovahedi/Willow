﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Willow.Core.Contracts.ApplicationService.Commands;
using Willow.Core.Contracts.ApplicationService.Common;
using Willow.Core.Domain.Exceptions;
using Willow.Extensions.Logger.Abstractions;
using Willow.Extensions.Translations.Abstractions;

namespace Willow.Core.ApplicationService.Commands
{
    public class CommandDispatcherDomainExceptionHandlerDecorator : CommandDispatcherDecorator
    {
        #region Fields
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<CommandDispatcherDomainExceptionHandlerDecorator> _logger;
        #endregion

        #region Constructors
        public CommandDispatcherDomainExceptionHandlerDecorator(IServiceProvider serviceProvider,
                                                                ILogger<CommandDispatcherDomainExceptionHandlerDecorator> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public override int Order => 2;
        #endregion

        #region Send Commands
        public override async Task<CommandResult> Send<TCommand>(TCommand command)
        {
            try
            {
                var result = _commandDispatcher.Send(command);
                return await result;
            }
            catch (DomainStateException ex)
            {
                _logger.LogError(WillowEventId.DomainValidationException, ex, "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.", command.GetType(), command, DateTime.Now);
                return DomainExceptionHandlingWithoutReturnValue<TCommand>(ex);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is DomainStateException domainStateException)
                {
                    _logger.LogError(WillowEventId.DomainValidationException, domainStateException, "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.", command.GetType(), command, DateTime.Now);
                    return DomainExceptionHandlingWithoutReturnValue<TCommand>(domainStateException);
                }
                throw ex;
            }

        }

        public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
        {
            try
            {
                var result = await _commandDispatcher.Send<TCommand, TData>(command);
                return result;

            }
            catch (DomainStateException ex)
            {
                _logger.LogError(WillowEventId.DomainValidationException, ex, "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.", command.GetType(), command, DateTime.Now);
                return DomainExceptionHandlingWithReturnValue<TCommand, TData>(ex);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is DomainStateException domainStateException)
                {
                    _logger.LogError(WillowEventId.DomainValidationException, ex, "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.", command.GetType(), command, DateTime.Now);
                    return DomainExceptionHandlingWithReturnValue<TCommand, TData>(domainStateException);
                }
                throw ex;
            }
        }
        #endregion

        #region Privaite Methods
        private CommandResult DomainExceptionHandlingWithoutReturnValue<TCommand>(DomainStateException ex)
        {
            var commandResult = new CommandResult
            {
                Status = ApplicationServiceStatus.InvalidDomainState
            };

            commandResult.AddMessage(GetExceptionText(ex));

            return commandResult;
        }

        private CommandResult<TData> DomainExceptionHandlingWithReturnValue<TCommand, TData>(DomainStateException ex)
        {
            var commandResult = new CommandResult<TData>()
            {
                Status = ApplicationServiceStatus.InvalidDomainState
            };

            commandResult.AddMessage(GetExceptionText(ex));

            return commandResult;
        }

        private string GetExceptionText(DomainStateException domainStateException)
        {
            var translator = _serviceProvider.GetService<ITranslator>();
            if (translator == null)
                return domainStateException.ToString();

            var result = (domainStateException?.Parameters.Any() == true) ?
                 translator[domainStateException.Message, domainStateException.Parameters] :
                   translator[domainStateException?.Message];

            _logger.LogInformation(WillowEventId.DomainValidationException, "Domain Exception message is {DomainExceptionMessage}", result);

            return result;
        }
        #endregion
    }
}
