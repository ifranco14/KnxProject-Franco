using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS.Entities;

namespace KnxProject_Franco.SERVICES
{
    public class CourtBranchServices: CONTRACTS.ICourtBranch
    {
        public bool Create(CourtBranchModel cb)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }

        public CourtBranchModel Details(int id)
        {
            return new CourtBranchModel();
        }

        public bool Edit(int id, CourtBranchModel cb)
        {
            return true;
        }

        public List<CONTRACTS.Entities.CourtBranchModel> GetAllCourtBranches()
        {
            //FAKE LIST
            //List<int> LawyersIn = new List<int>();
            //LawyersIn.Add(0);
            //LawyersIn.Add(1);
            //List<CONTRACTS.Entities.CourtBranchModel> cb = new List<CONTRACTS.Entities.CourtBranchModel> { new CONTRACTS.Entities.CourtBranchModel {
            //                                                                                        ID = 0, Name="Derecho penal",
            //                                                                                        LawyersInIDs = LawyersIn,
            //                                                                                        Description = "Ciencia que estudia el conjunto de normas jurídicas que definen determinadas conductas como infracciones (delitos o faltas) y dispone la aplicación de sanciones (penas y medidas de seguridad) a quienes lo cometen." },
            //                                                                                    new CONTRACTS.Entities.CourtBranchModel {
            //                                                                                        ID = 1,
            //                                                                                        Name ="Bienes raíces",
            //                                                                                        LawyersInIDs = LawyersIn,
            //                                                                                        Description = "Abogados especializados en Bienes Raíces le pueden ayudar en todos los aspectos relacionados con la inversión en una propiedad, la compra de una casa, y demás asuntos  sobre Derecho Inmobiliario." }
            //                                                                                    };
            //return cb;
            return new List<CourtBranchModel>();
        }
    }
}
