# DVLD - Driver and Vehicle Licensing Directorate

## Overview
The Driver and Vehicle Licensing Directorate (DVLD) system is a comprehensive desktop application developed using .NET (Windows Forms) and C#. It employs a 3-Tier Architecture to ensure scalability and maintainability. The system manages core functionalities of the DVLD, including handling individuals, drivers, users, applications, tests, and licenses. Data management is facilitated through Microsoft SQL Server, with data access implemented via ADO.NET.

## Features
- **Application Management**: Allows users to submit and manage applications for various license types:
  - Commercial
  - Ordinary
  - Motorcycle
  - Local and International licenses.
- **Workflow Management**: Efficient processing of license applications with workflows for Local and International requests.
- **Secure Data Handling**: Implements password encryption before storage to ensure sensitive information is protected.
- **Database Operations**: Developed a Data Access Layer to manage all CRUD operations efficiently for DVLD entities.
- **3-Tier Architecture**: Separation of concerns into:
  1. **Presentation Layer**: User interface.
  2. **Business Logic Layer**: Processing and rules.
  3. **Data Access Layer**: Database communication.

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
### 3. Run the Project
- After setting up everything, you can run the project using the following credentials:
- Username: Ismaeel_Moussa
- Password: 5587
