using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Università.BLogic;

namespace Università.DataModels
{
    internal class Facolta
    {
        internal MainEnumerators.Facolta Nome{ get; set; }
        internal MainEnumerators.TipoCorso Tipo { get; set; }
        internal TimeOnly OrarioApertura { get; set; }
        internal TimeOnly OrarioChiusura { get; set; }
        internal bool Lab {  get; set; }
        internal List<Esame> Esami { get; set; } = [];
        //Lista filtrata da università
        internal List<Docente> Docenti { get; set; } = [];
        //Lista filtrata da università
        internal List<Studente> Studenti { get; set; } = [];
        
        internal List<string> Aule { get; set; } = ["A","B","C","D","E"];

        internal List<EventoPlanning> Calendario { get; set; } = [];


        internal Facolta(MainEnumerators.Facolta nome, MainEnumerators.TipoCorso tipo, TimeOnly orarioApertura, TimeOnly orarioChiusura)
        {
            Nome = nome;
            Tipo = tipo;
            OrarioApertura = orarioApertura;
            OrarioChiusura = orarioChiusura;
            if (nome == MainEnumerators.Facolta.Medicina || nome == MainEnumerators.Facolta.Ingegneria)
            {
                Lab = true;
                Aule.Add("Lab1");
                Aule.Add("Lab2");
            }                
            else
                Lab = false;
            ObtainData.OttieniListaStudentiFacolta(this);
            foreach (var item in Universita.Docenti)
            {
                if (item.Facolta == nome || item.Facolta2 == nome)
                    Docenti.Add(item);
            }
            
            //foreach (var item in Universita.Eventi)
            //{
            //    if (item.Facolta == nome)
            //        Calendario.Add(item);
            //}
        }
        internal Facolta()
        {
            Nome = MainEnumerators.Facolta.None;
            Tipo = MainEnumerators.TipoCorso.None;
            OrarioApertura = TimeOnly.MinValue;
            OrarioChiusura = TimeOnly.MinValue;
            Lab = false;
        }

        
    }
}
