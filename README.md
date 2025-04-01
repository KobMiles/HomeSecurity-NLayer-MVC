# Home Security Service

## 🛠️ Installation & Setup

## 1️⃣ Clone the repository
Clone the project to your local machine using Git:
```bash
git clone https://github.com/KobMiles/HomeSecurity-NLayer-MVC.git
cd HomeSecurity-NLayer-MVC
```


## 2️⃣ Set up the database

### ✅ Install SQL Server
Ensure that **SQL Server** is installed on your system. You can use **SQL Server Express** or **SQL Server LocalDB**.

You can download and install it from the official Microsoft documentation: 
**[Install LocalDB – Microsoft Docs](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)**  

### ✅ Configure the Database Connection String  
Your project requires a **connection string** to establish a connection with the database. You have two options for storing it:  
<details>
<summary><strong>1️⃣Using appsettings.json (for general use)  </strong></summary>

1. Open or create your **appsettings.json** file.
2. Under **ConnectionStrings**, add your connection string. For a local database in Visual Studio, you can use the example below:
   
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=HomeSecurityDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```

3. Ensure your project is set up to read **DefaultConnection** from this section (for instance, by referencing **Configuration.GetConnectionString("DefaultConnection")** in your code).

4. **Optional**: If you already have your own database, replace the above connection string with your own.
</details>

<details>
<summary><strong>2️⃣Using UserSecrets (recommended for security 🔐)</strong></summary>
 To protect connection strings and other credentials, store them in **UserSecrets** instead of appsettings.json. Here’s how:

### Option🅰️: Via Visual Studio GUI
1. Right-click WebApp project in **Solution Explorer** and select **Manage User Secrets**.
2. A **secrets.json** file will open. Add your connection string there:
   
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=HomeSecurityDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```

3. This file is kept out of source control automatically.

### Option🅱️: Via .NET CLI
1. Open a terminal in your project folder.
2. Initialize user secrets (if not done already):
   
   ```bash
   dotnet user-secrets init
   ```

3. Add your connection string using:
   
   ```bash
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=(localdb)\\MSSQLLocalDB;Database=HomeSecurityDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   ```

4. The **secrets.json** file is updated accordingly (but not committed to source control).
</details>

### ⚡ Important: Automatic Local Database Creation  
The provided connection strings are designed to **automatically create a local database** using **SQL Server LocalDB**. To use this feature, ensure that **LocalDB** is installed on your system. You can download and install it from the official Microsoft documentation:  

🔗 **[Install LocalDB – Microsoft Docs](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)**  

### 🛠️ Using a Custom Database Connection  
If you prefer to connect to an existing database instead of creating a local one, replace the default connection string with your own. Here’s an example of a **custom connection string**:  

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USER;Password=YOUR_PASSWORD;MultipleActiveResultSets=true"
  }
}
```

Replace **YOUR_SERVER**, **YOUR_DATABASE**, **YOUR_USER**, and **YOUR_PASSWORD** with your actual database credentials.  
By configuring your connection string correctly, you ensure seamless integration with your chosen SQL Server instance. 🚀


## 3️⃣ Apply database migrations

Run the following command to apply migrations and create the database schema:
```bash
dotnet ef database update --project HomeSecurity.DAL --startup-project HomeSecurity.WebApp
```

If migrations are missing, create one:
```bash
dotnet ef migrations add InitialCreate --project HomeSecurity.DAL --startup-project HomeSecurity.WebApp
dotnet ef database update --project HomeSecurity.DAL --startup-project HomeSecurity.WebApp
```


## 4️⃣ Run the application

Start the **ASP.NET Core MVC** application:
```bash
dotnet run --project HomeSecurity.WebApp
```

Alternatively, if using **Visual Studio**:
1. Open the **HomeSecurity-NLayer-MVC.sln** solution.
2. Set **HomeSecurity.WebApp** as the startup project.
3. Press **F5** to run in debug mode.

Once started, the app will be accessible at:
- **http://localhost:5145** (For HTTP)
- **https://localhost:7129** (For HTTPS)

# 🧩 Dependencies

This project uses the following dependencies:

| Package                          | Purpose |
|----------------------------------|---------|
| `Microsoft.EntityFrameworkCore`  | ORM for database interactions |
| `Microsoft.EntityFrameworkCore.SqlServer` | SQL Server provider for EF Core |
| `Microsoft.AspNetCore.Identity`  | Authentication & Identity management |
| `AutoMapper`                     | Object-to-object mapping |
| `FluentValidation`               | Model validation |

### ✅ Restore dependencies:
If any dependencies are missing, install them with:
```bash
dotnet restore
```
