# AcmeCorpApi

Create an API in .NET Core that allows you to manage customers, their contact info, 
and their orders for Acme Corp.

•	Authentication/Authorization - API Key
•	Unit tests
•	Integration tests
•	Demonstrates use of SOLID and DDD principles
•	Docker-compose-up should start the API, perform any DB migrations (if 
•	needed), spawn dependent resources, etc.
•	Check in code to personal GH repo and reply with the link.
•	IaC to deploy to AWS is a bonus. 

1. Application configured in http://localhost:5183
2. Once run the application, from Postman request  http://localhost:5183/api/token to get Bearer token
3. Use the Bearer token request to get Customer (CRUD) api calls. Here is sample Json to create Customer
4. 
  {
        "id": 1,
        "name": "Joseph",
        "address": "Hyderabad",
        "emailId": "ioseph@test.com"
    }
 
 5. Use SQLite to store data from API's. Note: No master data scrips to create data at SQLite
 
