using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Università.DataModels
{
    internal abstract class Persona
    {
        
        [Required]
        [MinLength(2, ErrorMessage = "Il nome deve contenere almeno 2 caratteri!"), MaxLength(20, ErrorMessage = "Il nome deve contenere al massimo 20 caratteri!")]
        internal abstract string Nome { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Il cognome deve contenere almeno 2 caratteri!"), MaxLength(20, ErrorMessage = "Il cognome deve contenere al massimo 20 caratteri!")]
        internal abstract string Cognome { get; set; }
        [Required]
        [Range(18, 100, ErrorMessage = "L'età deve essere compresa tra 18 e 100 anni!")]
        internal abstract int Eta { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "L'indirizzo deve contenere almeno 5 caratteri!"), MaxLength(50, ErrorMessage = "L'indirizzo deve contenere al massimo 50 caratteri!")]
        internal abstract string Address { get; set; }
        [Required]
        internal abstract MainEnumerators.Genere Genere { get; set; }
        [Required]
        internal abstract MainEnumerators.Facolta Facolta { get; set; }
        [Required]
        internal abstract List<EventoPlanning> Planning { get; set; } 


    }
}
