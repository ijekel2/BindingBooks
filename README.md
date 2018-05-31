## BindingBooks Online Book "Store"
This repository contains a web application written in C# using ASP.NET MVC, which I based off of a tutorial by Brughen Patel on Udemy.com. Since I was developing in a Mac OS X environment, I chose to connect to a PostgreSQL database rather than use Microsoft SQL Server. The website supports basic CRUD operations on books and the ability to search books, which are displayed attractively as thumbnails on the "Browse" page. See below for screenshots of the website.

As it is now, the website does not support shopping carts for book purchase or rental. My next steps will be to add login functionality so that normal users can purchase and/or rent books and administrators can manage books. 

## Getting Started

### Prerequisites

You will need to install the following prerequisite software:
* [Mono](http://www.mono-project.com/download/stable/)
* [PostgreSQL](https://www.postgresql.org/download/)

### Creating Database and Database Owner

You will need to create a new database called "BindingBooksDB" and an a new user "BindingBooksAdmin". Open a new command line window and launch the PostreSQL interactive terminal with this command:
```
psql postgres
```
Once you are in the psql terminal, you can add the database and its owner with the following commands:
```
CREATE DATABASE BindingBooksDB;
CREATE USER BindingBooksAdmin IDENTIFIED BY ENCRYPTED PASSWORD 'password';
ALTER DATABASE BindingBooksDB OWNER TO BindingBooksAdmin;
```

Use the command `\q` to quit the psql terminal. Now your database should be configured according to the specifications in the project's Web.config file.

### Downloading BindingBooks

Once mono is installed and your database is set up, download the BindingBooks repository .zip file. Unzip the file, and use the command line to navigate to the unzipped folder using 
```
cd <pathToFolder>/BindingBooks-master/
```
Use the `ls` command (`dir` on Windows) to ensure that you are in the folder containing the `BindingBooks.sln` file. 

### Building BindingBooks

Once you are in the directory with the `BindingBooks.sln` file, you can build the project using Mono's `csc` command.

```
csc BindingBooks.sln
```
If the `csc` command doesn't work, try using the `msbuild` command.

```
msbuild BindingBooks.sln
```
### Deploying BindingBooks

Once your have successfully built the project, navigate the the project root directory, `BindingBooks`, which is in the same folder as `BindingBooks.sln`:
```
cd BindingBooks
```

Once in the project root directory, you can launch the project using the xsp4 command from Mono.
```
xsp4 --port=8000
```
Now open your browser and visit [localhost:8000](localhost:8000). Now you should see the BindingBooks homepage.

### BindingBooks Home Page
![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/home-page.png "Home Page")


## BindingBooks Tour
### Browse Page with Search
![alt text](https://github.com/ijekel2/BindingBooks/BindingBooks/Content/Images/browse.png "Browse Page")

![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/browse-search.png "Search on Browse Page")

![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/dropdown-books.png "Manage Dropdown Menu")

![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/manage-books.png "Manage Books Page")

### Create New Book
![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/create-book.png "Create New Book")

![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/submit-gatsby.png "Submit Newly Created Book")

![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/create-book.png "Create New Book")

![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/create-book.png "New Book Now Appears on Browse Page")

### View Book Details 
![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/click-details.png "Click Details Button From Manage Books")

![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/details.png "Details Page")

### Edit Book
![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/click-edit.png "Click Edit Button")

![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/edit-book.png "Edit Book Page")

![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/submit-edit.png "Edit Availability and Submit")

### Delete Book
![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/click-delete.png "Click Delete Button On Updated Book")

![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/delete-book.png "Delete Book Page")

![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/submit-delete.png "Click Delete Button")

![alt text](https://github.com/ijekel2/BindingBooks/tree/master/BindingBooks/Content/Images/manage-books.png "Book Is Deleted")
 
## Acknowledgments
* Website based off Brughen Patel's Udemy.com tutorial. Code can be found on his [GitHub](https://github.com/bhrugen90/QuirkyBookRental).






