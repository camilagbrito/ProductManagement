using Business.Models;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public abstract class BaseService
    {
        protected void Notify(string message)
        {

        }

        protected void Notify(ValidationResult validationResult) {
            
            foreach(var error in validationResult.Errors) {
                Notify(error.ErrorMessage);
            }
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> 
            where TE : Entity
        {
            var validator = validation.Validate(entity);
            
            if (validator.IsValid) return true;
          
            Notify(validator);

            return false;
        }
    }
}
