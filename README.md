# _Parks API_

#### By _**Matt Taylor**_


## Description

_An ASP.NET API that allows users to store information about US Parks, categorized by city and state._


## Setup/Installation Requirements

### 1.  Install .NET Core

#### on macOS:
* [Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer) to download a .NET Core SDK from Microsoft Corp.

#### on Windows:
* [Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer) to download the 64-bit .NET Core SDK from Microsoft Corp.

#### Install dotnet script
Enter the command ``dotnet tool install -g dotnet-script`` in Terminal (macOS) or PowerShell (Windows).

### 2. Clone this repository

Enter the following commands in Terminal (macOS) or PowerShell (Windows):
```sh
cd desktop
git clone https://github.com/mtaylorpdx/ParksApi.Solution
cd ParksApi.Solution
```
### 3. Install all necessary packages and make sure the project will build
In your terminal, type the following commands to make sure all necessary packages are included in the project and to launch in your browser:
```sh
cd ParksApi
dotnet restore
dotnet build
```

### 4. Update the database and tables
Enter the following to update your database and tables for the program:
```sh
dotnet ef database update
```

### 5. Launch the project in your browser
In your terminal, type:
```sh
dotnet watch run
```
Hold ```command``` while clicking the link in your local terminal to your local address, which should be:
```sh
http://127.0.0.1:5000
```

## Swagger

Type `localhost:5000` to utilize Swagger

## API Endpoints
_Once you have installed this program, you can use these endpoints on your local host in your browser._

Base URL: ```https://localhost:5000```

### Users

See all users and get user authentication.

#### HTTP Requests

### National Parks

Interact with the data for US National Parks.

#### HTTP Requests
```sh
GET /api/nationalparks
POST /api/nationalparksß
GET /api/nationalparks/{id}
PUT /api/nationalparks/{id}
DELETE /api/nationalparks/{id}
```
#### Path Parameters
| Parameter | Type | Default | Description |
| :---: | :---: | :---: | --- |
| nationalparkname | string | none | Returns matches by name.
| nationalparkcity | string | none | Returns all parks by specified city. |
| nationalparkstate | string | none | Returns all parks by specified state. |

#### Example Query
```sh
http://localhost:5000/api/nationalparks/?nationalparkname=yellowstone&state=wyoming
```

### State Parks

Interact with the data for US State Parks.

#### HTTP Requests
```sh
GET /api/stateparks
POST /api/stateparks
GET /api/stateparks/{id}
PUT /api/stateparks/{id}
DELETE /api/stateparks/{id}
```

#### Path Parameters
| Parameter | Type | Default | Description |
| :---: | :---: | :---: | --- |
| stateparkname | string | none | Returns matches by name. |
| stateparkcity | string | none | Returns all parks by specified city. |
| stateparkstate | string | none | Returns all parks by specified state. |

#### Example Query
```sh
http://localhost:5000/api/stateparks/?stateparkname=smith+rock
```


## Technologies Used
* _C#_
* _.NET Core 2.2_
* _ASP.NET Core MVC_
* _MySQL 2.2.0_
* _EF Core 2.2.0_
* _ASP.NET Core Identity_
* _Razor 2.2.0_
* _ASP.NET Core JSON Web Token Authentication & Authorization_
* _Swashbuckle 5.5.0_
* _[Postman](postman.com)_

## License

[MIT](https://choosealicense.com/licenses/mit/)

Copyright (c) 2020 **_Matt Taylor_**





How to test Token-Based Authentication & Authorization using Postman:
1. create POST request for localhost:5000/users/authenticate
2. input the following information into the Body:
{
    "username": "test",
    "password": "test"
}
3. hit "send" on POST request
4. verify that you receive a "200 ok" message
5. the API call should then return information about the user along with a "Token Key" - copy the token key
---
5. create GET request for localhost:5000/api/experiences
6. navigate to the "Authorization" tab in the dropdown menu for "type" and select "OAuth2.0"
7. navigate to the "Access Token" input box within the "Authorization" tab and insert the token key described in step 5
8. hit "send" on GET request
9. you should now have access to all endpoints that require authentication