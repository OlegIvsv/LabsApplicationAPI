using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LabsApplicationAPI.Models
{
    public static class AppValidationResultExtenions
    {
        public static IDictionary<string, string[]> AsValidationDictionary(this ModelStateDictionary msd)
        {
            var errorsDictionary = msd.ToDictionary(
                m => m.Key,
                m => m.Value.Errors
                .Select(e => e.ToString())
                .ToArray()
                );
            return errorsDictionary;
        }
    }
}
