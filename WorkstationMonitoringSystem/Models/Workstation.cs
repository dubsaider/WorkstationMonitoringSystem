using System.ComponentModel.DataAnnotations;

namespace WorkstationMonitoringSystem.Models
{
    public class Workstation
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CPU { get; set; }
        public string? GPU { get; set; }
        public int RAM { get; set;}
        public int Memory { get; set; }
        public int UsedMemory { get; set; }
        public string? GeneralInfoJSON { get; set; }
        public string? GPUInfoJSON { get; set; }


    }
}
