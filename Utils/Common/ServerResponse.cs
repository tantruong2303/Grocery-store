using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System;

using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using backend.Controllers.DTO;

namespace backend.Utils.Common
{
    public class ServerResponse
    {
        public static void setFieldErrorMessage(string field, string key, ViewDataDictionary dataView)
        {
            string value = ValidatorOptions.Global.LanguageManager.GetString(key);
            dataView[$"{field}Error"] = value;
        }
        public static void setMessage(string key, ViewDataDictionary dataView)
        {
            string value = ValidatorOptions.Global.LanguageManager.GetString(key);
            dataView["message"] = value;
        }

        public static void setErrorMessage(string errorKey, ViewDataDictionary dataView)
        {
            string value = ValidatorOptions.Global.LanguageManager.GetString(errorKey);
            dataView["errorMessage"] = value;
        }


        public static void mapDetails(ValidationResult result, ViewDataDictionary dataView)
        {
            foreach (var failure in result.Errors)
            {
                string field = failure.PropertyName;
                string message = Helper.StringFormat(failure.ErrorMessage, failure.FormattedMessagePlaceholderValues);
                dataView[$"{field}Error"] = message;
            }
        }
    }
}