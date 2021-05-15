# AntiVehicle-Pro
A new and improved version of AntiVehicle that has a ton more features!

AntiVehicle Pro is a free version of AntiVehicle that has been made for those who are need in of more moderation features for vehicles in Unturned. The plugin comes with a vehicle blacklist (stops player from entering blacklisted vehicles) and a vehicle ban list to ban players from using vehicles (once added to the config the changes will apply after a server restart occurs).

## Adding a blacklisted vehicle

Please make sure to create a new "Vehicle" when adding a new blacklisted ID. An example on doing multiple IDs is shown below.
```xml
  <Blacklisted>
    <Vehicle>
      <VehicleId>1111</VehicleId>
    </Vehicle>
    <Vehicle>
      <VehicleId>86</VehicleId>
    </Vehicle>
  </Blacklisted>
```
## Adding a VehicleBan to a player

Please make sure to create a new "Vehicleban" when adding a new player as shown below.
```xml
  <VehicleBanned>
    <Vehicleban>
      <Player>76561198190129334</Player>
    </Vehicleban>
    <Vehicleban>
      <Player>76561198168236438</Player>
    </Vehicleban>
  </VehicleBanned>
```