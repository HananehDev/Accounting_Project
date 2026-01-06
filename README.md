## Acounting Project

An accounting management application developed using **C# and Windows Forms**.
This project follows the **Repository Pattern** and uses **SQL Server** for data persistence,
providing a clean, maintainable, and scalable architecture.

---

## ✨ Features
- User management
- Customer management
- Accounting document registration
- Financial reports
- SQL Server database integration
- Layered architecture using Repository Pattern

---

## 🛠 Technologies Used
- C#
- Windows Forms
- SQL Server
- Repository Pattern
- Entity Framework
- Stimulsoft Reports (WinForms)

---

## 🧱 Project Architecture
The project is designed using the **Repository Pattern** to:
- Separate concerns
- Reduce tight coupling
- Improve maintainability
- Make future development easier

---

## ⚙ Requirements
- Visual Studio 2019 or later
- .NET Framework (compatible with the solution)
- SQL Server
- Git

---

## 🚀 Getting Started

### 1️⃣ Clone the repository
```bash
git clone https://github.com/HananehDev/Accounting_Project.git

2️⃣ Open the solution

Open the following file in Visual Studio: Accounting.sln

3️⃣ Configure database connection

Update the connection string in: Accounting.App/App.config


4️⃣ Setup database

Run the SQL Server script (if included) to create tables and initial data

Ensure SQL Server service is running

5️⃣ Run the application

Set Accounting.App as Startup Project

Press F5 or click Start

🗄 Database

Database Engine: SQL Server

Designed for accounting records, users, customers, and reports

Repository Pattern is used to abstract data access logic
```
1️⃣Login Form

<img align="center" src="https://github.com/HananehDev/Accounting_Project/blob/master/Screenshot%202026-01-06%20115734.png?raw=true" alt="Login Form" />

Shows:
- User authentication UI
- Username and password fields
- Entry point of the system


2️⃣ Main Dashboard

<img align="center" src="https://github.com/HananehDev/Accounting_Project/blob/master/Screenshot%202026-01-06%20115840.png?raw=true" alt="Login Form" />

Shows:
- Application layout
- Navigation menus
- Main modules of the accounting system


3️⃣ Customer / Account Management

<img align="center" src="https://github.com/HananehDev/Accounting_Project/blob/master/list.png?raw=true" alt="Login Form" />

Shows:
- Data grid with records
- Add / Edit / Delete operations
- CRUD functionality


4️⃣ New Transaction

<img align="center" src="https://github.com/HananehDev/Accounting_Project/blob/master/Tran.png?raw=true" alt="Login Form" /> 

Shows:
- Selection of a person from the list to associate with the transaction.
- Fields for transaction type (payment or receipt), amount, and a description.
- Buttons for saving the transaction.


5️⃣ Transaction Report

<img align="center" src="https://github.com/HananehDev/Accounting_Project/blob/master/dar.png?raw=true" alt="Login Form" />

<img align="center" src="https://github.com/HananehDev/Accounting_Project/blob/master/par.png?raw=true" alt="Login Form" />

Shows:
- Filters to select transactions by date range and account type.
- A table displaying the transaction history with columns for date, amount, and account involved.
- Options to print, preview, or delete the report.


🎯 Project Purpose

- This project was developed to practice and demonstrate:
- Windows Forms application architecture
- Repository Pattern implementation
- SQL Server integration
- Layered solution design
- Real-world accounting application concepts


👨‍💻 Author

Name: Hananeh Ranjbaran
GitHub: https://github.com/HananehDev
