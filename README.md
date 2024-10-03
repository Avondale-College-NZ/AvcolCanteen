# Avondale College School Canteen
This project is a school canteen website. This is a full-stack project with front and back-end functionality. This project uses ASP.NET CORE MVC and an SQL database to store user information. 

# How to setup:
1.	To use this project first clone the repository into visual studio.
2.	After cloning is complete, open the NuGet package manager console and issue an update-database command. This will create the database and necessary tables and fields.
3.	Then run these commands in the package manager console with your own fields: 
- dotnet user-secrets init
- dotnet user-secrets set "AdminUser:FirstName" "admin"
- dotnet user-secrets set "AdminUser:LastName" "admin"
- dotnet user-secrets set "AdminUser:Email" "admin@admin.com"
- dotnet user-secrets set "AdminUser:Password" "_password-for-admin-account_"
- dotnet user-secrets set "SendGridSettings:FromEmail" "_your-email@example.com_"
- dotnet user-secrets set "SendGridSettings:EmailName" "_YourName_"
- dotnet user-secrets set "SendGridSettings:ApiKey" "_your-sendgrid-api-key_"
4.	After the commands have been successfully completed, run the SQL script named Master Insert Statement. This will insert some dummy data in the project for it to be functional.
5.	After everything is complete press the green play button in Visual Studio to start the website.

# How to use:

### Admin
To use this website you can login with the admin account (the credentials are set using the user-secrets) and then that will allow you to modify the data. When logged in as the admin the user will be able to edit the data using the links in the homepage dropdown.
These links are NOT available to anyone who doesn't have the admin acccount.

### Customer
The customer can view the products on the website but to place an order must register themselves. After registering and verifying their email they will be able to place orders.
The customer cannot view any of the views that allow for data manipulation.
