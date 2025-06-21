# 🛍️ E-Shop Microservices System

A modular, scalable e-commerce web application built using ASP.NET Core with microservices architecture, containerization, and clean architecture principles.

---

## 🚀 Features

- 🛒 Product Catalog (Catalog.API)
- 🧺 Shopping Basket (Basket.API)
- 📦 Order Management (Ordering.API)
- 💰 gRPC-based Discount Service (Discount.gRPC)
- 🌍 YARP API Gateway for routing
- 🌐 Razor Pages frontend (Shopping.Web)
- 📊 Distributed caching via Redis
- 📬 Inter-service messaging via RabbitMQ
- 🐳 Docker Compose for containerized orchestration
- ✅ Health checks and service readiness
- ☁️ Ready for deployment
- 
---

🛠️ Technologies Used

ASP.NET Core Web API & Razor Pages – Modern backend and frontend framework

gRPC – High-performance inter-service communication

Redis – In-memory data store for basket caching

RabbitMQ – Message broker for decoupled communication (used in ordering, events)

PostgreSQL – Relational database for catalog and discount services

SQL Server – Alternative data storage for some modules (e.g., ordering or identity)

MongoDB + EF Core – Used for document-style storage with familiar ORM

YARP API Gateway – Reverse proxy to manage and route requests across services

Refit – Type-safe HTTP client for service-to-service calls in Razor frontend

MediatR – Implements the CQRS pattern for clean separation of commands/queries

Swagger – Auto-generated API documentation for each microservice

Docker & Docker Compose – Containerized development and deployment environment

---

## 🗂️ Microservices Overview

| Microservice | Description |
|--------------|-------------|
| `Catalog.API` | Manages product information |
| `Basket.API` | Manages shopping carts |
| `Ordering.API` | Handles order placement and history |
| `Discount.gRPC` | Provides discount values |
| `YARP Gateway` | Routes API traffic |
| `Shopping.Web` | Razor Pages frontend |

---
🏗 Architecture Overview
This solution follows Clean Architecture and separates concerns by layer:

WebApps/Shopping.Web: Razor Pages frontend

Services:

Catalog.API: Product management (MongoDB)

Basket.API: Shopping cart (Redis)

Ordering.API: Checkout system

Discount.Grpc: Discount calculation (gRPC)

Shared Kernel: Shared contracts and DTOs

Each service is containerized and communicates over REST/gRPC.
## 📦 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/)
- [Docker](https://www.docker.com/)
