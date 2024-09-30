# SQL Visual Compare User Guide

## Introduction

**SQL Visual Compare** is a tool designed to visually compare the structure and data of SQL databases. This can be especially useful when working with multiple versions of a database, comparing changes between environments (development, staging, production), or ensuring that database migrations have been successfully applied.

With SQL Visual Compare, you can:
- Compare database structures (tables, views, procedures, etc.)
- Compare data between tables in different databases
- Synchronize changes between databases
- Generate SQL scripts to apply changes from one database to another

This guide will walk you through how to use SQL Visual Compare for basic and advanced database comparison tasks.

---

## 1. Installing SQL Visual Compare

Before starting, you need to install SQL Visual Compare.

1. Visit the official website of SQL Visual Compare and download the installation package.
2. Run the installation package and follow the instructions to complete the installation.
3. Once installed, open SQL Visual Compare from your desktop or start menu.

---

## 2. Connecting to Databases

To begin comparing databases, you need to establish a connection to the databases you wish to compare.

### Step 1: Open the Connection Manager

- Open SQL Visual Compare and navigate to the **File** menu.
- Select **New Connection** to open the connection manager.

### Step 2: Enter Database Details

- For each database, enter the necessary connection information such as:
  - **Server Name**
  - **Authentication Method** (Windows Authentication or SQL Server Authentication)
  - **Database Name**
  - **Username/Password** (if required)
- Test the connection to ensure the details are correct.
- Once the connection is successful, click **Connect**.

### Step 3: Connecting to Multiple Databases

- Repeat the steps above to add connections for both databases you want to compare.
- Once both databases are connected, you can proceed with the comparison.

---

## 3. Comparing Database Structures

SQL Visual Compare allows you to compare the structure of tables, views, stored procedures, and other objects between two databases.

### Step 1: Start a Structure Comparison

- In the main window, click **Compare Database Structure**.
- Select the two databases you want to compare from the dropdown menus.

### Step 2: Select Objects to Compare

- SQL Visual Compare will display a list of database objects (tables, views, procedures, etc.).
- You can select which types of objects you want to include in the comparison (e.g., only tables or stored procedures).
- Click **Compare** to begin the structure comparison.

### Step 3: Review the Results

- SQL Visual Compare will show a side-by-side comparison of the objects in both databases.
- Differences between objects (e.g., missing columns, different data types) will be highlighted.
- You can drill down into specific objects to view detailed differences.

---

## 4. Comparing Database Data

You can also use SQL Visual Compare to compare the actual data stored in tables between two databases.

### Step 1: Start a Data Comparison

- From the main window, click **Compare Data**.
- Select the two databases you want to compare, and then select the tables to compare.

### Step 2: Choose Comparison Options

- SQL Visual Compare allows you to select comparison options such as:
  - **Columns to Compare**: Specify which columns to include in the comparison.
  - **Key Columns**: Specify which columns to use as the primary key for comparison.
  - **Comparison Method**: Choose whether to compare all rows or just differences.
  
- Once configured, click **Compare Data**.

### Step 3: Review Data Differences

- The results will show any differences in the data between the two tables.
- You can view added, deleted, or modified rows.
- SQL Visual Compare will also show the specific differences at the row and column level.

---

## 5. Synchronizing Databases

After comparing databases, you may want to synchronize the changes between them. SQL Visual Compare provides options to generate SQL scripts for synchronizing structures or data.

### Step 1: Synchronizing Database Structure

- Once the structure comparison is complete, you can choose to synchronize the two databases.
- Select the objects you want to synchronize and click **Generate Script**.
- SQL Visual Compare will generate a SQL script to apply the changes from one database to the other.
- Review the script and apply it to the target database if necessary.

### Step 2: Synchronizing Database Data

- After completing a data comparison, select the rows you want to synchronize between the databases.
- Click **Generate Data Sync Script** to create a SQL script that will update the target database with the data from the source database.
- Review the script and execute it in the target database to apply the data changes.

---

## 6. Exporting and Saving Comparisons

SQL Visual Compare allows you to save and export comparison results for future reference or for sharing with team members.

### Step 1: Save Comparison Results

- After completing a comparison (structure or data), you can save the results by clicking **Save Comparison**.
- Save the comparison file for later review or to rerun the comparison at a later date.

### Step 2: Export to Excel or HTML

- SQL Visual Compare provides options to export the comparison results to Excel or HTML formats.
- This is useful for sharing results with others or keeping a record of differences between databases over time.

---

## 7. Advanced Features

SQL Visual Compare also provides advanced features for more complex scenarios, such as:

- **Custom Comparison Rules**: Set custom comparison rules for specific database objects.
- **Scheduled Comparisons**: Automate regular comparisons between databases at scheduled intervals.
- **Integration with Source Control**: Track changes to your database schema over time by integrating SQL Visual Compare with your version control system.

---

## Conclusion

**SQL Visual Compare** is a powerful tool for comparing and synchronizing SQL databases, whether for development, testing, or production environments. With features for structure and data comparison, along with synchronization and export capabilities, SQL Visual Compare can help ensure consistency and reduce errors when working with multiple database instances.

Whether you are troubleshooting differences between environments or ensuring database migrations are applied correctly, SQL Visual Compare provides the tools you need for effective database comparison.
