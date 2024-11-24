using csvSave.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvSave.application.implementation
{
    public class ImpPackageData: PackageData
    {
        public ImpPackageData(string shipmentIdentifier, string shipmentType, string weightUnits)
        {
            this.shipmentIdentifier = shipmentIdentifier;
            this.shipmentType = shipmentType;
            this.weightUnits = weightUnits;
        }

        public string getIdentifier() { return this.shipmentIdentifier; }

        public string getType() { return this.shipmentType; }

        public string getWeight() {  return this.weightUnits; }

    }
}
