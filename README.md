# 🚚 Shipment System API

A clean, scalable, and SOLID-based .NET Web API for managing asset shipment flows across locations.  
This project follows **Clean Architecture**, includes **Global Exception Handling**, and uses **Serilog** for production-ready logging.

---

## 📐 Architecture

This project is structured using **Clean Layered Architecture**:

ShipmentSystem.sln
│
├── ShipmentSystem.API → Controllers, Middleware, Startup
├── ShipmentSystem.Application → Business logic, DTOs, Interfaces
├── ShipmentSystem.Domain → Entities, ValueObjects, Enums
├── ShipmentSystem.Infrastructure → EF Core, Repositories, Data access

---

## ✨ Features

✅ Clean project structure using best practices  
✅ Serilog integration with file & console logging  
✅ Global exception handler middleware  
✅ Swagger UI enabled  
✅ Git + GitHub integrated  
✅ Ready to scale with EF Core, DTOs, and Domain-driven structure

---

## 📦 Technologies Used

| Stack           | Tech                                    |
| --------------- | --------------------------------------- |
| Backend         | ASP.NET Core Web API                    |
| Architecture    | Clean Architecture (DDD + SOLID)        |
| Logging         | Serilog                                 |
| Docs / Test     | Swagger (Swashbuckle)                   |
| DI              | Built-in Microsoft Dependency Injection |
| Version Control | Git & GitHub                            |

---

## 🧪 How to Run Locally

```bash
# Clone this repository
git clone https://github.com/rajpootmoney/Shipment-System-API.git

# Navigate to API folder
cd ShipmentSystem.API

# Run the app
dotnet run
```
