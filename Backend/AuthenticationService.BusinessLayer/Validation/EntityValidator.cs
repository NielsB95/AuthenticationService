using AuthenticationService.BusinessLayer.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.BusinessLayer.Validation
{
	public class EntityValidator
	{
		public static IList<ValidationResult> Validate<T>(T entity) where T : Entity
		{
			// Create the context
			var validationContext = new ValidationContext(entity);

			// Create a list where the results will be sotred in.
			var validationsResults = new List<ValidationResult>();

			// Validate the entity.
			bool correct = Validator.TryValidateObject(entity, validationContext, validationsResults, true);

			// Return the list of validation results.
			return validationsResults;
		}
	}
}
