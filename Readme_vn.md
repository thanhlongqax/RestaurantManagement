# Restaurant Management Microservices

## 📌 Giới thiệu
Hệ thống **Restaurant Management** được triển khai theo kiến trúc **microservices**, sử dụng **.NET 7**, **PostgreSQL**, và **Docker Compose** để dễ dàng triển khai và quản lý.

Mục đích của hệ thống
Hệ thống phục vụ quản lý hoạt động nội bộ của nhà hàng với các chức năng chính như:

Quản lý đơn hàng, bàn, thực đơn, và quy trình bếp.

Hỗ trợ đa dạng vai trò người dùng trong nhà hàng, gồm:

Quản lý: Giám sát toàn bộ hoạt động, quản lý nhân viên và báo cáo.

Nhân viên phục vụ: Ghi nhận và xử lý đơn hàng của khách tại bàn, hỗ trợ thanh toán.

Nhân viên bếp: Nhận và xử lý các đơn hàng từ nhân viên phục vụ để chuẩn bị món ăn.

## 🛠 Công nghệ sử dụng
- **.NET 7** (C#)
- **PostgreSQL 16**
- **Docker & Docker Compose**
- **Ocelot API Gateway**
- **Entity Framework Core**

## 🚀 Hướng dẫn cài đặt và chạy hệ thống

### **1️⃣ Cài đặt yêu cầu**
Trước khi chạy hệ thống, đảm bảo bạn đã cài đặt:
- **Docker** & **Docker Compose**
- **.NET SDK 7.0**

### Cổng mặc định : 5000
User-service : 5001
Table-service : 5002
Menu-Service : 5003
Kitchen-Service : 5004
Order-service : 5005
File-Service : 5006
### **2️⃣ Build các service**
Thực hiện từng bước để tránh lỗi:
```sh
docker-compose build fileservice
docker-compose build userservice
docker-compose build tableservice
docker-compose build menuservice
docker-compose build kitchenservice
docker-compose build orderservice
docker-compose build api-gateway
```

### **3️⃣ Khởi động cơ sở dữ liệu**
Chạy PostgreSQL cho từng service trước:
```sh

docker-compose up -d userservices
docker-compose up -d tableservices
docker-compose up -d menuservices
docker-compose up -d orderservices
docker-compose up -d kitchenservices
```
Chờ khoảng **10-20 giây** để database khởi động.

### **4️⃣ Khởi động từng service**
```sh
docker-compose up -d fileservice
docker-compose up -d userservice
docker-compose up -d tableservice
docker-compose up -d menuservice
docker-compose up -d kitchenservice
docker-compose up -d orderservice
```

### **5️⃣ Khởi động API Gateway**
```sh
docker-compose up -d api-gateway
```

### **6️⃣ Kiểm tra container đang chạy**
```sh
docker ps
```
Nếu có lỗi, xem log chi tiết bằng:
```sh
docker-compose logs userservice
docker-compose logs api-gateway
```

### **7️⃣ Dừng và xóa container (Nếu cần)**
Dừng toàn bộ container:
```sh
docker-compose down
```
Dừng và xóa luôn database volume (reset database):
```sh
docker-compose down -v
```

## 🌍 API Gateway
Sau khi khởi động, truy cập **API Gateway** tại:
```
http://localhost:5000
```

## 📌 Thông tin cổng của các service
| Service        | Cổng  |
|---------------|-------|
| API Gateway   | 5000  |
| User Service  | 5001  |
| Table Service | 5002  |
| Menu Service  | 5003  |
| Kitchen Service | 5004  |

## 👤 Tác Giả
**Thành Long**

📧 **Liên Hệ**: thanhlongndp@gmail.com

## 📜 Giấy Phép
Dự án được phát hành theo giấy phép **MIT**.

---
🚀 *Made with ❤️ by Long*

---
⚡ **Hệ thống đã sẵn sàng! Nếu gặp lỗi, vui lòng kiểm tra log hoặc liên hệ để hỗ trợ.** 🚀

