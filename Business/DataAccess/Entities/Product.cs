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
        [Required(ErrorMessage = "{0} is required!")]
        [MinLength(3, ErrorMessage = "{0} must be min {1} characters!")]
        [MaxLength(200, ErrorMessage = "{0} must be max {1} characters!")]
        public string Name { get; set; }

        [StringLength(300, ErrorMessage = "{0} must be max {1} characters!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is required!")] //Zorunludur mesajını alabilmek için bunu koyduk
        [Range(0, 1000000, ErrorMessage = "{0} must be {1} or positive!")] 
        [DisplayName("Stock Amount")]
        public int? StockAmount { get; set; } //Normalde soru işareti koymaya gerek yok ancak zorunludur error mesajını almak için bu yöntemi uyguladık.

        [Required(ErrorMessage = "{0} is required!")] //Zorunludur mesajını alabilmek için bunu koyduk
        [Range(0, double.MaxValue)]
        [DisplayName("Unit Price")]
        public double? UnitPrice { get; set; } //Normalde soru işareti koymaya gerek yok ancak zorunludur error mesajını almak için bu yöntemi uyguladık.

        [DisplayName("Expiration Date")]
        public DateTime? ExpirationDate { get; set; }

        [DisplayName("Continued")]
        public bool IsContinued { get; set; }

        [DisplayName("Category")]
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
