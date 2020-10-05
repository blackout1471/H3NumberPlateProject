#include <string>
#include <bluetooth/bluetooth.h>
#include <bluetooth/hci.h>
#include <bluetooth/hci_lib.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/socket.h>

// Struct to hold the bluetooth information both client and server
struct Blue_Device {
    std::string Name;
    std::string Mac;
};

// Class to handle bluetooth connections
class BluetoothHandler {
    private:
        // The bluetooth devices id
        int m_DeviceId;

        // The socket the bluetooth can use
        int m_SocketId;
    public:
        BluetoothHandler();
        ~BluetoothHandler();
    public:
        // Method to search for bluetooth devices, returns null if none found
        Blue_Device* SearchDevices();
    public:
        // Opens the device / Initialises the bluetooth device, returns true if succeeds
        bool OpenDevice();

        // Closes the bluetooth device, returns true if succeed
        bool CloseDevice();

};