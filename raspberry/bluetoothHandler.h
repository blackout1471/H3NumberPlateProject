#include <string>
#include <bluetooth/bluetooth.h>
#include <bluetooth/hci.h>
#include <bluetooth/hci_lib.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/socket.h>

struct Blue_Device {
    std::string Name;
    std::string Mac;
};

class BluetoothHandler {
    private:
        int m_DeviceId;
        int m_SocketId;
    public:
        BluetoothHandler();
        ~BluetoothHandler();
    public:
        Blue_Device* SearchDevices();
    public:
        bool OpenDevice();
        bool CloseDevice();

};