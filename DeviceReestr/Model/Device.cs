using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReestr.Model
{
    class Device
    {
        public string Id { get; private set; }
        public string SerialNo { get; private set; }
        public string Type { get; private set; }
        public string Description { get; private set; }
        public int OwnerId { get; private set; }
        public User Owner { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Device(string serialNo, string type, string description, User user)
        {
            Id = Guid.NewGuid().ToString();
            SerialNo = serialNo;
            Type = type;
            Description = description;
            Owner = user;
            OwnerId = user.Id;
            CreatedAt = DateTime.Now;
        }

        public Device(string guid, string serialNo, string type, string description, int ownerId, DateTime createdAt)
        {
            Id = guid;
            SerialNo = serialNo;
            Type = type;
            Description = description;
            OwnerId = ownerId;
            CreatedAt = createdAt;
        }

        internal bool Save()
        {
            return DataBase.TrySave(this);
        }
    }
}
