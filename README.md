Reservation system is a project to manage hotel bookings.
It uses JDBC to connect to its data in a postgres database. It is capable of performing all the CRUD operations on DB through its service class.

The project contains following 3 classes:

1. Main:           Containing the main method, execution begins from here. User selects the operation to be performed in this console based application.
   
2. DbConnection:   Connection to DB using JDBC is establised through this database class which returns the connection object.

3. Serive class:   Class responsible for perfoming the actions as requested in the main class.

Upscaling this project, ORM can be used where a relation for table and for guest is managed separately and an additional relation store all the old bookings for record keeping. It will also ensure normalization of the database.
