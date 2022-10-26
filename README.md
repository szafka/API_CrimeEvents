API CRIME-EVENTS
***
.NET Core Api with Docker
***
An application that supports accident reporting
----------------------------------------------------------------------------
How to start:
----------------------------------------------------------------------------
-> Open API_CrimeEvents.sln<br>
-> Open terminal<br>
-> Use command: docker-compose up --build<br>
***
(At this point, we create images of the application and create a database)<br>
***
To see LawEnforcement API endpoints, write in browser:<br>
-> http://localhost:8081/swagger/index.html<br>
To see CrimeEvent API endpoints, write in browser:<br>
-> http://localhost:8080/swagger/index.html<br>

----------------------------------------------------------------------------
Start without docker images:
----------------------------------------------------------------------------
-> Open API_CrimeEvents.sln<br>
-> Chose properties of solution<br>
-> Chose multiple startup projects with enable CrimeEvent and LawEnforcement<br>
-> Tap ok<br>
-> Start program in visual studio / visual studio code.<br>
(The application will automatically open two windows in the browser responsible for the controllers of each APIs)<br>
