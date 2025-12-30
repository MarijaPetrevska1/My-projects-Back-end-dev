# 🔐 SecurityLab

**SecurityLab** is a web application built with **ASP.NET Core** that demonstrates modern security practices, including **user authentication, two-factor authentication (2FA), and role-based authorization**.  
This project was developed as a personal learning and exercise project to explore and practice secure web application techniques. It is currently a work in progress and serves as a platform for testing and implementing new security concepts.  

Future improvements may include:  
1. More robust UI/UX with responsive design  
2. Advanced session and token management 
3. Integration with real email providers for OTP delivery  
4. Additional security enhancements and error handling  
5. Full unit and integration testing
---

## 🚀 Features

### User Authentication
- User registration with **username, email, and password**
- Secure **password hashing** 
- OTP generation for registration confirmation
- Two-factor authentication (2FA) during login

### Login System
- Validates user credentials
- Generates a temporary OTP for additional security
- Confirms login via OTP

### Role-Based Authorization
- Define and manage **roles** for access control
- Assign **temporary (just-in-time) access** to users
- Protect application resources based on user roles

### Security & Data Management
- Safe storage of user credentials
- OTP expiration for added security
- Session management and token-based authentication
- Least privilege principle applied for resource-specific roles

### Frontend
- HTML, CSS, and JavaScript forms for:
  - Registration
  - Login
  - OTP confirmation
- Interactive and simple user interface

---

## 🛠 Technologies Used

- **Backend:** ASP.NET Core, C#, Entity Framework Core, Dependency Injection
- **Frontend:** HTML, CSS, JavaScript (Fetch API)
- **Database:** SQL Server or InMemory database
- **Email (Optional):** MailKit for sending OTP emails

---

