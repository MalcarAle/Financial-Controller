using System.ComponentModel.DataAnnotations;

namespace Fina.Core.Requests.Categories
{
    public class DeleteCategoryRequest : Request
    {
        [Required(ErrorMessage = "Id não identificado")]
        public long Id { get; set; }
    }
}
