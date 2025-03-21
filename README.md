# Tyska För Små Upptackare

**TyskaForSmaUpptackare** is a responsive web application built with ASP.NET Core MVC that teaches German grammar to children in an engaging and interactive way. 
The site uses a hierarchical product model, with images and audio that users can explore — and it supports payments via Stripe for premium content.

---

## Features

 **Hierarchical Product Structure:**  
  - **Product:** The main entity (e.g., a house, airplane, etc.).
  - **ProductPart:** Subdivisions of a product (e.g., rooms, airplane sections).
  - **ProductItem:** Interactive items within parts (e.g., objects in a room).  
    Items can include audio and images.

- **Interactivity:**  
  - Click or press keyboard keys (Enter/Space) to play audio.
  - Sound-based interaction with visuals, optimized for kids.
  - Keyboard-accessible and responsive on mobile, tablet, and desktop.

- **Authentication & Authorization:**  
  - Built-in ASP.NET Identity for user accounts.
  - Role-based access (Admin, Customer).

- **Admin Interface:**  
  - Create/edit/delete products, parts, and items.
  - Upload `.webp`, `.png`, and `.mp3` files through the UI.
  - View customer orders via admin panel.

- **Shopping Cart & Stripe Integration:**  
  - Add products to cart and pay using Stripe Checkout.
  - Orders saved after payment, with unlockable access to purchased products.
 
- **Contact Form & Email Delivery:**
The project includes a contact form on the homepage where users can submit questions or messages.
The form is fully validated, accessible, and integrates with Resend to securely send emails.
Features:

  - Client-side and server-side validation for name, email, and message
  - Success message displayed upon submission
  - Emails are sent using Resend's official .NET SDK
  - Domain is fully verified with Resend for reliable delivery

- **Seed Data on First Launch:**  
  Includes the German alphabet, animals, and numbers with corresponding audio files.

---

## Technologies Used

- **Backend:** ASP.NET Core MVC, Entity Framework Core, ASP.NET Identity  
- **Database:** SQL Server  
- **Frontend:** Razor Views + JavaScript  
- **Payment:** Stripe Checkout API  
- **Other Tools:** dotnet-aspnet-codegenerator, Git, Bootstrap

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Server Express
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- A Stripe account (test keys are enough for development)

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/karinEkenberg/TyskaForSmaUpptackare.git
   cd TyskaForSmaUpptackare
   ```

2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

3. **Configure your database connection:**  
   Add `appsettings.json` to your project, set the connection string under `"DefaultConnection"`.

4. **Add Stripe keys:**  
   Also in `appsettings.json`, under `StripeSettings`:
   ```json
   "StripeSettings": {
     "PublishableKey": "your-publishable-key",
     "SecretKey": "your-secret-key"
   }
   ```

5. **Apply database migrations:**
   ```bash
   dotnet ef database update
   ```

6. **Run the project:**
   ```bash
   dotnet run
   ```
   The site should launch at `https://localhost:5001`.



## Usage

### Admin Access

To access the admin pages:

- Register a user account via the site.
- Manually update the user's role in the database to `"Administrators"`.

Admins can:
- Create/edit/delete products
- Upload images and audio
- View customer orders

### Product Exploration

- Free products are available without login.
- Paid products are locked until purchased.
- After purchase, users can:
  - Explore rooms and interactive items.
  - Click images or press keys to hear German words.

### Stripe Testing

Use [Stripe test cards](https://stripe.com/docs/testing) when checking out.  
Example test card: `4242 4242 4242 4242` with any future date and CVC.

---

## Test Content (Seeded)

- **Alphabet:** Letters A–Z (including Ä, Ö, Ü, ß) with audio
- **Animals:** Images and audio for animals like Affe, Bär, Chamäleon...
- **Numbers:** 1–1000, grouped in ones, tens, and hundreds, with audio

You can find images in `/wwwroot/img` and audio files in `/wwwroot/audio`.

---

## Accessibility & Responsiveness

- Keyboard navigable (Enter/Space to trigger sound)
- Mobile-first design with Bootstrap
- Alt-text and `aria-label` attributes for accessibility

---

## License

This project is licensed under the [MIT License].

---

## Acknowledgments

- Built by Karin Ekenberg as part of a UX/design-focused final project.
- Inspired by educational tools that combine interaction with structured content.
- Thanks to the ASP.NET Core and Stripe communities for excellent documentation.

