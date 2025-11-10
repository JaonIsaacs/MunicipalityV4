#  Municipal Services Application (C#)
##  Overview
The **Municipal Services Application** is a C#-based system designed to streamline and manage service requests within a municipal environment. The system allows users to create, view, and track various service requests such as maintenance issues, public works, or administrative queries.  

A key feature of the application is the **Service Request Status** module, which uses a **Binary Tree** data structure to represent and link related service requests efficiently. Each service request is represented as a node, connecting to related or dependent requests for easy navigation and retrieval.

---

##  Implementation Details

###  Binary Tree Integration
- Each node in the binary tree corresponds to a **Service Request** object containing:
  - Request ID  
  - Service Type  
  - Status (Pending, In Progress, Completed)  
  - Timestamp and description  

- The binary tree links related service requests (for example, a follow-up repair or escalation) to improve request tracking and contextual viewing.

- Using a binary tree improves:
  - **Traversal efficiency** — faster access to linked requests.
  - **Logical organization** — easier to maintain relationships between requests.
  - **Scalability** — as the number of service requests grows, performance remains consistent.

---

##  Project Structure

```
MunicipalityV4/
│
├── Program.cs                     # Entry point of the application
├── ServiceRequest.cs               # Defines the Service Request model
├── BinaryTree.cs                   # Implements the Binary Tree structure
├── ServiceRequestManager.cs        # Handles request creation, linking, and retrieval
├── UI/                             # Contains user interface components
│   ├── Menu.cs
│   ├── RequestView.cs
│
└── README.md                       # Project documentation (this file)
```

---

##  How to Compile and Run

### Requirements:
- **Visual Studio 2022** or later  
- **.NET 6.0 SDK** or newer  
- Windows 10 or later  

### Steps to Run:
1. **Clone the repository:**
   ```bash
   git clone https://github.com/JaonIsaacs/MunicipalityV4.git
   ```
2. **Open the project:**
   - Launch *Visual Studio* → `File` → `Open` → `Project/Solution`
   - Select the `.sln` file in the project directory.

3. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

4. **Build the solution:**
   ```bash
   dotnet build
   ```

5. **Run the program:**
   - Press **F5** in Visual Studio **or** use:
     ```bash
     dotnet run
     ```

6. **Interact with the program:**
   - Use the **main menu** to create, view, or manage service requests.
   - Access the **Service Request Status** section to explore binary tree-linked service records.

---

##  Example Usage
When viewing service requests:
- Selecting a request node displays all related requests connected through the binary tree.
- The user can traverse between linked requests using the navigation commands in the console UI.

Example:
```
[Root Request] Pothole Repair - Pending
├── Left: Follow-up Inspection - Completed
└── Right: Re-Repair Request - Pending
```

---

##  Learning Outcomes
- Implemented a **Binary Tree** to organize data hierarchically.
- Improved understanding of **recursive traversal** and **node management**.
- Applied object-oriented design principles in a municipal service management context.

---

##  Recommended Enhancements
Future improvements may include:
- Integration with **SQL Server** via *Entity Framework Core* for persistent storage.  
- Web API support using **ASP.NET Core** for mobile or web-based access.  
- UI enhancement using **Blazor** or **WPF** for interactive tree visualization.  
- Logging with **Serilog** or **Application Insights** for improved monitoring.

---

##  References

1. Microsoft Learn. (2024). *Binary Trees in C# – Data Structures and Algorithms.*  
   https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic  

2. GeeksforGeeks. (2024). *Introduction to Binary Trees and Their Applications.*  
   https://www.geeksforgeeks.org/binary-tree-data-structure  

3. TutorialsTeacher. (2024). *C# Data Structures and Collections.*  
   https://www.tutorialsteacher.com/csharp/csharp-collections  

4. W3Schools. (2024). *C# Programming Language Basics and Examples.*  
   https://www.w3schools.com/cs  

5. Microsoft Learn. (2024). *Entity Framework Core Overview.*  
   https://learn.microsoft.com/en-us/ef/core  

6. ASP.NET Documentation. (2024). *ASP.NET Core Web API Overview.*  
   https://learn.microsoft.com/en-us/aspnet/core  

7. Serilog Documentation. (2024). *Logging and Monitoring in .NET Applications.*  
   https://serilog.net  

8. Blazor Documentation. (2024). *Building Interactive Web UIs with Blazor.*  
   https://learn.microsoft.com/en-us/aspnet/core/blazor  

9. ResearchGate. (2023). *Applications of Data Structures in Municipal Management Systems.*  
   https://www.researchgate.net  
