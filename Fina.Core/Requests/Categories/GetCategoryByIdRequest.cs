using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Requests.Categories
{
    public class GetCategoryByIdRequest : Request
    {
        [Required(ErrorMessage="O Id é inválido")]
        public long Id { get; set; }
    }
}
