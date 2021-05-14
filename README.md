# Personal Budget Project

This is my program developed for the application at the LMU - MMT Program 2021. This program is a WebApp that runs on [Blazor Webassambly](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor), a client-side C# frameworked developed by Microsoft.

[![Product Name Screen Shot][product-screenshot]](https://mmt.lennardgreve.de)

## Features

The Personal Budget Project is a web-based program that can run on any operating system. In addition to that, the project follows the mobile-first concept and is not only responsive but also a progressive web app. 
That means, that you can install the web app on your device (Smartphone, PC, TV, etc.) and also access it offline.

### Dashboard
* Current budget display
* Expense / Income overview
* Quick add for new transactions
* Table of last 10 transactions

### Transaction list
* Budget Performance Graph
* Expense / Income Graph
* Detailed Table of all transactions 
  - keyword and date range filter
  - CRUD operations

### Settings
* Export Data as .json
* Import Data as .json

## Usage

In order to see the program in action, you can either start a local instance on your machine from the .zip file or simply open [https://mmt.lennardgreve.de](https://mmt.lennardgreve.de).

### local instance

1. extract _PersonalBudgetCompiled.zip_ 
2. run a local webserver of your choice and open `wwwroot/index.html`

### inspeckt code

1. make sure to have the .Net 5 SDK installed `cmd: dotnet --info`
2.  extract _PersonalBudgetSource.zip_ and open `PersonalBudget.sln` with VisualStudio 2019 / Rider


## License
[MIT](https://choosealicense.com/licenses/mit/)


<!-- MARKDOWN LINKS & IMAGES -->
[product-screenshot]: https://mmt.lennardgreve.de/assets/AppOverview.png