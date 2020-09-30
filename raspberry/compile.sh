#!/bin/bash
g++ -I ./includes/openalpr/src/openalpr main.cpp bluetoothHandler.h bluetoothHandler.cpp -lopenalpr -lbluetooth