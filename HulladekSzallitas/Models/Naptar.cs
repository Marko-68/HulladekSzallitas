using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hulladékszállítás.Models
{
    public class Naptar
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public DateTime datum { get; set; }
        //[Required, ForeignKey("Szolgaltatas")]
        [Required]
        public int SzolgaltatasId { get; set; }
        public virtual Szolgaltatas? Szolgaltatas { get; set; }
    }
}
