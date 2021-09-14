using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace Backend.Utils.Common
{
    static public class ServerResponse
    {
        public static void SetFieldErrorMessage(string field, string key, ViewDataDictionary dataView)
        {
            string value = ValidatorOptions.Global.LanguageManager.GetString(key);
            dataView[$"{field}Error"] = value;
        }
        public static void SetMessage(string key, ViewDataDictionary dataView)
        {
            string value = ValidatorOptions.Global.LanguageManager.GetString(key);
            dataView["message"] = value;
        }

        public static void SetErrorMessage(string errorKey, ViewDataDictionary dataView)
        {
            string value = ValidatorOptions.Global.LanguageManager.GetString(errorKey);
            dataView["errorMessage"] = value;
        }


        public static void MapDetails(ValidationResult result, ViewDataDictionary dataView)
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