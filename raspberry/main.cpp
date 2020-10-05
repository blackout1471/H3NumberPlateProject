#include <string>
#include <stdio.h>
#include <ostream>
#include <iostream>
#include <alpr.h>
#include "bluetoothHandler.h"

int main() {
	// Start recognizer library, set country to us
	alpr::Alpr* engine = new alpr::Alpr("us");

	// Recognize image given
	alpr::AlprResults result = engine->recognize("ea7the.jpg");

	// Loop results for each numberplate in picture
	// print out the best one for each image
	for (int i = 0; i < result.plates.size(); i++)
	{
		alpr::AlprPlateResult res = result.plates[i];

		std::cout << res.bestPlate.characters << std::endl;
	}

	// Bluetooth handler init
	BluetoothHandler* handler = new BluetoothHandler();
	if (!handler->OpenDevice())
		std::cout << "Error opening device" << std::endl;

	// Search all devices
	Blue_Device* devices = handler->SearchDevices();

	// Print out all the available devices
	for (int i = 0; i < sizeof(devices) / sizeof(devices[0]); i++)
	{
		std::cout << "Device: " << devices[i].Name << " Mac: " << devices[i].Mac << std::endl;
	}

	// Close device
	handler->CloseDevice();

	return 0;
}