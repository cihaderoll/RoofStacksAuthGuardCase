# **RoofStacks Auth-Guard Case**

## **Table Of Contents**
* [Summary](#Summary)
* [Technologies Used](#technologies-used)
* [How Authorization Flow Works](#how-authorization-flow-works)
* [Prerequisites](#Prerequisites)
* [Installation](#Installation)
* [Getting Access Token](#getting-access-token)
* [Consuming API](#consuming-api)

## **Summary**
The project is built on the .NET 8 architecture and consists of an authorization server that complies with OAuth/OpenID standards, as well as a Web API that performs CRUD operations on the employee list.

## **Technologies Used**
* .NET 8
* Microsoft IdentityServer
* EF Core
* PostgreSQL
* FluentValidation
* ESK(Elastic-Serilog-Kibana)
* JWT
* xUnit
* Moq

## **How Authorization Flow Works**

![image](https://github.com/user-attachments/assets/8b08ceeb-01a2-4c9a-b62a-b0aef4ca6d29)

1. The client application (in our scenario, Postman) sends a request to the **`https://localhost:7126/oauth/token`** endpoint with the necessary credential information.
2. **`After the Auth0 Authorization Server`** validates the credentials, it returns a response containing the accessToken to the client application.
3. Then, the client application sends a request to the **`EmployeeAPI`** with the access token received from the authentication server.
4. After the **`EmployeeAPI`** validates the token, it returns the appropriate response.



## **Prerequisites**
* .NET 8 SDK
* PostgreSQL ([How to install](https://www.dbvis.com/thetable/how-to-set-up-postgres-using-docker/))
* Elastic and Kibana ([How to install](https://karthiksdevopsengineer.medium.com/setting-up-elasticsearch-and-kibana-single-node-cluster-with-docker-d785f591a760))

## **Installation**
To install Auth-Guard, follow these steps:

1. Clone the repository: **`git clone https://github.com/cihaderoll/RoofStacksAuthGuardCase.git`**
2. Verify the configurations within the application (such as server ports) and check the configurations of the servers you have set up.
3. Run command **`update-database -context appdbcontext`**
4. If everything is set up correctly, you can run the AuthGuard and EmployeeService projects simultaneously.
5. You should be able to see the Swagger interface in both applications.

## Getting Access Token
To execute the endpoints in the EmployeeService application, you need an AccessToken obtained from the AuthGuard application. To get this, you should make a request to the following endpoint.

**`https://localhost:7126/oauth/token`**

If the request is successful, you should receive a response similar to the following:

```
{
    "accessToken": "eyJhbGciOiJSUzI1NiIsImtpZ...-_xWQWpNroDAobRW_pxE_N8Xw__hgOgcnHKgFEt35n_-YH4nMgCg",
    "expiresIn": 3600,
    "tokenType": "Bearer",
    "scope": "employees"
}
```
Since the authorization process is handled through Credential Flow, there is no need to provide any information when making the request.
Within the application configuration files, the client's credential information is included. The EmployeeService application is registered with the same credential information in the AuthGuard application. If you wish to change these credentials:

* Go to **`appsettings.Development.json`** file on EmployeeService
* Find **`Authorization`** config and change it the way you want
* Then go to **`Configuration.cs`** class under **`Common`** folder on AuthGuard
* Find the client with the clientId of **`EmployeeAPI`** and apply the changes you made to the EmployeeService application here as well.
* Save and run both applications again.

## Consuming API

To consume the EmployeeService endpoints, you need the access_token mentioned above. After obtaining the access_token, you must include this token in the Authorization header of all subsequent requests.
Below is an example of how to include the relevant token in the header of a request sent via curl:

```
curl --location 'https://localhost:7126/api/v1/employee' \
--header 'Authorization: Bearer eyJhbGc...'
```

After doing this, you can successfully make requests to the endpoints within the EmployeeService application. Below are the endpoints available for requests within the application:

```
GET https://localhost:7126/api/v1/employee
GET https://localhost:7126/api/v1/employee/{id}
POST https://localhost:7126/api/v1/employee
PUT https://localhost:7126/api/v1/employee
DELETE https://localhost:7126/api/v1/employee
```


