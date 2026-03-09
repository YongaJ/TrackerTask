TrackerTask Solution Notes Overview

This project is a simple Task Tracker built with a .NET Web API backend and a small JavaScript frontend. The goal of the app is to allow users to create tasks, view them, edit them and also sort them. I understand the requirements were to use Vue/React/Angula for the website, but my skills on those technologies are very novice. And I didn't wanna shoot myself in the foot.
I rather decided to go with vanilla HTML and JS. Using bootstrap just for the touchups for UI. I tried to make the site as a signle page app ass possble. 

The backend is built using:

ASP.NET Core Web API

Entity Framework Core

InMemory database

Some seeded sample data

The frontend is just a lightweight JavaScript page that calls the API and displays the tasks.

Debugging Experience
Issue Encountered

While working on the backend tests, the first idea was to call the API directly using HttpClient with this endpoint:

https://localhost:7250/api/tasks

But the tests kept failing with this exception:

System.Net.Http.HttpRequestException
System.Net.Sockets.SocketException: No connection could be made because the target machine actively refused it.

Diagnosis

After looking into it, the problem turned out to be that the API server wasn’t running when the tests executed. Because of that, the test project tried to connect to the localhost endpoint but nothing was listening on that port.

This was confirmed by:

Looking at the exception stack trace

Trying the endpoint manually in the browser

Noticing that the tests only worked when the API project was already running.

So basically the tests depended on the API being started first, which isn’t ideal.

Resolution

To make the tests more reliable, they were changed to use the Entity Framework Core InMemory database directly.

Instead of calling the API through HTTP, the test creates the DatabaseContext, runs the seed logic and then checks that the tasks were inserted.

This approach has a few advantages:

Tests run faster

No dependency on the API server running

The test environment stays isolated and predictable

Backend Tests Implemented
Happy Path Test

SeedData_ShouldCreateTasks

Purpose:
To check that the database seed logic actually inserts the initial tasks.

What the test checks:

The seed method runs without errors

Tasks exist in the database afterwards

Validation / Error Test

Task_WithEmptyTitle_ShouldFailValidation

Purpose:
Make sure a task without a title is not considered valid.

What it verifies:

Required fields are enforced

Invalid task data should fail validation

Frontend Test

A small unit test was also added on the frontend side. This test checks some of the utility logic used before displaying tasks in the UI.

The idea here was mainly to make sure the frontend does not break if the API sends incomplete or slightly malformed data.

Conclusion

Overall this project shows:

Building a REST API using ASP.NET Core

Using EF Core for database operations

Connecting a simple JavaScript frontend to the API

Handling errors and debugging issues

Adding automated tests to make things more stable

The debugging process helped improve the tests quite a bit, since they no longer depend on the API server running seperately.
