using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReestr.Model
{
    class DeviceList
    {

        private List<Device> devices;

        public DeviceList(User user)
        {
            devices = DataBase.TryGetDevicesByUser(user);
        }

        public DeviceList()
        {
            devices = DataBase.TryGetDevicesAll();
        }

        public IEnumerable<Device> Devices
        {
            get { return devices.OrderBy(x => x.SerialNo); }
        }

        public IEnumerable<Device> FilterDevices
        {
            get { return devices.OrderByDescending(x => x.CreatedAt).Take(5).ToList(); ; }
        }

    }
}
