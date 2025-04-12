
# Tyska För Små Upptäckare 🇩🇪✨  
**An interactive learning platform for children to explore German grammar through play.**

**TyskaFörSmåUpptäckare** is a responsive web application built with ASP.NET Core MVC that teaches German to children in a fun and structured way. 
The site combines audio, images, and interactive UI elements, where users can explore themed environments (like a house) and learn through clicking and listening. 
It supports user authentication, paid content via Stripe, and admin-level content management.

---
## 🎥 Demo Video

Watch the demo video here:  
👉 [Watch on YouTube](https://youtu.be/NOC9z29z6b0)

Or click the image below to play:

[![Watch the demo](https://img.youtube.com/vi/NOC9z29z6b0/hqdefault.jpg)](https://youtu.be/NOC9z29z6b0)


## 🖼️ Screenshots
### Free content (tablet view)

![tfsudjur](https://github.com/user-attachments/assets/a5d386d7-c469-45c9-b48f-832321601e56)

### Paid content (tablet view)

![tfsuflyg](https://github.com/user-attachments/assets/aa9f7739-123d-4070-a490-5dc04d056b1c)

### Inside the house (mobile view)

![tfsumobil](https://github.com/user-attachments/assets/1ac6d74c-edb7-4f0d-889c-c1ac693eab91)

### Inside the living room (mobile view)

![tfsuvrum](https://github.com/user-attachments/assets/f7e77570-947b-492c-b871-f3b620559895)


## 🚀 Features

### 🏗️ Hierarchical Product Structure
- **Product** – Main item (e.g., a house or an airplane).
- **ProductPart** – Subsections (e.g., rooms).
- **ProductItem** – Clickable elements in each part (e.g., toys, objects).
- Supports multiple nested levels – items can contain other items.

### 🧠 Interactive & Kid-Friendly UX
- Click or press `Enter`/`Space` to trigger audio playback.
- Large buttons, clear calls-to-action, intuitive layout for children.
- Built-in keyboard navigation following [DIGG accessibility guidelines](https://www.digg.se/webbriktlinjer/alla-webbriktlinjer/all-funktionalitet-ska-kunna-anvandas-med-tangentbord).

### 👥 Authentication & Roles
- Built with ASP.NET Identity.
- Role-based access: **Administrators** and **Customers**.
- Restricted views and features for different user types.

### 🛍️ Shopping Cart & Stripe Integration
- Add products to a cart and pay via **Stripe Checkout**.
- Orders are saved and associated with the logged-in user.
- Paid content is unlocked after a successful purchase.
- Cart persists between sessions and logins.

### 🛠️ Admin Tools (CRUD)
- Full content management system for admins:
  - Add/edit/delete products, parts, and items.
  - Upload `.webp`, `.png`, `.mp3` files through the UI.
  - Role-based view filtering with `[Authorize]`.
- Modal confirmation for destructive actions.
- Proper model binding with `[BindNever]` and optional fields to avoid validation issues.

### 💌 Contact Form with Resend
- Fully validated contact form for user questions.
- Integrated with [Resend](https://resend.com/) using their official .NET SDK.
- Domain verified for secure email delivery.

  **Contact form features:**
  - Client-side + server-side validation
  - Success message on submission
  - Sends emails via Resend API

### 📥 Seeded Sample Content
- Includes a German **alphabet**, **animals**, and **numbers** (1–1000)
- Comes with corresponding audio and image files for each item
- Audio playback implemented with JavaScript

---

## 🧰 Tech Stack

- **Backend**: ASP.NET Core MVC (.NET 8), Entity Framework Core, ASP.NET Identity  
- **Frontend**: Razor Views, JavaScript, Bootstrap 5  
- **Database**: SQL Server  
- **Payment**: Stripe Checkout  
- **Email**: Resend API  
- **Version Control**: Git, GitHub  
- **Design**: Figma, Draw.io (ER diagrams & DB structure)

---

## 🧪 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Express
- [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- [Stripe](https://stripe.com) test account

### Installation

1. **Clone the repo:**
   ```bash
   git clone https://github.com/karinEkenberg/TyskaForSmaUpptackare.git
   cd TyskaForSmaUpptackare
   ```

2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

3. **Add appsettings.json:**  
   Create a file named `appsettings.json` and configure:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "your-connection-string"
     },
     "StripeSettings": {
       "PublishableKey": "your-stripe-publishable-key",
       "SecretKey": "your-stripe-secret-key"
     },
     "Resend": {
       "ApiKey": "your-resend-api-key"
     }
   }
   ```

4. **Apply database migrations:**
   ```bash
   dotnet ef database update
   ```

5. **Run the application:**
   ```bash
   dotnet run
   ```
   The site should be available at `https://localhost:7083`.

---

## 🔐 Admin Access

To access the admin dashboard:

- Register a user on the site.
- Manually update the role to `Administrators` in the database.

Admins can:
- Manage products, parts, and items.
- Upload image/audio files.
- View customer orders and purchase history.
- Manage paid/unlocked content.

---

## 🧒 Product Exploration

- **Free content** is accessible without login.
- **Paid content** is restricted until purchase.
- After purchasing, users can:
  - Enter themed “houses” or environments.
  - Click images or use the keyboard to trigger audio.

---

## 💳 Stripe Testing

Use test cards from [Stripe’s documentation](https://stripe.com/docs/testing).  
Example card: `4242 4242 4242 4242` with any future date and valid CVC.

---

## 🧩 Accessibility & Responsiveness

- Fully responsive: Mobile, Tablet, Desktop
- Keyboard-navigable (including interactive grid & arrows)
- Uses `aria-labels`, alt text, and clear focus styles
- Designed to be distraction-free and suitable for younger children

---

## 📊 Known Limitations / To-Do

- Purchase history does not fully display in the admin panel due to Identity-related DBContext conflicts.
- Admin UI for selecting/uploading files could be improved with dropdowns or previews.
- Current illustrations are temporary (some stock, some personal).
- Future versions may include:
  - Drag-and-drop builder for interactive rooms
  - Voice recognition for pronunciation training
  - Deployment to a live environment

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---

## 🙏 Acknowledgments

- Created by **Karin Ekenberg** as a final thesis project in full-stack web development.
- Inspired by playful learning methods and inclusive design for kids.
- Special thanks to the .NET, Bootstrap, Resend, and Stripe communities.


