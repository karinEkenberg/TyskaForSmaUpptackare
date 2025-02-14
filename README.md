# TyskaForSmaUpptackare

TyskaForSmaUpptackare is a web application built with ASP.NET Core MVC that offers a flexible, hierarchical product management system. Originally designed with the idea of teaching language concepts through interactive “products” (such as houses, airplanes, etc.), the application allows an admin to create main products, subdivide them into parts (e.g., rooms or sections), and further define items (or even nested items) within each part.

---

## Features

- **Hierarchical Product Structure:**  
  - **Product:** The main entity (e.g., a house or airplane).
  - **ProductPart:** Represents a section or subdivision of the main product (e.g., a room or airplane cabin section).
  - **ProductItem:** The individual items or objects within a part, with support for nested (child) items.

- **Authentication & Authorization:**  
  - Integrated with ASP.NET Identity to handle user authentication.
  - Role-based access control for admin and standard users.

- **Admin Management:**  
  - Admin pages for managing products and content.
  - Scaffolding of Identity pages for custom styling and functionality.

- **Modern Web Technologies:**  
  - Utilizes ASP.NET Core MVC, Entity Framework Core, and SQL Server.
  - Supports Razor Pages for Identity UI if desired.

---

## Technologies Used

- **Backend:** ASP.NET Core MVC, Entity Framework Core, ASP.NET Identity  
- **Database:** SQL Server  
- **Frontend:** Razor Views (with optional Razor Pages for Identity)  
- **Tools:** dotnet-aspnet-codegenerator for scaffolding, Git for version control

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express)
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/karinEkenberg/TyskaForSmaUpptackare.git
   cd TyskaForSmaUpptackare
   ```

2. **Restore NuGet packages:**
   ```bash
   dotnet restore
   ```

3. **Configure the connection string:**  
   In the *appsettings.json* file, set your SQL Server connection string for `"DefaultConnection"`.

4. **Apply the database migrations:**
   ```bash
   dotnet ef database update
   ```

5. **Build and run the project:**
   ```bash
   dotnet build
   dotnet run
   ```
   The application should now be running on `https://localhost:5001` (or the URL specified in your launch settings).

---

## Usage

- **Admin Interface:**  
  Log in using the admin credentials (set up during initial seeding or via the registration process). Once logged in, you can manage products, product parts, and product items through the admin panels.

- **Product Hierarchy:**  
  The main product can have multiple parts, and each part can contain several items. Items can also be nested to represent more complex structures (e.g., a drawer containing clothing).

---

## License

This project is licensed under the [MIT License](LICENSE).

---

## Acknowledgments

- Thanks to the ASP.NET Core team for their excellent documentation and support.
- Inspired by modern educational tools and flexible web architectures.
