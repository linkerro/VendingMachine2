using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class VendingMachine
    {
        private Dictionary<int, Rack> _racks=new Dictionary<int, Rack>();

        public Dictionary<int, Rack> Racks
        {
            get
            {
                return _racks;
            }
        }

        public void InstallRacks(Dictionary<int, Rack> racks)
        {
            _racks = racks
                .Union(_racks)
                .ToDictionary(x=>x.Key,x=>x.Value);
        }
    }
}
