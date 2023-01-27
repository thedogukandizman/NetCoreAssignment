The project is written by .netcore and there are 6 layers included.

There are 2 basic entities inheriting from BaseEntity.  BaseEntity (Id,CratedDate,UpdatedDate)
Each entity has its own repository. These repositories inherits from the generic repository.
Different requests for each entity other than the generic repository are written in the entity's repo.

EFCore is used as ORM.Migration is done with Codefit approach.
There is no parameter for auto Migration when the application starts running. Manuel migration is required.

Added "WhereIf" Iqueryable extension that can be used in the repository.

Status Type Enum has been added for the Todo entity to be cast to the Status property.

Each entity has its own service. The services are called in the API layer.
Mw development has been made for Exception Handling.
FOR IOC ServiceRegistration.cs is written. Repository,Service, Mapping and Jwt and dBContext are removed.
Mapping operations are provided with AutoMapper.


AllowAnonymous and Authorize attributes have been created for Authorize.
Middleware and utils are written for jwt.

Requests come through Dto and continue by mapping the related objects with AutoMapper.

User:

Signup:
When you make a request by entering email and password, a user record is created and a success response is returned.
For password encription and verifying BCrypt is used.

Signin:
When a registered user enters email and password, if the operation is successful, email and token are returned as a response.
Added authorize for Swagger. Tokens can be entered for testing.

chnagePassword:
If the user is not logged in tokens, he will get an "unauthorized" error. If there is a token entry, it can change the password with email, oldPassword and newPassword.

Todo:

All Todo requests must be authenticate to the user system. Otherwise, it will get an "unathorized" error.
The user who is authenticated to the system can perform all requests.

todo (Get):
Filtering can be done for status. You can request the whole list regardless of status or by filtering it by status.
It asks for UserId information. The id of the authenticated user could be set directly from the HttpContext Items.

todo (Post):
The new Name and Status fields are mandatory. Description is an optional field.

todo (put)
It is possible to make changes in Name, Status and Description fields.

todo (delete)
The relevant Todo record is deleted.

Layers are Domain, Domain.Shared, Data Access, Service, Service.Contracts and presentation ( api ) layers.

Domain:
It contains Entities and Repository interfaces.

Domain.Shared:
Used for Utils used within the application.(For Ex; Type) There is no requirement to be in every utils domain shared layer.

DataAccess:
Contains Database Context operations.
It includes migrations.
Repository contains concrete classes.

Service.Contracts:
It includes DTOs and Service interfaces.

Service:
It includes Authorization, AutoMapper, Exception Settings,Error Handling, Registration (DI).
It contains concrete classes of services.

Api:
Http requests management layer.