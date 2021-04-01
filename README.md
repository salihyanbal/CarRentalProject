<h1 align="center">Car Rental System - Backend</h1> 
<p align="center">
  <img src="https://github.com/salihyanbal/CarRentalProject/blob/master/GitHub/images-for-read-me/white-logo-on-black-background.png" width="600" alt="main">
</p>

# Table of Contents

- <a href="#introduction">** Introduction **</a>
- <a href="#setup">** Setup **</a>
- <a href="#technologies">** Technologies **</a>
- <a href="#techniques">** Techniques **</a>
- <a href="#databasetables">** Database Tables **</a>
- <a href="#dynamicfilter">** Dynamic Filter and How to Create **</a>
- <a href="#fluentvalidation">** FluentValidation and Usage **</a>
- <a href="#aspects">** Aspects and Usages **</a>
- <a href="#nugetpackages">** Nuget Packages and Their Versions **</a>

<div id="introduction">
# Introduction

I have been developed this project to improve myself, learn design patterns and other technologies. If you need detailed information do not hesitate to contact me.
</div>

<div id="setup">
# Setup
  
After downloading the files and opening the solution u need to do the required and optional configurations.

- Required
1. Creating sql tables (You can get sql query from: [.sql](https://github.com/salihyanbal/CarRentalProject/blob/master/carrental.sql))
2. Configure connection string from: DataAccess > Concrete > Ef > [CarRentalContext.cs](https://github.com/salihyanbal/CarRentalProject/blob/master/DataAccess/Concrete/Ef/CarRentalContext.cs) (default configuration for Mssql) 
- Replace the server name with yours.
- Optional
3. Authorization token configurations are held in WebApi > [appsettings.json](https://github.com/salihyanbal/CarRentalProject/blob/master/WebAPI/appsettings.json) > TokenOptions. 
	- You can change token options as you wish.
4. Start the project
</div>

<div id="technologies">
# Technologies Used

* .NET
* ASP.NET for Restful api
* EntityFramework Core
* Autofac
* FluentValidation
* MsSql
* [Angular for Frontend](https://github.com/salihyanbal/car-rental-ng)
</div>

<div id="techniques">
# Techniques

* Layered Architecture Design Pattern
* AOP
* JWT
* Autofac dependency resolver
* IOC
</div>

<div id="databasetables">
# Databas Tables

[DatabaseTables](https://github.com/salihyanbal/CarRentalProject/blob/master/GitHub/images-for-read-me/sqltables.png)
</div>

<div id="dynamicfilter">
  
# Dynamic Filter and How to Create

I created a dynamic filter because of the need for creating queries for multiple filtering and controlling the filtered fields from one place.
If you want to add a filter for your entity, you can follow the steps below.

1. Create FilterDto, implement the interface of IFilterDto, and add properties that will be used for filtering the entity. ([Example FilterDto](https://github.com/salihyanbal/CarRentalProject/blob/master/Entities/DTOs/CarDetailFilterDto.cs))

[FilterDto](https://github.com/salihyanbal/CarRentalProject/blob/master/GitHub/filter-dto.jpg)

2. Create a method in the related DAL and implement the Filter structure. ([Example usage of Filter Expression in the EfCarDal](https://github.com/salihyanbal/CarRentalProject/blob/master/DataAccess/Concrete/Ef/EfCarDal.cs))

[FilterDal](https://github.com/salihyanbal/CarRentalProject/blob/master/GitHub/dal-for-filter.jpg)

Filter Attributes Usage

1. If you need to filter with the same property with multiple values, you should create the property as a List.
2. To fetch the data that has the same value as the filter property you should place [EqualFilter("propertyName)"] attribute.
3. To fetch the data that has bigger values than the filter property you should use [MinFilter("propertyName")] attribute.
4. To fetch the data that has smaller values than the filter property you should use [MaxFilter("propertyName")] attribute.

You can create custom FilterDto's and filtering methods for other entities by following the same steps.


</div>

<div id="fluentvalidation">
# FluentValidation and Usage

If you want to check content of entity when add, update etc. operations you can create validation for related entity.

[Fluent Validation](https://github.com/salihyanbal/CarRentalProject/blob/master/GitHub/fluent-validation.jpg)


</div>

<div id="aspects">
# Aspects and Usages
  
## ValidationAspect

Aspect for [FluentValidation](#fluentvalidation)

You need to add [ValidationAspect(typeof(validationType))] on top of the related method.

[ValidationAspect](https://github.com/salihyanbal/CarRentalProject/blob/master/GitHub/validation-aspect.jpg)

## CacheAspect

If you want to add the returned data to the cache, you need to add  [CacheAspect] on top of the related method, by default it adds the data to the cache for 60 minutes. 
If you want to change the duration you just modify it as [CacheAspect(20)]. It will cache the returned data for 20 minutes.

[CacheAspect](https://github.com/salihyanbal/CarRentalProject/blob/master/GitHub/cache-aspect.jpg)

## CacheRemoveAspect

We need to clean cache when add, update, delete or any manipulative operations triggered because the data is changed. For that purpose, you can use the cache remove aspect by adding [CacheRemoveAspect("Servicename.Get")] on top of the related method. The name of the service, which is the interface of the related manager, must be given.

[CacheRemoveAspect](https://github.com/salihyanbal/CarRentalProject/blob/master/cache-remove-aspect.jpg)

## PerformanceAspect

If the processing time of the method is longer than expected this aspect writes it to debug screen.
I added this aspect to all methods. You can check it from: Core > Utilites > Interceptors > AspectInterceptorSelector.cs. By default, I gave 60 seconds for the performance control.

[PerformanceAspectAll](https://github.com/salihyanbal/CarRentalProject/blob/master/performance-aspect-all.jpg)
[PerformanceAspectMethod](https://github.com/salihyanbal/CarRentalProject/blob/master/performance-aspect-method.jpg)

## SecuredOperationAspect

You can secure the usages of operations by adding [SecuredOperation("role1,role2")] on top of the related method.You should spare the roles just with a comma.

[SecuredOperationAspect](https://github.com/salihyanbal/CarRentalProject/blob/master/secured-operation-aspect.jpg)

## TransactionAsepct

If an operation handles more than one transaction and other transactions need to withdrawal when one transaction failed, you can add [TransactionScopeAspect] on top of the related operation.

[TransactionScopeAspect](https://github.com/salihyanbal/CarRentalProject/blob/master/transaction-scope-aspect.jpg)
</div>

<div id="nugetpackages">

# Nuget Packages and Their Versions

* Autofac - Version = v6.1.0
* Autofac.Extensions.DependencyInjection - Version = v7.1.0
* Autofac.Extras.DynamicProxy - Version = v6.0.0
* FluentValidation - Version = v9.5.1
* Microsoft.AspNetCore.Authentication.JwtBearer - Version = v3.1.12
* Microsoft.AspNetCore.Http - Version = v2.2.2
* Microsoft.AspNetCore.Http.Abstractions - Version = v2.2.0
* Microsoft.AspNetCore.Http.Features - Version = v5.0.3
* Microsoft.EntityFrameworkCore.SqlServer - Version = v3.1.12
* Microsoft.IdentityModel.Tokens - Version = v6.8.0
* Newtonsoft.Json - Version = v13.0.1
* System.IdentityModel.Tokens.Jwt - Version = v6.8.0
  
</div>










