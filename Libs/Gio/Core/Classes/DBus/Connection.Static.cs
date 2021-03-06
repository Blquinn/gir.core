using System;

namespace Gio.Core.DBus
{
    public partial class Connection
    {
        public static Connection Get(BusType busType)
        {
            var handle = Methods.bus_get_sync((Gio.BusType)busType, IntPtr.Zero, out var error);
            HandleError(error);

            if(TryGetObject(handle, out Connection obj))
                return obj;
            else
                return new Connection(handle);
        }
    }
}