# Simple Product Management Documentation

## Getting Started
- Applications:
	- Visual Studio 2022
	- Visual Studio Code
-   Backend:
	-   Open Visual Studio and click "Open a project or solution", then open the `SimpleProductManagement` folder and click  `SimpleProductManagement.sln`.
    -   Open `Package Manager Console` with the default project set to `SimpleProductManagement`.
    -   Run `update-database` to apply database migrations.
    -   At the top of the Visual Studio window set the start-up item to `SimpleProductManagement` and run the backend API by clicking the green arrow next to it with `https`.
	-   The API endpoints can be found at [https://localhost:7083/swagger/index.html](https://localhost:7083/swagger/index.html) 
		- Here you can create a product via the HTTP Post endpoint
		- Here you can get all products via the HTTP get endpoint

-   Frontend:
    -   Open `SimpleProductManagement/SimpleProductManagement` in Visual Studio Code.
    -   Open terminal in visual studio code and run `npm i` to install dependencies.
    -   Run `npm run dev`
    -   Open [http://localhost:5173](http://localhost:5173) to see the front-end.

### API Documentation
After running the backend: 
-   Documentation about the API endpoints can be found at: [https://localhost:7083/swagger/index.html](https://localhost:7083/swagger/index.html)

### Possible Improvements

-   Look into Dockerization and add a docker container 