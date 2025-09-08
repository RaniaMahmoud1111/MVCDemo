
 Company Site (Learning Project)

This is a simple **Company Management web application** built with **ASP.NET Core MVC**.  
It is designed as a **learning project** to explore technologies and architectural patterns like Repository, Service Layer, Unit of Work, and Dependency Injection.

---

## 🏢 What the App Includes

- **Employee Module** – Add, update, search, soft delete employees  
- **Department Module** – Manage company departments  
- **Security Module** – Authentication and role-based authorization using ASP.NET Identity  

---

## ✨ Features

- ✅ **Soft Delete** – data is not permanently removed, just hidden  
- ✅ **Search & Filter** – search employees and departments  
- ✅ **Authentication & Authorization**  
  - Reset Password via Email or SMS using [Twilio](https://www.twilio.com/)  
  - External Login with **Google OAuth2**  
  - Role-based authorization (e.g., Admin, User)  
- ✅ **File Management**  
  - Upload images and PDFs  
  - Preview and download attachments  

---

## 🏗 Architecture

The project follows a **3-layer architecture**:

- **Presentation Layer** → Controllers, Views, UI logic  
- **Business Logic Layer (BLL)** → Services, validation, business rules  
- **Data Access Layer (DAL)** → Repositories, EF Core data operations  

> Technologies like **Dependency Injection** are used internally to keep the app clean, decoupled, and easy to maintain.

---

## 🛠 Technologies Used

- ASP.NET Core MVC  
- Entity Framework Core (EFC)  
- SQL Server  
- LINQ  
- AutoMapper (with some manual mapping)  
- Twilio API (SMS/Email OTP)  
- Google OAuth2 (External Login)  

---

## 📸 Screenshots

### Sign up & Login Page and Extrnal login by google

![sign up](https://github.com/user-attachments/assets/002d4460-8c89-4f6c-be35-31d23d09f233)

![login](https://github.com/user-attachments/assets/22ef7422-1ee9-4363-9109-d0addf5b8655)
![login with google](https://github.com/user-attachments/assets/1f3bc912-e0a8-4f34-a786-d0375b3af536)
### Reset Pass by SMS(Twilio)
![foget](https://github.com/user-attachments/assets/f2722da1-e0c2-44d2-b97f-cfddc24da013)

![photo_2025-09-08_17-41-07](https://github.com/user-attachments/assets/27a64679-e1bf-4d51-8b98-cfed27db4866)

### Reset Pass by email 

![forget pass](https://github.com/user-attachments/assets/96639b86-70a1-4d54-81f6-8bd2d5bb24a7)

![reset by email](https://github.com/user-attachments/assets/a0a3d115-e1d1-4c48-be39-ef6507a25c2e)
![email](https://github.com/user-attachments/assets/991970cc-6f96-43c2-88c9-22f55f8a4080)

![email2](https://github.com/user-attachments/assets/d4c39a5c-b2b7-435c-8308-6eaefd4cb405)

### after Link of reset send we Enter New Pass

![new pass](https://github.com/user-attachments/assets/b8b77698-a8ac-4544-9b3c-ea9505bac040)



### Employee Module with Crud Operation and Soft Delete and attaching service(images , docs, pdfs) also include search module and also search by ajax call

![IndexEMp](https://github.com/user-attachments/assets/98cee843-9ffe-4a23-a9a5-8e42c4d7f3c4)

![details](https://github.com/user-attachments/assets/d5ead1fa-c1cd-4bf2-bed5-5b7d2a99ec2d)

![attach](https://github.com/user-attachments/assets/31ed9a83-1274-4efa-a1b7-c089007fff66)

![edit](https://github.com/user-attachments/assets/1cf4a9e5-ba0c-4565-99d3-129aac5725f6)

![ajax call](https://github.com/user-attachments/assets/d2058ddb-c440-4504-a91b-b7378d808c01)


### Department Module  with Crud Operation and Soft Delete

![deptIndex](https://github.com/user-attachments/assets/f12c71d8-2910-4c71-b423-9fcaab827d6d)

![del](https://github.com/user-attachments/assets/eb7725db-7230-4087-9e88-b519c561fa1b)


