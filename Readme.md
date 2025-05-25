# Restaurant Management Microservices
📌 *[Xem bản tiếng Việt](Readme_vn.md)*
## 📌 Introduction

The **Restaurant Management** system is implemented using a **microservices architecture**, leveraging **.NET 7**, **PostgreSQL**, and **Docker Compose** to enable easy deployment and management.

### Purpose of the system

This system is designed to manage the internal operations of a restaurant with key features including:

* Managing orders, tables, menus, and kitchen workflows.
* Supporting multiple user roles within the restaurant, including:

  * **Manager**: Oversees overall operations, manages staff, and views reports.
  * **Waiter/Staff**: Takes and processes customer orders at tables and handles payments.
  * **Kitchen Staff**: Receives orders from waiters and prepares the food.

---

## 🛠 Technologies Used

* **.NET 7** (C#)
* **PostgreSQL 16**
* **Docker & Docker Compose**
* **Ocelot API Gateway**
* **Entity Framework Core**

---

## 🚀 Setup and Run Instructions

### **1️⃣ Prerequisites**

Before running the system, make sure you have installed:

* **Docker** & **Docker Compose**
* **.NET SDK 7.0**

### Default ports:

* API Gateway: 5000
* User Service: 5001
* Table Service: 5002
* Menu Service: 5003
* Kitchen Service: 5004
* Order Service: 5005
* File Service: 5006

---

### **2️⃣ Build the services**

Run each command one by one to avoid errors:

```sh
docker-compose build fileservice
docker-compose build userservice
docker-compose build tableservice
docker-compose build menuservice
docker-compose build kitchenservice
docker-compose build orderservice
docker-compose build api-gateway
```

---

### **3️⃣ Start the databases**

Start PostgreSQL containers for each service first:

```sh
docker-compose up -d userservices
docker-compose up -d tableservices
docker-compose up -d menuservices
docker-compose up -d orderservices
docker-compose up -d kitchenservices
```

Wait around **10-20 seconds** for the databases to fully start.

---

### **4️⃣ Start the services**

```sh
docker-compose up -d fileservice
docker-compose up -d userservice
docker-compose up -d tableservice
docker-compose up -d menuservice
docker-compose up -d kitchenservice
docker-compose up -d orderservice
```

---

### **5️⃣ Start the API Gateway**

```sh
docker-compose up -d api-gateway
```

---

### **6️⃣ Check running containers**

```sh
docker ps
```

If any issues occur, check logs for details:

```sh
docker-compose logs userservice
docker-compose logs api-gateway
```

---

### **7️⃣ Stop and remove containers (if needed)**

To stop all containers:

```sh
docker-compose down
```

To stop containers and remove database volumes (reset data):

```sh
docker-compose down -v
```

---

## 🌍 API Gateway Access

Once the system is up, access the API Gateway at:

```
http://localhost:5000
```

## 📌 Service Port Information

| Service         | Port |
| --------------- | ---- |
| API Gateway     | 5000 |
| User Service    | 5001 |
| Table Service   | 5002 |
| Menu Service    | 5003 |
| Kitchen Service | 5004 |


## 👤 Author  
**Thanh Long**  

📧 **Contact**: thanhlongndp@gmail.com  

## 📜 License  
This project is released under the **MIT License**.  

---  

🚀 *Made with ❤️ by Long*  

Let me know if you need any modifications! 🚀
---

⚡ **The system is ready! If you encounter any issues, please check the logs or contact support.** 🚀

---


