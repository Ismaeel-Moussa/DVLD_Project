# DVLD Project

## Overview
DVLD is a desktop application built using **.NET (Windows Forms)** and **C#**, utilizing a **SQL Server database**. The application follows a **3-Tier Architecture**, comprising:

1. **Presentation Layer**: User interface for interaction.
2. **Business Layer**: Contains the logic and rules of the application.
3. **Data Access Layer**: Manages communication with the database.

## Features
- Organized 3-tier architecture.
- Secure and modular database connectivity.
- Includes a database backup for easy setup.

## Prerequisites
1. **SQL Server** installed and running.
2. A compatible version of the **.NET Framework** for Windows Forms.
3. Your SQL Server credentials for connecting the application to the database.

## Setup Instructions
### 1. Restore the Database
- Locate the database backup file in the provided folder.
- Use **SQL Server Management Studio (SSMS)** or a similar tool to restore the database. Follow these steps:
  1. Open SSMS and connect to your SQL Server instance.
  2. Right-click on **Databases** > **Restore Database**.
  3. Choose the backup file and complete the restoration process.

### 2. Update the Database Connection String
- Navigate to the `DVLD_Presentation` folder in the project.
- Open the `App.config` file and update the `DataBaseConnectionString` entry with your database credentials:
  ```xml
  <add name="DataBaseConnectionString" connectionString="Server=.;Database=DVLD;User Id=your-username;Password=your-password;"/>
