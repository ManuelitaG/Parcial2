using Parcial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Parcial2.Clases
{
    public class clsPesaje
    {
        private DBExamenEntities1 dbExamen = new DBExamenEntities1();
        private clsCamion camion = new clsCamion();
        public Pesaje pesaje { get; set; }

        public string Insertar(string placa, int nroEjes, string marca)
        {
            try
            {
                if (camion.ConsultarXPlaca(pesaje.PlacaCamion) == null)
                {
                    CrearCamion(placa, nroEjes, marca);
                }

                dbExamen.Pesajes.Add(pesaje);
                dbExamen.SaveChanges();
                return "El pesaje se ha guardado correctamente :)";

            }
            catch (Exception ex)
            {
                return "Error al intentar insertar el pesaje :( ";
            }


        }

        public void CrearCamion(string placa, int nroEjes, string marca)
        {
            var cam = new Camion
            {
                Placa = placa,
                Marca = marca,
                NumeroEjes = nroEjes
            };
            dbExamen.Camions.Add(cam);
            dbExamen.SaveChanges();
        }

        public IQueryable ListarImagenes(string idPlaca)
        {
            using (var cont = new DBExamenEntities1())
            {

                return from P in dbExamen.Set<Pesaje>()
                       join C in dbExamen.Set<Camion>()
                       on P.PlacaCamion equals C.Placa
                       join FT in dbExamen.Set<FotoPesaje>()
                       on P.id equals FT.idFotoPesaje
                       where P.PlacaCamion == idPlaca
                       orderby FT.idFotoPesaje
                       select new
                       {
                           placa = P.PlacaCamion,
                           Ejes = C.NumeroEjes,
                           marca = C.Marca,
                           fecha = P.FechaPesaje,
                           peso = P.Peso,
                           imagenes = FT.ImagenVehiculo
                       };
            }
        }

        public string GuardarImagenPesaje(int idPesaje, List<string> Imagenes)
        {
            try
            {
                foreach (string imagen in Imagenes)
                {
                    FotoPesaje FPesaje = new FotoPesaje();
                    FPesaje.idPesaje = idPesaje;
                    FPesaje.ImagenVehiculo = imagen;
                    dbExamen.FotoPesajes.Add(FPesaje);
                    dbExamen.SaveChanges();
                }
                return "Se guardó la información en la base de datos :)";
            }
            catch (Exception ex)
            {
                return "Error :( " + ex.Message;
            }
        }


    }
}