# Online Book Store

This repository contains an **Online Book Store** developed using the **ASP.NET MVC framework**.

## Context

The **Online Book Store** aims to help beginners understand the fundamental concepts of the MVC architecture practically. It demonstrates the roles of the **Model**, **View**, and **Controller**—how the Controller interacts with the Model and provides the requested View.


## Table of Contents
- [Context](#context)
- [Overview](#overview)
- [Theory](#theory)
  - [Introduction to MVC](#introduction-to-mvc)
  - [Role of Each MVC Component](#role-of-each-mvc-component)
  - [Benefits of MVC](#benefits-of-mvc)
- [Practical](#practical)
  - [1. Controllers](#1-controllers)
  - [2. Models](#2-models)
  - [3. Views and HTML Helpers](#3-views-and-html-helpers)
  - [4. Data Annotations and Validation](#4-data-annotations-and-validation)
- [Application Demonstration](#application-demonstration)


## Overview

**Scenario:**  
You have been tasked with developing an online bookstore website using the **MVC (Model-View-Controller)** architecture. The website allows users to browse, search, and purchase books while ensuring proper data validation and user input handling.


## Theory

### Introduction to MVC

#### Concept and Advantages  
MVC (**Model-View-Controller**) is a software architectural pattern that separates an application into three main components:
- **Model:** Manages data and business logic.
- **View:** Handles the presentation layer.
- **Controller:** Acts as an intermediary between Model and View.

Advantages of MVC:
- **Separation of Concerns:** Improves code organization and maintainability.
- **Modularity and Reusability:** Promotes clean, reusable components.
- **Enhanced Testability:** Simplifies independent unit testing.
- **Improved Collaboration:** Enables parallel development by separating responsibilities.

### Role of Each MVC Component

- **Model:** Manages data, database interactions, validation, and business rules.
- **View:** Handles the user interface, rendering data for display, and capturing user input.
- **Controller:** Directs the application flow, processing user input, updating Models, and returning appropriate Views.

### Benefits of MVC

- **Separation of Concerns:** Clear division of responsibilities simplifies maintenance and debugging.
- **Code Reusability:** Modular components can be reused across applications.
- **Testability:** Independent testing ensures robust functionality.


## Practical

### 1. Controllers

- **BookController:** Manages actions like listing books, searching, and adding to the cart.  

**Examples:**  
- `Index` action method: Retrieves books and displays them in the view.  
  ![Index action method](assets/images/OBS2.png)  
- `Search` action method: Filters books based on title or author.  
  ![Search action method](assets/images/OBS3.png)  
- `AddToCart` action method: Adds selected books to the cart.  
  ![AddToCart action method](assets/images/OBS4.png)

### 2. Models

- **Book Model:** Represents book details with properties and data annotations for validation.  
  ![Book model](assets/images/OBS6.png)  
- **Cart Model:** Holds selected books and total price.  
  ![Cart model](assets/images/OBS7.png)

### 3. Views and HTML Helpers

- **Index.cshtml:** Displays available books in a table.  
  ![Index.cshtml](assets/images/OBS9.png)  
- **Search.cshtml:** Provides a search form for books.  
  ![Search.cshtml](assets/images/OBS10.png)  
- **Cart.cshtml:** Displays selected books and total price.  
  ![Cart.cshtml](assets/images/OBS11.png)  
- **HTML Helpers:** Used for generating form elements like text boxes and dropdowns.  
  ![HTML Helpers](assets/images/OBS12.png)

### 4. Data Annotations and Validation

- Apply data annotations to validate book details and user inputs.  
  ![Model validation](assets/images/OBS13.png)  
- Use server-side validation with `ModelState.IsValid`.  
  ![Server-side validation](assets/images/OBS14.png)


## Application Demonstration

1. **Home Page:**  
   ![Home Page](assets/images/OBS15.png)

2. **Add Books to Cart:**  
   ![Add Books](assets/images/OBS16.png)

3. **View Cart:**  
   ![View Cart](assets/images/OBS17.png)

4. **Remove Books from Cart:**  
   ![Remove Books](assets/images/OBS18.png)

5. **Search for Books:**  
   ![Search Books](assets/images/OBS19.png)

6. **Final Cart:**  
   ![Final Cart](assets/images/OBS20.png)

Users can also register and log in to manage sessions. Books added to the cart are saved per user session.