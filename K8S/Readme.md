Install Docker 
Install Postman
Install latest .net core

create platform and command web api using dotnet new webapi -n {NameofTheApplication}
 dotnet new webapi -n CommandService   

Add packages using dotnet add package {packagename}
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Micosoft.EntityFrameworkCore.Design
dotnet add package Micosoft.EntityFrameworkCore
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package Grpc.AspNetCore

Add package into Platform service
dotnet add package Grpc.AspNetCore

Add Package into command service
dotnet add package Grpc.Tools
dotnet add package Grpc.Net.Client
dotnet add package Google.Protobuf



dotnet ef database update

docker ps 

dotnet --info

docker run -p 8081:80 pradeepdevananth/commandsservice

docker build -t pradeepdevananth/platformservice .   

docker push pradeepdevananth/platformservice    

docker build -t pradeepdevananth/commandsservice .

docker push pradeepdevananth/commandsservice      


 docker run -p 8081:80 pradeepdevananth/commandsservice

 
To restart deployment if not updated properly -
kubectl rollout restart deployment platforms-depl
kubectl rollout restart deployment commands-depl

to delete - kubectl delete deployment commands-depl

to delete all -  kubectl delete service --all    


use platforms-depl.yaml - for deployment for platforms application in kube.
use platforms-np-srv.yaml for create node port in kube.
use commands-depl.yaml for deployment for commands appliction in kube.
use ingress-srv for create ingress in kube. so that ingress will navigate request between microservice. its starting point for outside world.
use local-pvc to create storeage class in kube
use mssql-plat-depl.yaml to create SQL server instance in kube.



To install ingress-nginx
goto - https://kubernetes.github.io/ingress-nginx/deploy/#docker-desktop
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.1.0/deploy/static/provider/cloud/deploy.yaml



kubectl get namespaces
kubectl get pods --namespace=ingress-nginx
kubectl get services --namespace=ingress-nginx
kubectl get storageclass



To alway redirect to ingress ip and port we need to do like below.
open host file - c:\windows\system32\drivers\etc\hosts
add below line
127.0.0.1 acme.com


then use to initiates storage class -  local-pvc.yaml


After that to create secrets we need to do like this.
Kubectl create secret generic mssql --from-literal=SA_PASSWORD="pass55w0rd!"

Kube dashboard -
follow the create-user.yaml


Kube for mssql server launch 
Follow the mssql-plat-depl.yaml


Dotnet DB migration
dotnet ef migrations add initialmigration


Message Queue for Rabbit MQ using.
use rabbitmq-depl.yaml

Rabbit MQ type of exchange
- Direct exchange - Single Queue with Route Key
- FanOut exchange - Multi Queue without Route key
- Topic exchange - Multi Queue with Route Key
- Header exchange


add package for platform and command service - dotnet add package RabbitMQ.Client



