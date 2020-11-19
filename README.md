Installation Process is below
=
It's basically a reservation base system implemented with the basic and the advanced Authentication and Authorization system using Identity.
This application is created targeting mainly 3 types of users: 
  i)    admin
  ii)   manager
  iii)  Passenger

![Screenshot_1](https://user-images.githubusercontent.com/73245269/99473121-2514d700-2974-11eb-8bae-073ce8cd9fa6.jpg)


Installation Process 
====================
i) 	  First, Delete 'Migrations' and 'IdentityMigrations' folders.
ii) 	Second, In the web.config file change the server name of the ConnectionStrings
iii) 	Third, run Migrations command using the follwing steps:


-------------------------------1st Step---------------------------------------------

enable-migrations -ContextTypeName ReservationProjectMvc.Models.ContextCS -MigrationsDirectory Migrations

add-migration -Configuration ReservationProjectMvc.Migrations.Configuration init

update-database -Configuration ReservationProjectMvc.Migrations.Configuration


-------------------------------2nd Step---------------------------------------------

enable-migrations -ContextTypeName ReservationProjectMvc.Identity.ApplicationDbContext -MigrationsDirectory IdentityMigrations

add-migration -Configuration ReservationProjectMvc.IdentityMigrations.Configuration Idenityinit

update-database -Configuration ReservationProjectMvc.IdentityMigrations.Configuration


Yeah! Now, Please run the project, login as admin, insert data and test the behavior:-)
=======================================================================================

	Already Authenticated User:
	--------------------------
	--------------------------
	=> username:	admin
	=> password:	admin123
	
	=> username:	manager
	=> password:	manager123

	=> any new registered user will be authorized by "Passenger" role
