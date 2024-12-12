using System.ComponentModel.DataAnnotations.Schema;

namespace Hulladékszállítás.Models
{
    public class Szolgaltatas
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string tipus { get; set; }
        public string jelentes { get; set; }
    }
}
