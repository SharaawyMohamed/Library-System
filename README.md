# Online Book Reader Project

## Overview

This project is a simple online book reader system implemented in C++. The system allows two types of users to interact with it: Admin and Customer. Below are the details of the functionalities and requirements.

## Functional Requirements

### User Roles

1. **Admin User:**
   - Can add books to the system.
   - Can add new admin users (Super Admin functionality).

2. **Customer User:**
   - Can read one book at a time.
   - Can have a history of their reading sessions.
   - Can add new books to their personal collection of books read.

### User Capabilities

#### Admin

- Login to the system.
- Add new books.
- Add new admin users (Super Admin capability).

```cpp
class Admin {
public:
    void login();
    void addBook(const Book& book);
    void addAdmin(const Admin& newAdmin); // Super Admin functionality
};
