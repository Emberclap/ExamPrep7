using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public List<Drone> Drones { get; set; }
        public int Count => Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (!string.IsNullOrEmpty(drone.Name) && !string.IsNullOrEmpty(drone.Brand) && drone.Range >= 5 && drone.Range <= 15)
            {
                if (this.Capacity > Count)
                {
                    Drones.Add(drone);
                    return $"Successfully added {drone.Name} to the airfield.";
                }
                else { return "Airfield is full."; }
            }
            else
            {
                return "Invalid drone.";
            }
        }
        public bool RemoveDrone(string name) => Drones.Remove(Drones.Where(x => x.Name == name).FirstOrDefault());

        public int RemoveDroneByBrand(string brand)
        {
            int count = 0;
            count = Drones.RemoveAll(x => x.Brand == brand);
            return count;
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(x => x.Name == name);
            if (drone != null)
            {
                drone.Available = false;
            }
            return drone;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = new List<Drone>();
            drones = Drones.FindAll(x => x.Range >= range).ToList();
            foreach (Drone drone in drones)
            {
                drone.Available = false;
            }
            return drones;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (var drone in Drones.Where(x => x.Available == true))
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }

}
