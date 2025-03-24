using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Università.DataModels
{
    internal class Docente : Persona
    {
        [Required]
        [Key]
        [MinLength(5, ErrorMessage = "L'Id deve contenere 5 caratteri!"), MaxLength(5, ErrorMessage = "L'Id deve contenere 5 caratteri!")]
        internal string Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Il nome deve contenere almeno 2 caratteri!"), MaxLength(20, ErrorMessage = "Il nome deve contenere al massimo 20 caratteri!")]
        internal override string Nome { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Il cognome deve contenere almeno 2 caratteri!"), MaxLength(20, ErrorMessage = "Il cognome deve contenere al massimo 20 caratteri!")]
        internal override string Cognome { get; set; }
        [Required]
        [Range(18, 100, ErrorMessage = "L'età deve essere compresa tra 18 e 100 anni!")]
        internal override int Eta { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "L'indirizzo deve contenere almeno 5 caratteri!"), MaxLength(50, ErrorMessage = "L'indirizzo deve contenere al massimo 50 caratteri!")]
        internal override string Address { get; set; }
        [Required]
        internal override MainEnumerators.Genere Genere { get; set; }
        internal Docente()
        {
            Id = string.Empty;
            Nome = string.Empty;
            Cognome = string.Empty;
            Eta = 0;
            Address = string.Empty;
            Genere = MainEnumerators.Genere.None;
        }
        internal Docente(string id, string nome, string cognome, int eta, string address, MainEnumerators.Genere genere)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
            Address = address;
            Genere = genere;
        }
        internal void Print()
        {
            Console.WriteLine($"Id: {Id,-7} Nome: {Nome,-10} Cognome: {Cognome,-15}Età: {Eta,-5}Indirizzo: {Address,-25}Genere: {Genere,-5}");

        }

    }
}
