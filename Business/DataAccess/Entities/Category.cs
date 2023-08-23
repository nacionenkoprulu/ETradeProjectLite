#nullable disable

using AppCoreLite;
using System.ComponentModel.DataAnnotations;

namespace Business.DataAccess.Entities
{

    #region Entity
    public class Category : Record
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }


    }
    #endregion
}
