# HVPP-Configurator
AVR HVPP Configurator

Implemented AVR HVPP functions to configure or rescue your AVR micro controller.

It can be used to earse the lock byte from the chip.
Or it can help to recover your chip with wrong fuse settings.

The firmware is built in Arduino IDE and can be programmed to any Arduino compatiable chips with 8K+ flash memory.

At the moment, it support any 28 pins DIP and 32 pins TQFP AVR chips. (ATMEGA8/48/88/168/328 series)

A windows GUI is also built to make it easier to use.

Folder structure:

/Arduino/HVPP-Configurator => Source code of firmware for Arduino IDE
/Firmware                  => Pre-compiled firmware for ATMEGA8/168/328 (Intel HEX format)
/GUI/Source Code           => Source of Windows GUI
/GUI/Binary                => Pre-compiled Windows Desktop Application (Require .NET 4.0)
/Schematic                 => Schematics for the project
