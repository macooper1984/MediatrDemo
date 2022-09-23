# Mediatr Demo

### FAQ
#### What is this solution
This solution was written to demonstrate Mediatr as a way of implementing CQS in C# .Net

#### What is CQS
Command Query Separation (CQS) is a software design pattern which acknowledges that reading data and modifying data are inherently different actions and as such should be handled differently.

In this example, I use Mediatr, a .Net library downloaded through the Nuget package manager to implement CQS within a .Net solution and show some potential options around how Pipelines can be used to enhance your solution.

#### What is Mediatr?
Github: [Mediatr](https://github.com/jbogard/MediatR)

Taken from [Codemaze](https://code-maze.com/cqrs-mediatr-in-aspnet-core/):

> You can think of MediatR as an “in-process” Mediator implementation, that helps us build CQRS systems. All communication between the user interface and the data store happens via MediatR.

> The term “in process” is an important limitation here. Since it’s a .NET library that manages interactions within classes on the same process, it’s not an appropriate library to use if we wanted to separate the commands and queries across two systems. In those circumstances, a better approach would be to a message broker such as Kafka or Azure Service Bus.`

#### Why do we need Mediatr when we're allready using Masstransit?
A few people have asked why we need Mediatr when we’re already using MassTransit. The answer is that Mediatr handles messages "in process", unlike AMPQ, them messages never leave the bounds of the service.



•	Application to demonstrate CQRS implementation using Mediatr
•	A few disclaimers:
o	Not claiming this is the only way to implement CQRS or that it’s perfect
	Code written in my own time 
	(Mostly less than 3 hours). 
	Learning as I go
o	Initially based on Clean Architecture. But taken a few liberties to save time
o	Dodgy classes – Name is pretty honest, just don’t look under the hood.
o	This is just a proof of concept
	A lot showing what I can achieve, done for the fun of it.
	Some aspects are quite advanced. Do not try this at home.
o	These are things I’ve taken from my time at Sage where architects did a lot of these things for us.

•	Data structure (Postman)
•	API (Swagger)
•	Adding Mediator to the solution
•	Command – Create Order
•	Queries – Get Order
•	Reusable blocks – Create Flight Booking
•	Pipelines
o	Transaction
	Rollback
	Atomic actions (Event publishing)
•	Consumer
•	Unit testing
