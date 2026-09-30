### N-Tier API

- Tier means layer, and n means numbres. An N-Tier API splits the work into different layers that each do one job and only talk to the later next to them.

Controller (Presentation) -> Services (Business) -> Repository(Data Access) -> Database

## Controller

- Speaks HTTP, Takes the request, asks the service, picks the status code

## Services

- Holds the rules AKA our business Logic

## Repository

- Stores and Fetches Data: get, add, update, delete (The only class that uses AppDbContext)


### DTO Data Transfer Objects

* Data * This holds the fields, No methods, No rules, AND NO DATABASE

* Transfer * It has one Job to Carry Data across our API,

* Object * This is a plain C# class, just like anyother