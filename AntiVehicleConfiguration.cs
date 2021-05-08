using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntiVehiclePro.Models;
using Rocket.API;
using Steamworks;

namespace AntiVehiclePro
{
    public class AntiVehicleConfiguration : IRocketPluginConfiguration
    {
        public bool ShouldAllowTirePop { get; set; }
        public bool ShouldAllowDamage { get; set; }
        public bool ShouldWarnCriminal { get; set; }
        public string ShouldWarnCriminalMessage { get; set; }
        public bool ShouldAlertOwner { get; set; }
        public Vehicle[] Blacklisted { get; set; }
        public Vehicleban[] VehicleBanned { get; set; }
        public void LoadDefaults()
        {
            ShouldAllowTirePop = false;
            ShouldAllowDamage = false;
            ShouldWarnCriminal = true;
            ShouldWarnCriminalMessage = "Hey stop that!";
            ShouldAlertOwner = true;
            VehicleBanned = new Vehicleban[]
            {
                new Vehicleban()
                {
                    Player = 76561198190129669
                }
            };
            Blacklisted = new Vehicle[]
            {
                new Vehicle()
                {
                    VehicleId = 1111
                }
            };
        }
    }
}
