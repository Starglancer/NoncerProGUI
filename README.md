# Nimiq RPC

## Description

A Windows Forms based gui for the Nimiq client RPC calls

## Screenshots

![Status](https://user-images.githubusercontent.com/124823644/235308411-dc8d3cc9-b7b1-4d1b-83e9-28fa11b8ad53.png)

![PeerCount](https://user-images.githubusercontent.com/124823644/235308415-77d07d7b-d8b6-40cd-91b8-044b11994089.png)

![Mining](https://user-images.githubusercontent.com/124823644/235308421-6df5bfd9-58c5-4ecb-84c7-8eda8821a767.png)

## Features

 - Will work with both local and remote Nimiq clients
 - Heartbeat check every 10 seconds to ensure client is still running
 - Tray icon for running in the background to monitor status
 - Display details of blocks, peers, transactions and mining status
 - Rolling 60 minute trend charts for block number, peer count and hash rate
 - control mining parameters and client logging level
 - Export any data to csv file
 - DOES NOT create transactions by design. Please use the standard Nimiq web wallet for that purpose
 
## Requirements

 - Network connection to the internet
 - No inbound ports need to be opened
 - Microsoft Windows operating system (I have tested on Windows 10 only)
 - Dot Net Framework 4.7.2. This will be installed at deployment time if not already present
 
## To Do List

- Fix any bugs identified by users
- Make enhancements identified by users
 
## Acknowledgements

- Thanks to rraallvv for his [NimiqClientSharp](https://github.com/rraallvv/NimiqClientSharp) wrapper used in this project
- Thanks to [Advanced Installer](https://www.advancedinstaller.com/) for their excellent installer which has been used from release 1.00 onwards
