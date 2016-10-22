using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HelperClasses
{
    public class BalanceCalculator
    {
        public double? CalculateBalance(int ClientID)
        {
            //Update the clients balance due
            PlanetVetEntities pve = new PlanetVetEntities();
            double? TotalBalance = 0;

            //Get clients pets, check the procedures/inventory used on them
            //Calculate the charges for the client 
            //for both inventory items
            //as well as procedures
            List<Patient> PatientList = pve.Patients.Where(p => p.ClientID == ClientID).ToList();
            foreach(Patient p in PatientList)
            {
                List<Procedure> ProcedureList = pve.Procedures.Where(pr => pr.PatientID == p.PatientID).ToList();
                //Procedures done to pet p
                foreach (Procedure pr in ProcedureList)
                {
                    TotalBalance += pr.ProcedureCost;
                }

                //Inventory used for pet p
                List<InventoryLog> InventoryUsedForProcedures = pve.InventoryLogs.Where(inv => inv.PatientID == p.PatientID).ToList();
                foreach(InventoryLog il in InventoryUsedForProcedures)
                {
                    TotalBalance += il.ChargeToClient;
                }
            }

            return TotalBalance;
        }
    }
}
