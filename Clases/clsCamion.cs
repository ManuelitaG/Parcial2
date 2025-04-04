using Parcial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial2.Clases
{
    public class clsCamion
    {
        private DBExamenEntities1 dbExamen = new DBExamenEntities1();
        private Camion camion;

        public Camion ConsultarXPlaca(string Placa)
        {
            return dbExamen.Camions.FirstOrDefault(e => e.Placa == Placa); 
        }
    }
}