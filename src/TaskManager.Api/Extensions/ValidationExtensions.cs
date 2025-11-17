//Minimal APIs don’t automatically run data-annotation validation like [ApiController] does for controllers, so we validate manually once at the endpoint entrance

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Api.Extensions
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// Try validate an object using System.ComponentModel.DataAnnotations.
        /// If invalid, returns a ProblemDetails (ValidationProblem) result in the out parameter.
        /// If valid, out result is null and method returns true.
        /// </summary>
        public static bool TryValidate<T>(this T instance, out IResult? validationProblem)
        {
            var context = new ValidationContext(instance!);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instance!, context, results, validateAllProperties: true);


            if (isValid)
            {
                validationProblem = null;
                return true;
            }


            //Convert ValidationResultsinto a shape ValidationProblem expects
            var errors = results.SelectMany(r => (r.MemberNames?.DefaultIfEmpty(string.Empty) ?? new[] { string.Empty })
                .Select(m => new { Member = m ?? string.Empty, message = r.ErrorMessage ?? string.Empty }))
                .GroupBy(x => x.Member)
                .ToDictionary(
                    g => string.IsNullOrWhiteSpace(g.Key) ? "" : g.Key,
                    g => g.Select(x => x.message).ToArray()
                );

            validationProblem = Results.ValidationProblem(errors);
            return false;
        }


    }
}
