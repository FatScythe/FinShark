## Financial Shark

#### Web api built with ASP .NET8 Web Api, Users can create Stocks, get stock(s), delete stocks and update stocks, Users can also comment on stock and perform CRUD operations on their comment, Users can create personalized Portfolio for all their curated stocks.


### 📚 Getting Started

#### 🛠️ Installation
1. Clone the project or download zip file
2. Navigate to the project directory
   ```bash
   cd FinShark
   ```
3. Open the appsettings.json file, input your SQL connection string
   ```JSON
    "ConnectionStrings": {
    "DefaultConnection": "SQL Connection string"
   },
   ```
4. Delete Migrations folder, then open the terminal in the Finshark dir, to run database migration
   
   ``` bash
      dotnet ef migrations add init
   ```
5. After a sucessful migration, run
   ``` bash
      dotnet ef database update
   ```
6. Finally 
   ``` bash
      dotnet watch run 
   ```
   OR
   ``` bash
      dotnet run
   ```

### Authentication 
#### Authentication is JWT token is sent on registering/login, The JWT token can then be used to access protected resources on the server.
