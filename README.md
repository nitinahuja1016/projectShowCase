Product Organiser:
It contains spring boot based java project to organise your products.

The project is about how we can organize our products in a systematic manner for easy retrival.
Upscaling this project, it can be used by medical stores to find out where any particular medicine is kept or what all medicinies are kept in any particular shelf or drawer.

Added feature of this project is it can tell the expiry of the medicine or expiry of the warranty in other cases.

Technical details of the project:
1. A model class Product which is managed with ORM liabrary.
2. A controller class managed with Springframework which provides response with representational state of the object in json and is used for mapping methods (get, post) with specific URL.
3. A service class, again managed by springframework which takes care of all the work to be performed on the request.
4. An interface which manages the database connection with JPA repository and finally,
5. A springBootApplication class which conatins the main class from which the execution begins. Using springframework, it mangaes the creation and destruction of all the java objects.

Along with the above classes, it has resources which contains application properties which is reponsible for the little configuration that is required while using sprin boot application which contains URL to the database, user id and password to connect to the data base.

Finally it has pom.xml file which is used to manage the dependencies.
