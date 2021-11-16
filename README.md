# VehicleCRUD

## Information
Applications is created with three classes Vehicle, VehicleType and VehicleMake (which stands for which brand of vehicle). 
Application is using Entity Framework and migrations, the repository pattern and unitOfWork to make the data persisent and to allow for CRUD operations to be demonstated.

## How-to:
- Download or clone the repository.
- A ```localDb``` must be installed.
- Migration for creating our database, ```initialDb```, is already in the DataLayer, therefore to create the database you need to set DataLayer as startup project and the default project in Package Manager Console (PMC) to DataLayer. Then you write and run the code ```Update-Database``` in PMC.
- Now change the startup project to PresentationLayer.
- You can now run the program!

## Screenshots
![image](https://user-images.githubusercontent.com/71070272/142032747-a70ae130-a267-426a-8b9a-67f45e6d43cf.png)
