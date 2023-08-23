#nullable disable

using AppCoreLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.DataAccess.Entities
{
    #region Entity
    public partial class Product : Record
    {
        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [Range(0, 1000000)]
        [DisplayName("Stock Amount")]
        public int StockAmount { get; set; }

        [Range(0, double.MaxValue)]
        public double UnitPrice { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public bool IsContinued { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }

    }
    #endregion

    public partial class Product
    {
        [NotMapped]
        [DisplayName("Unit Price")]
        public string UnitPriceDisplay { get; set; }

        [NotMapped]
        [DisplayName("Expiration Date")]
        public string ExpirationDateDisplay { get; set; }

        [NotMapped]
        [DisplayName("Is Continued")]
        public string IsContinuedDisplay { get; set; }

    }




    
}
