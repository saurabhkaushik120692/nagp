using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerApp.Model
{
    public class Customer
    {
        /// <summary>
        /// Gets or sets the Location ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string name { get; set; }
    }
}
