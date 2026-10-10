#  Langham Hotel Management System

### IT502 Programming 1 — Assessment 2
**Student Name:** Krish
**Student ID:** 850006961
**Cohort:** NZDITTS226C-E
**Institution:** New Zealand Skills and Education College (NZSE)
**Date:** 2026

---

## Project Overview

The Langham Hotel Management System is a console-based application developed in C# using .NET 10.0. It was built as a pilot project for Langham Hotels, a luxury hotel chain headquartered in Queen Street, Auckland, New Zealand. The system manages day-to-day hotel operations including room addition, allocation, de-allocation, billing, and file-based data persistence.

---

##  Built With

| Technology | Version |
|---|---|
| Language | C# |
| Framework | .NET 10.0 (Long Term Support) |
| IDE | Visual Studio 2026 |
| Version Control | GitHub |
| File I/O | StreamReader / StreamWriter |

---

##  Project Structure

Assessment2Task2/
│
├── Assessment2Task2.sln
├── README.md
├── Assessment2Task2/
│ ├── Assessment2Task2.csproj
│ ├── Program.cs
│ │
│ ├── Models/
│ │ ├── Room.cs
│ │ ├── Customer.cs
│ │ └── RoomAllocation.cs
│ │
│ └── Services/
│ ├── RoomService.cs
│ ├── AllocationService.cs
│ └── FileService.cs


---

##  Features

| Menu Option | Feature | Status |
|---|---|---|
| 0 | Backup Room Allocations File |  Implemented |
| 1 | Add Rooms |  Implemented |
| 2 | Display Rooms |  Implemented |
| 3 | Allocate Rooms |  Implemented |
| 4 | De-Allocate Rooms |  Implemented |
| 5 | Display Room Allocation Details |  Implemented |
| 6 | Billing |  Under Construction |
| 7 | Save Room Allocations To File |  Implemented |
| 8 | Show Room Allocations From File |  Implemented |
| 9 | Exit |  Implemented |

---

##  Classes Overview

| Class | Location | Purpose |
|---|---|---|
| `Room` | Models/ | Stores room number and allocation status |
| `Customer` | Models/ | Stores customer number and name |
| `RoomAllocation` | Models/ | Links room to allocated customer |
| `RoomService` | Services/ | Handles add and display room logic |
| `AllocationService` | Services/ | Handles allocate and de-allocate logic |
| `FileService` | Services/ | Handles all file I/O and backup logic |
| `Program` | Root | Main entry point and menu loop |

---

##  Exception Handling

| Exception Type | Trigger Scenario |
|---|---|
| `FormatException` | User enters letters instead of numbers |
| `InvalidOperationException` | Allocating an already allocated room |
| `FileNotFoundException` | Reading file before it has been created |
| `UnauthorizedAccessException` | Writing to a read-only file |

All exceptions are handled using `try`, `catch`, and `finally` blocks with user-friendly error messages.

---

##  File I/O

| File | Purpose |
|---|---|
| `lhms_850006961.txt` | Primary file — stores all room allocation data with timestamps |
| `lhms_850006961_backup.txt` | Backup file — receives content from primary file during backup |

### File Location
Both files are saved automatically to:

C:\Users[YourUsername]\Documents\


### File Operations
- **Option 7** — Creates or appends to `lhms_850006961.txt` with a timestamp
- **Option 8** — Reads and displays all contents of `lhms_850006961.txt`
- **Option 0** — Copies content to backup file and clears the primary file

---

## ▶️ How to Run

### Prerequisites
- Visual Studio 2026
- .NET 10.0 SDK installed

### Steps
1. Clone the repository:
```bash
git clone https://github.com/krish-850006961/Assessment2Task2.git
```
2. Open `Assessment2Task2.sln` in Visual Studio
3. Press `Ctrl + Shift + B` to build
4. Press `Ctrl + F5` to run without debugging
5. Use the menu options `0` through `9` to navigate the system

---

## 🧪 Test Sequence
Add 3 rooms → Option 1
Display rooms → Option 2
Allocate 2 rooms → Option 3
View allocations → Option 5
De-allocate 1 room → Option 4
Save to file → Option 7
Show from file → Option 8
Run backup → Option 0
Exit → Option 9

---

## 📸 Sample Output
                LANGHAM HOTEL MANAGEMENT SYSTEM
                             MENU
Backup Room Allocations File
Add Rooms
Display Rooms
Allocate Rooms
De-Allocate Rooms
Display Room Allocation Details
Billing
Save the Room Allocations To a File
Show the Room Allocations From a File
Exit

Enter Your Choice Number Here:


---

##  Assessment Tasks Completed

| Task | Description | Marks |
|---|---|---|
| Task 1 | Environment Setup — Visual Studio + GitHub | 10 |
| Task 2 | Functionality Implementation — All menu options | 50 |
| Task 3 | Exception Handling — 4 exception types | 20 |
| Task 4 | End User Documentation — Word document | 20 |
| **Total** | | **100** |

---

## 🔗 Repository

https://github.com/krish-850006961/Assessment2Task2


---

##  Contact

**Student:** Krish
**Student ID:** 850006961
**Institution:** NZSE — New Zealand Skills and Education College
**Phone:** 0800 99 88 11
**Website:** nzse.ac.nz

---

*© 2026 Krish — IT502 Programming 1 — Assessment 2 — NZSE*