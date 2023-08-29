#nullable disable


using AppCoreLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.DataAccess.Entities
{
	public partial class Store : Record
	{
        [Required]
        [StringLength(150)]
        [DisplayName("Store Name")]
        public string Name { get; set; }

        [DisplayName("Is Virtual")]
        public bool IsVirtual { get; set; }


    }


    public partial class Store
    {
        [NotMapped]
		public string IsVirtualDisplay { get; set; }

    }

}
