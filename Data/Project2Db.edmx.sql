










































-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 12/16/2020 21:23:53

-- Generated from EDMX file: C:\Users\AKPOLAT\source\repos\hasanakpolad\ProjectWCF2\Data\Project2Db.edmx
-- Target version: 3.0.0.0

-- --------------------------------------------------



-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------



-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;

    DROP TABLE IF EXISTS `customer`;

SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------


CREATE TABLE `customer`(
	`Id` int NOT NULL, 
	`UserName` varchar (45), 
	`Password` varchar (45), 
	`Mail` varchar (45));

ALTER TABLE `customer` ADD PRIMARY KEY (Id);





CREATE TABLE `product`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE,
	`ProductName` varchar(45),
	`Price` double NOT NULL, 
	`Stock` int NOT NULL);

ALTER TABLE `product` ADD PRIMARY KEY (Id);





CREATE TABLE `buy_history`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`ProductName` longtext NOT NULL, 
	`Price` double NOT NULL, 
	`Count` int NOT NULL, 
	`CustomerId` int NOT NULL, 
	`ProductId` int NOT NULL);

ALTER TABLE `buy_history` ADD PRIMARY KEY (Id);





CREATE TABLE `log`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`FirstDatetime` datetime NOT NULL, 
	`Text` longtext NOT NULL, 
	`LastDatetime` datetime NOT NULL);

ALTER TABLE `log` ADD PRIMARY KEY (Id);







-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
