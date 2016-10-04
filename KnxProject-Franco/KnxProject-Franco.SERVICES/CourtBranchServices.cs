using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnxProject_Franco.SERVICES
{
    public class CourtBranchServices: CONTRACTS.ICourtBranch
    {
        public List<CONTRACTS.Entities.CourtBranch> GetAllCourtBranches()
        {
            //FAKE LIST
            List<int> LawyersIn = new List<int>();
            LawyersIn.Add(0);
            LawyersIn.Add(1);
            List<CONTRACTS.Entities.CourtBranch> cb = new List<CONTRACTS.Entities.CourtBranch> { new CONTRACTS.Entities.CourtBranch {
                                                                                                    ID = 0, Name="Derecho penal",
                                                                                                    LawyersInIDs = LawyersIn,
                                                                                                    Description = "Ciencia que estudia el conjunto de normas jurídicas que definen determinadas conductas como infracciones (delitos o faltas) y dispone la aplicación de sanciones (penas y medidas de seguridad) a quienes lo cometen." },
                                                                                                new CONTRACTS.Entities.CourtBranch {
                                                                                                    ID = 1,
                                                                                                    Name ="Bienes raíces",
                                                                                                    LawyersInIDs = LawyersIn,
                                                                                                    Description = "Abogados especializados en Bienes Raíces le pueden ayudar en todos los aspectos relacionados con la inversión en una propiedad, la compra de una casa, y demás asuntos  sobre Derecho Inmobiliario." }
                                                                                                };
            return cb;
        }
    }
}
