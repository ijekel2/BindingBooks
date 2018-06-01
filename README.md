## BindingBooks Online Book "Store"
This repository contains a web application written in C# using ASP.NET MVC, which I based off of a tutorial by Brughen Patel on Udemy.com. Since I was developing in a Mac OS X environment, I chose to connect to a PostgreSQL database rather than use Microsoft SQL Server. The website supports basic CRUD operations on books and the ability to search books, which are displayed attractively as thumbnails on the "Browse" page. See below for screenshots of the website.

As it is now, the website does not support shopping carts for book purchase or rental. My next steps will be to add login functionality so that normal users can purchase and/or rent books and administrators can manage books. 

## Getting Started

### Prerequisites

You will need to install the following prerequisite software:
* [Mono](http://www.mono-project.com/download/stable/)
* [PostgreSQL](https://www.postgresql.org/download/)

### Creating Database and Database Owner

You will need to create a new database called "BindingBooksDB" and a new user "BindingBooksAdmin". Open a new command line window and launch the PostreSQL interactive terminal with this command:
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

Once mono is installed and your database is set up, download the BindingBooks repository .zip file. Unzip the file, and use the command line to navigate to the unzipped folder:
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
![alt text](https://github.com/ijekel2/BindingBooks/blob/master/BindingBooks/Content/Images/home-page.png "Home Page")
 
 ## BindingBooks Tour
### Browse Page with Search

This is the browse page with thumbnails that link to book details.
![alt text](https://github.com/ijekel2/BindingBooks/blob/master/BindingBooks/Content/Images/browse.png "Browse Page")

The search bar can be used to search books by title.
![alt text](https://github.com/ijekel2/BindingBooks/blob/master/BindingBooks/Content/Images/browse-search.png "Search on Browse Page")

The "Manage" dropdown menu navigates to manage pages for books, genres, and membership types.
![alt text](https://github.com/ijekel2/BindingBooks/blob/master/BindingBooks/Content/Images/dropdown-books.png "Manage Dropdown Menu")

From the manage books page, you can create, edit, delete, or view the details of a book.
![alt text](https://github.com/ijekel2/BindingBooks/blob/master/BindingBooks/Content/Images/manage-books.png "Manage Books Page")

### Create New Book

This is the page for creating a new book
![alt text](https://github.com/ijekel2/BindingBooks/blob/master/BindingBooks/Content/Images/create-book.png "Create New Book")

Here I create a new book and submit it.
![alt text](https://github.com/ijekel2/BindingBooks/blob/master/BindingBooks/Content/Images/submit-gatsby.png "Submit Newly Created Book")

Now that the book has been created, it appears on the browse page.
![alt text](https://github.com/ijekel2/BindingBooks/blob/master/BindingBooks/Content/Images/search-gatsby.png "New Book Now Appears on Browse Page")

### View Book Details 

This is the book details page.
![alt text](https://github.com/ijekel2/BindingBooks/blob/master/BindingBooks/Content/Images/details.png "Details Page")

### Edit Book
From the details page, we can choose to edit the book.
![alt text](https://github.com/ijekel2/BindingBooks/blob/master/BindingBooks/Content/Images/click-edit.png "Click Edit Button")

Here I update the availabity to "Out of Stock" and submit the change.
![alt text](https://github.com/ijekel2/BindingBooks/blob/master/BindingBooks/Content/Images/submit-edit.png "Edit Availability and Submit")

### Delete Book
We can see that the availability has been changed to "Out of Stock" on the Manage page. Now we can click the delete button to redirect to the delete page.
![alt text](https://github.com/ijekel2/BindingBooks/blob/master/BindingBooks/Content/Images/click-delete.png "Click Delete Button On Updated Book")

At the bottom of the delete page, we click the delete button to complete delete.
![alt text](https://github.com/ijekel2/BindingBooks/blob/master/BindingBooks/Content/Images/submit-delete.png "Click Delete Button")

Now that we have deleted the book, it no longer appears on the Manage Books page.
![alt text](https://github.com/ijekel2/BindingBooks/blob/master/BindingBooks/Content/Images/manage-books.png "Book Is Deleted")

## Acknowledgments
* Website based off Brughen Patel's Udemy.com tutorial. Code can be found on his [GitHub](https://github.com/bhrugen90/QuirkyBookRental) profile.






