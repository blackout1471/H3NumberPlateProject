#include <string>
#include <stdio.h>
#include <ostream>
#include <iostream>
#include <alpr.h>
#include "bluetoothHandler.h"

int main() {
	alpr::Alpr* engine = new alpr::Alpr("us");
	alpr::AlprResults result = engine->recognize("ea7the.jpg");

	for (int i = 0; i < result.plates.size(); i++)
	{
		alpr::AlprPlateResult res = result.plates[i];

		std::cout << res.bestPlate.characters << std::endl;
	}

	BluetoothHandler* handler = new BluetoothHandler();
	if (!handler->OpenDevice())
		std::cout << "Error opening device" << std::endl;

	Blue_Device* devices = handler->SearchDevices();

	for (int i = 0; i < sizeof(devices) / sizeof(devices[0]); i++)
	{
		std::cout << "Device: " << devices[i].Name << " Mac: " << devices[i].Mac << std::endl;
	}

	handler->CloseDevice();

	return 0;
}