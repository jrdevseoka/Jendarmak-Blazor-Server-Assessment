# Jendarmak-Blazor-Server-Assessment

## Project Overview

The goal of this project is to create an assembly line process management application that allows users to manage operations and the devices that are assigned to them. The application should be designed to handle only 4 types of devices.

## Key Features

The application should include the following features:

A listing of operations with an option to remove an operation.
A modal form to add a new operation to the list of operations.
A modal form to add a new device to an operation.
A pleasant user interface.
Razor components.

## Project Setup

### 1. Clone the Repository

Clone the project repository from the version control system (Git). Use the following command in your terminal or Git Bash:

```bash
git clone https://github.com/jrdevseoka/Jendarmak-Blazor-Server-Assessment.git
```

### 2. Navigate to the Project Folder

In the terminal, navigate to the Assembly.Site directory

```bash
cd Assembly.Site
```

### 3. Restore Dependencies

Run the following command to restore dependencies:

```bash
dotnet restore
```

### 4. Tailwind CSS Integration

In the terminal, navigate to the wwwroot directory within the Assembly.Site folder and run:

```bash
npm install tailwindcss
```

### 5. Build Tailwind CSS

Run the script using

```bash
npm run build:css
```

### 6. Run the Application

```bash
dotnet run
```
