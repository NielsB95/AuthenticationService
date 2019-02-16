# Authentication service [![CircleCI](https://circleci.com/gh/NielsB95/AuthenticationService.svg?style=svg)](https://circleci.com/gh/NielsB95/AuthenticationService)

This repository contains an authentication service which can be used in a microservice environment. It consists of two complementary applications that together form the authentication service. The first, and most important, service, is the backend wherein the actual authentication and authorization is handled. The second service is a frontend with which accounts, roles and permissions can be managed. Furthermore, this frontend shows some statistics in a dashboard.

In the image below, a composition of microservices shows how this authentication service can be used. In this example, the authentication service is hooked up with the API Gateway. The API Gateway distributes the incomming requests to the right services, however, for some requests the sender needs to authenticated and authorized. The API Gateway can quickly communicate with the authentication service if this requests can proceed or if a 401 Unauthorized should be returned.

Backend
------------
The ASP.NET Core backend of this authentication service is the place where the actual authentication and authorization happens. This backend exposes an API-endpoint where a request can be send to. This endpoint (`/Authenticate`) expects the user to send a username and password along with it. When the username and password match with what we expect it to be, a [JSON Web Token (JWT)](https://jwt.io/) is returned, along with information of the authenticated user. 

Frontend
------------
The frontend of this authentication service provides the administartors of an application with the tools to manage their users. Users, roles and permissions can be created, altered and be revoked. Besides providing the tools to manage the users, this applications also provides usefull insights. The dashboard shows among others, the total number of accounts and the number of succesfull authentications on a daily basis.

Example usage
------------
![Authentication service](https://drive.google.com/uc?export=view&id=1Cr9uoS7glH_Zll-iH7NjO6lgzRxnOU1a)

Code analysis
-------------
[![](https://codescene.io/projects/4174/status.svg) Get more details at **codescene.io**.](https://codescene.io/projects/4174/jobs/latest-successful/results)
