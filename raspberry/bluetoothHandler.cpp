#pragma once
#include "bluetoothHandler.h"
#include "helperFunc.h"

BluetoothHandler::BluetoothHandler() : m_DeviceId(0),  m_SocketId(0) {
    /* inquiry_info *ii = NULL;
    int max_rsp, num_rsp;
    int len, flags;
    int i;
    char addr[19] = { 0 };
    char name[248] = { 0 };

    OpenDevice();

    len  = 8;
    max_rsp = 255;
    flags = IREQ_CACHE_FLUSH;
    ii = (inquiry_info*)malloc(max_rsp * sizeof(inquiry_info));
    
    num_rsp = hci_inquiry(m_DeviceId, len, max_rsp, NULL, &ii, flags);
    if( num_rsp < 0 ) perror("hci_inquiry");

    for (i = 0; i < num_rsp; i++) {
        ba2str(&(ii+i)->bdaddr, addr);
        memset(name, 0, sizeof(name));
        if (hci_read_remote_name(m_SocketId, &(ii+i)->bdaddr, sizeof(name), 
            name, 0) < 0)
        strcpy(name, "[unknown]");
        printf("%s  %s\n", addr, name);
    }

    free( ii );
    CloseDevice(); */
}

BluetoothHandler::~BluetoothHandler() {

}

Blue_Device* BluetoothHandler::SearchDevices() {
    int len = 8;
    int max_rsp = 255;
    int flags = IREQ_CACHE_FLUSH;
    int num_rsp;
    char tempName[255] = {0};
    char tempMac [19] = {0};

    inquiry_info* info = new inquiry_info[max_rsp];
    num_rsp = hci_inquiry(m_DeviceId, len, max_rsp, NULL, &info, flags);
    if (num_rsp < 0)
        printf("%d num_rsp", num_rsp);

    Blue_Device* devices = new Blue_Device[num_rsp];

    for (int i = 0; i < num_rsp; i++)
    {
        ba2str(&(info+i)->bdaddr, tempMac);
        //printf("%s\n", tempMac);
        //devices[i].Mac = tempMac;
        if (hci_read_remote_name(m_SocketId, &(info+i)->bdaddr, sizeof(tempName), tempName, 0) < 0)
            devices[i].Name = "Unknown";
        
        printf("%s %s\n", tempMac, tempName);
        //devices[i].Name = tempName;
    }

    delete info;

    return NULL;
}

bool BluetoothHandler::OpenDevice() {
    m_DeviceId = hci_get_route(NULL);
    m_SocketId = hci_open_dev(m_DeviceId);
    
    if (m_SocketId < 0 || m_DeviceId < 0)
        return false;

    return true;
}

bool BluetoothHandler::CloseDevice() {
    if (close(m_SocketId) < 0)
        return false;

    return true;
}