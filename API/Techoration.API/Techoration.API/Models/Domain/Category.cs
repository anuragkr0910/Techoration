using System.ComponentModel.DataAnnotations.Schema;

namespace Techoration.API.Models.Domain
{
    public class Category
    {
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? SerialNo { get; set; }

        public string Name { get; set; }

        public string URLHandle { get; set; }
    }
}
