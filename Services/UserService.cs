using System;
using backend.Controllers.DTO;
using FluentValidation.Results;
using backend.Utils.Common;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace backend.Services
{
    public class UserService
    {
        public Boolean registerHandler(RegisterDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new RegisterDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.mapDetails(result, dataView);
                return false;
            }
            return true;
        }
    }
}