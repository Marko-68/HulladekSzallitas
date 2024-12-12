using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hulladékszállítás.Models
{
    public class Lakig
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id {  get; set; }
        public DateTime igeny { get; set; }
        //[Required, ForeignKey("Szolgaltatas")]
        [Required]
        public int SzolgaltatasId {  get; set; }
        public virtual Szolgaltatas? Szolgaltatas { get; set; }
        public int mennyiseg {  get; set; }
    }
}
