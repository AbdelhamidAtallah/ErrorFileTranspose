using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ErrorTranspose.Models
{
    public class Error
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ErrorId { get; set; }
        public string? MAJ { get; set; }
        public string? TypeModification { get; set; }
        public string? NatureErreur { get; set; }
        public string? CodeErreur { get; set; }
        public string? Omschrijving { get; set; }
        public string? Libelle { get; set; }
        public string? NatureErreur2 { get; set; }
        public string? CodeErreur2 { get; set; }
        public string? NatureErreur3 { get; set; }
        public string? CodeErreur3 { get; set; }
        public string? NatureErreur4 { get; set; }
        public string? CodeErreur4 { get; set; }
        public string? Remarques { get; set; }
    }
}
