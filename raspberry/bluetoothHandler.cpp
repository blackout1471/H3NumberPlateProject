#pragma once
#include "bluetoothHandler.h"
#include "helperFunc.h"

BluetoothHandler::BluetoothHandler() : m_DeviceId(0),  m_SocketId(0) {
}

BluetoothHandler::~BluetoothHandler() {

}

// searches devices and returns possible devices
Blue_Device* BluetoothHandler::SearchDevices() {
    int len = 8;
    int max_rsp = 255;
    int flags = IREQ_CACHE_FLUSH;
    int num_rsp;
    char tempName[255] = {0};
    char tempMac [19] = {0};

    // setup max amount of devices to search for, and set max timeout per device
    inquiry_info* info = new inquiry_info[max_rsp];
    num_rsp = hci_inquiry(m_DeviceId, len, max_rsp, NULL, &info, flags);
    if (num_rsp < 0)
        printf("%d num_rsp", num_rsp);

    Blue_Device* devices = new Blue_Device[num_rsp];

    // Loop through all devices and get name for device
    for (int i = 0; i < num_rsp; i++)
    {
        ba2str(&(info+i)->bdaddr, tempMac);
        if (hci_read_remote_name(m_SocketId, &(info+i)->bdaddr, sizeof(tempName), tempName, 0) < 0)
            devices[i].Name = "Unknown";
        
        printf("%s %s\n", tempMac, tempName);
    }

    delete info;

    return devices;
}

// Opens the device for bluetooth
bool BluetoothHandler::OpenDevice() {
    m_DeviceId = hci_get_route(NULL);
    m_SocketId = hci_open_dev(m_DeviceId);
    
    if (m_SocketId < 0 || m_DeviceId < 0)
        return false;

    return true;
}

// Closes the bluetooth device
bool BluetoothHandler::CloseDevice() {
    if (close(m_SocketId) < 0)
        return false;

    return true;
}