using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;

namespace AntiVehiclePro
{
    public class AntiVehicle : RocketPlugin<AntiVehicleConfiguration>
    {
        protected override void Load()
        {
            Logger.Log("AntiVehicle is now loaded");
            VehicleManager.onDamageTireRequested += VehicleManager_onDamageTireRequested;
            VehicleManager.onEnterVehicleRequested += VehicleManager_onEnterVehicleRequested;
            VehicleManager.onDamageVehicleRequested += VehicleManager_onDamageVehicleRequested;
        }

        private void VehicleManager_onDamageVehicleRequested(CSteamID instigatorSteamID, InteractableVehicle vehicle, ref ushort pendingTotalDamage, ref bool canRepair, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            if (instigatorSteamID != CSteamID.Nil)
            {
                UnturnedPlayer sameplayer = UnturnedPlayer.FromCSteamID(instigatorSteamID);
                if (instigatorSteamID != vehicle.lockedOwner)
                {
                    if (pendingTotalDamage >= 20)
                    {
                        if (sameplayer.IsAdmin != true)
                        {
                            if (Configuration.Instance.ShouldAllowDamage == false)
                            {
                                shouldAllow = false;
                            }
                        }
                    }
                }
            }
        }

        private void VehicleManager_onEnterVehicleRequested(Player player, InteractableVehicle vehicle, ref bool shouldAllow)
        {
            UnturnedPlayer unturnedPlayer = UnturnedPlayer.FromPlayer(player);
            var blacklist = Configuration.Instance.Blacklisted.FirstOrDefault(x => x.VehicleId == vehicle.id);
            var banned = Configuration.Instance.VehicleBanned.FirstOrDefault(x => x.Player == unturnedPlayer.SteamProfile.SteamID64);
            if (banned != null)
            {
                UnturnedChat.Say("You are not allowed to enter this vehicle!");
                Logger.Log($"{unturnedPlayer.DisplayName}({unturnedPlayer.CSteamID}) is attempting to get into a vehicle! They are vehicle banned!");
                shouldAllow = false;
            }
            if (blacklist != null)
            {
                shouldAllow = false;
                UnturnedChat.Say(unturnedPlayer, "You are not allowed to enter this vehicle!");
                Logger.Log($"Prevented {unturnedPlayer.DisplayName}({unturnedPlayer.CSteamID}) from entering a vehicle with an ID of {vehicle.id}");
            }
        }

        private void VehicleManager_onDamageTireRequested(CSteamID instigatorSteamID, InteractableVehicle vehicle, int tireIndex, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            if (Configuration.Instance.ShouldAllowTirePop == false)
            {
                shouldAllow = false;
            }
            if (instigatorSteamID != CSteamID.Nil && vehicle.lockedOwner != CSteamID.Nil)
            {
                UnturnedPlayer criminal = UnturnedPlayer.FromCSteamID(instigatorSteamID);
                UnturnedPlayer owner = UnturnedPlayer.FromCSteamID(vehicle.lockedOwner);
                if (Configuration.Instance.ShouldWarnCriminal == true)
                {
                    UnturnedChat.Say(criminal, $"{Configuration.Instance.ShouldWarnCriminalMessage}");
                }
                
            }
        }

        protected override void Unload()
        {
            Logger.Log("AntiVehicle is now unloaded");

        }
    }
}