gRPC
Google Remote Procedure Call
Uses HTTP/2 protocol to transport binary message (inc. TLS)
Focused on high performance
Relies on "Protocol Buffers" (aks Protobuf) to defined the contract between end points
Multi-language support (c# client can call a ruby service)
Frequently used as a method of service to service communication

gRPC only support TLS. so in cluster no need to use with security. we just using workaroud to over come and make gRPC support without using HTTPS. so add cluster ip 666 in both platform and command service to communicate each other.

Add package into Platform service
dotnet add package Grpc.AspNetCore

Add Package into command service
dotnet add package Grpc.Tools
dotnet add package Grpc.Net.Client
dotnet add package Google.Protobuf



Need to do analysis of 
- Introduction of HTTPS / TLS
- Revisit Event Processor / Eventing (Re Architect)
- More elaborate use-case
- service case
- 

-----------------------------------------------------------
-----------------------------------------------------------
-----------------------------------------------------------
-----------------------------------------------------------

History of watching.
-------------------
-------------------


12-Jan 2.0 pm - https://teams.microsoft.com/l/meetup-join/19%3ameeting_ZDQzZDMxMTYtYjk1My00MzE5LTg1YmMtNWQzMGU2MTAyYWE0%40thread.v2/0?context=%7b%22Tid%22%3a%2201b695ba-6326-4daf-a9fc-629432404139%22%2c%22Oid%22%3a%22cbd6563e-1c33-4b67-a1c1-141ef08afd29%22%7d

13 Jan 11 am - https://teams.microsoft.com/l/meetup-join/19%3ameeting_MDRkM2ZhYjMtZmVmYy00MzY5LWE0MzUtYTFiZDI5ZTkxMzZj%40thread.v2/0?context=%7b%22Tid%22%3a%2201b695ba-6326-4daf-a9fc-629432404139%22%2c%22Oid%22%3a%22cbd6563e-1c33-4b67-a1c1-141ef08afd29%22%7d

13 Jan 2.00 pm - https://teams.microsoft.com/l/meetup-join/19%3ameeting_ODI4NjBhN2QtZTk1YS00NjZlLWI1MzQtMWI3NmM3YjhmNGU2%40thread.v2/0?context=%7b%22Tid%22%3a%2201b695ba-6326-4daf-a9fc-629432404139%22%2c%22Oid%22%3a%22cbd6563e-1c33-4b67-a1c1-141ef08afd29%22%7d

5.14



Microservice - https://youtu.be/DgVjEo3OGBI?t=2020 - Jan 11 - 11.50 PM
https://youtu.be/DgVjEo3OGBI?t=4560 - 1.26
https://youtu.be/DgVjEo3OGBI?t=8181 - 2.16 - 3.03 AM 12 Jan 2022
https://youtu.be/DgVjEo3OGBI?t=9763 -2.42  4.03 AM 12 Jan 2022

12 Jan 3.41 on 6.56 PM
13 Jan 4.29 on 12.58 AM
API Gateway - 13 Jan 4.46 on 1.55 AM
https://youtu.be/DgVjEo3OGBI?t=18432 - need to start - Part 5 - 13 Jan - 5.07 on 2.46 AM 
- 5.30 
Kube ms sql server - 5.30 as on 15-Jan 2022 4.03 PM

Jan 17 02.33 AM - need to start solution architecture - 07.20.51 Video.

Jan 17 05.19 PM - need to start RabbitMQ subscriber in Command service - 08.25.11 Video.


Jan 20 02.08 PM - 9.23 Video.

Jan 20 02.43 PM - GRPC need to start 9.39 Video.

Jan 21 12:48 AM - Finished 11 Hours 05 Minutes Video.


-----------------------------------------------------------
-----------------------------------------------------------
-----------------------------------------------------------
-----------------------------------------------------------



.NET Microservices - Full Course
In this step-by-step tutorial I take you through an introduction on building microservices using .NET. As the name suggests we build everything completely from start to finish –with the full scope of the course outlined in the time-stamp section below. However, at a high-level we’ll cover:

• Building two .NET Microservices using the REST API pattern
• Working with dedicated persistence layers for both services
• Deploying our services to Kubernetes cluster
• Employing the API Gateway pattern to route to our services
• Building Synchronous messaging between services (HTTP & gRPC)
• Building Asynchronous messaging between services using an Event Bus (RabbitMQ)

To accompany this course I have provided free Kubernetes command and Architecture Cheat Sheet which is available for download when you subscribe to my blog at: https://dotnetplaybook.com/


📕 My Book: https://www.apress.com/gp/book/978148
... 
🤩 Patreon Site (Exclusive Member Benefits!): https://www.patreon.com/binarythistle
 
📕 Webhooks Course: https://dotnetplaybook.learnworlds.co...
 
🔗 GitHub Repo: https://github.com/binarythistle/S04E...

🔗 Containerizing a .NET App: https://docs.docker.com/samples/dotne...

🔗 Insomnia Download: https://insomnia.rest/download

🔗How to edit your hosts file: https://www.howtogeek.com/howto/27350...

🔗 Dependency Injection in .NET: https://docs.microsoft.com/en-us/aspn...



⏲️ Time Codes ⏲️

- 0:00 PART 1 - INTRODUCTION & Theory
- 2:39 Course Approach
- 6:11 Course Overview
- 11:31 Ingredients & Tooling
- 16:14 What are microservices?
- 33:40 Overview of our microservices
- 37:37 Solution Architecture
- 43:54 Application Architecture 

- 46:47 PART 2 - BUILDING THE FIRST SERVICE
- 47:33 Scaffolding the service
- 52:37 Data Layer - Model
- 57:35 Data Layer - DB Context
- 1:02:38 Data Layer - Repository
- 1:16:00 Data Layer - DB Preparation
- 1:27:31 Data Layer - Data Transfer Objects
- 1:41:19 Controller and Actions

2:16:21 PART 3 - DOCKER & KUBERNETES
- 2:16:21 Review of Docker
- 2:20:55 Containerizing the Platform Service
- 2:37:29 Pushing to Docker Hub
- 2:42:43 Introduction to Kubernetes
- 2:46:54 Kubernetes Architecture Overview
- 2:58:40 Deploy the Platform service

3:25:01 PART 4 - STARTING OUR 2ND SERVICE
- 3:25:01 Scaffolding the service
- 3:30:41 Add a Controller and Action
- 3:41:50 Overview of Synchronous and Asynchronous Messaging
- 3:55:21 Adding a HTTP Client
- 4:19:34 Deploying service to Kubernetes
- 4:44:55 Adding an API Gateway


5:07:12 PART 5 - STARTING WITH SQL SERVER
https://www.youtube.com/watch?v=DgVjEo3OGBI&t=18432s
- 5:07:12 Adding a Persistent Volume Claim
- 5:12:34 Adding a Kubernetes Secret
- 5:15:12 Deploying SQL Server to Kubernetes
- 5:30:31 Accessing SQL Server via Management Studio
- 5:33:06 Updating our Platform Service to use SQL Server

6:06:02 PART 6 - MULTI-RESOURCE API
- 6:06:02 End Point Review for Commands Service
- 6:09:31 Data Layer - Models
- 6:16:38 Data Layer - DB Context
- 6:21:37 Data Layer - Repository
- 6:34:53 Data Layer - Dtos
- 6:40:49 Data Layer - AutoMapper Profiles
- 6:45:26 Controller & Actions

7:20:49 PART 7 - MESSAGE BUS & RABBITMQ
- 7:20:49 Solution Architecture Overview
- 7:24:06 RabbitMQ Overview
- 7:28:55 Deploy RabbitMQ to Kubernetes

7:43:27 PART 8 - ASYNCHRONOUS MESSAGING
- 7:44:01 Add a Message Bus Publisher to Platform Service
- 8:18:07 Testing our Publisher
- 8:25:19 Command Service ground work
- 8:36:46 Event Processing
- 8:59:14 Adding an Event Listener
- 9:19:29 Testing Locally
- 9:26:28 Deploying to Kubernetes

9:39:12 PART 9 - GRPC
- 9:39:12 Overview of gRPC
- 9:44:06 Final Kubernetes networking configuration
- 9:54:32 Adding gRPC Package references
- 9:56:44 Working with Protocol Buffers
- 10:03:55 Adding a gRPC Server to Platforms Service
- 10:20:53 Adding a gRPC Client to Commands Service
- 10:39:41 Adding a Database prep class to Commands Service
- 10:48:05 Test Locally
- 10:51:01 Deploy to Kubernetes
- 10:58:43 Final thoughts & thanks
- 11:00:55 Supporter Credits