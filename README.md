![titulo](/docs/titulo.JPG)

# NetCore3-MySQL

Connecting a .Net Core 3 web API with a remote MySQL server.

## Technologies

- [.Net Core 3](https://docs.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-core-3-0)
- [MySQL](https://www.mysql.com/)
- [MySQL Workbench](https://www.mysql.com/products/workbench/)
- [Dapper](https://dapper-tutorial.net/)

## Topics

- [MySQL](#mysql)
- [.Net Core 3](#net-core-3)

### MySQL

Let's create a remote MySQL database and manipulate it with MySQL Workbench.

First, access this website:

```bash
https://remotemysql.com/
```

Click on Login > Create Account:

![mysql01](/docs/mysql01.JPG)

You will receive an e-mail to confirm. Login in the website and create a database:

![mysql02](/docs/mysql02.JPG)

Your database is ready!

![mysql03](/docs/mysql03.JPG)

Now download the MySQL Workbench through this link:

```bash
https://dev.mysql.com/downloads/workbench/
```

After the installation process, open the program and click on "Manage Connections...":

![mysql04](/docs/mysql04.JPG)

Click on "New" and set the Hostname, Username, Password and Default Schema fields with the data from the remote database:

![mysql05](/docs/mysql05.JPG)

Test the connection:

![mysql06](/docs/mysql06.JPG)

Now, connect to the database:

![mysql07](/docs/mysql07.JPG)

![mysql08](/docs/mysql08.JPG)

![mysql09](/docs/mysql09.JPG)

We are ready to create our first table.  
Run the following script inside the "Query 1" tab:

```bash
CREATE TABLE user (
	id INT PRIMARY KEY AUTO_INCREMENT,
    name varchar(100)
);
```

Add some lines:

```bash
INSERT INTO user (name) VALUES ('Luciano');
INSERT INTO user (name) VALUES ('Sousa');
INSERT INTO user (name) VALUES ('Pereira');
```

The table structure will be visible:

![mysql10](/docs/mysql10.JPG)

### .Net Core 3

Download the [project sample](https://github.com/lucianopereira86/NetCore3-Swagger) from the [part 1](https://lucianopereira.netlify.com/posts/-net-core-web-api-part-1-swagger/).

Inside the _appsettings.json_, add a new object called _ConnectionStrings_ containing the MySQL connection string:

![netcore01](/docs/netcore01.JPG)

Create a folder named _Models_ in the root with two classes: _ConnectionStrings_ and _User_.

![netcore02](/docs/netcore02.JPG)

![netcore03](/docs/netcore03.JPG)

To be able to use the connection string anywhere in the code, it's necessary to create a singleton of its model inside the _Startup_ class.

![netcore04](/docs/netcore04.JPG)

Create another controller called _UserController_ with two methods: POST and GET.

![netcore05](/docs/netcore05.JPG)

Dapper is an ORM that allow an easy connection with any database. Install it through Nuget.

![netcore06](/docs/netcore06.JPG)

MySqlConnector is another package that you need to install.

![netcore07](/docs/netcore07.JPG)

Create a constructor inside the _UserController_ injecting the _ConnectionStrings_ singleton in a local variable.

![netcore08](/docs/netcore08.JPG)

Implement the Dapper inside the GET and POST methods:

![netcore09](/docs/netcore09.JPG)

![netcore10](/docs/netcore10.JPG)

Run the API and see the result in the URL:

```bash
http://localhost:53000/swagger/index.html
```

![netcore11](/docs/netcore11.JPG)

Test the GET method:

![netcore12](/docs/netcore12.JPG)

The result will be:

![netcore13](/docs/netcore13.JPG)

Test the POST method:

![netcore14](/docs/netcore14.JPG)

The result will be:

![netcore15](/docs/netcore15.JPG)

Run the GET method again and a new user will appear:

![netcore16](/docs/netcore16.JPG)
