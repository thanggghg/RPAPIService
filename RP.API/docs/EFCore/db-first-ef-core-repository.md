# Database First with Entity Framework Core and Repository Pattern

## Introduction

**Database First** approach in **Entity Framework Core** allows you to generate entity classes and a DbContext based on an existing database schema. This is particularly useful when you are working with legacy databases or databases managed outside your application.

This guide will cover how to:

1. Scaffold the entity and DbContext classes from an existing database.
2. Update entities when the database schema changes.
3. Implement the **Repository Pattern** to interact with your data.

---

## 1. Installing Entity Framework Core

Before you start, ensure you have installed **Entity Framework Core** in your project.

### Step 1: Install EF Core Packages

In the **.NET CLI**, run the following commands to install the necessary EF Core packages:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
