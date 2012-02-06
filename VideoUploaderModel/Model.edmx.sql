



-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 02/06/2012 23:14:07
-- Generated from EDMX file: C:\Users\malik\Documents\Visual Studio 2010\Projects\VideoUploader\VideoUploaderModel\Model.edmx
-- Target version: 2.0.0.0
-- --------------------------------------------------

DROP DATABASE IF EXISTS `videouploader`;
CREATE DATABASE `videouploader`;
USE `videouploader`;

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------

--    ALTER TABLE `Groupe` DROP CONSTRAINT `FK_DroitGroupe`;
--    ALTER TABLE `User` DROP CONSTRAINT `FK_GroupeUser`;
--    ALTER TABLE `Element` DROP CONSTRAINT `FK_UserFolder`;
--    ALTER TABLE `Comment` DROP CONSTRAINT `FK_ItemComment`;
--    ALTER TABLE `Comment` DROP CONSTRAINT `FK_UserComment`;
--    ALTER TABLE `Element_Item` DROP CONSTRAINT `FK_Item_inherits_Element`;
--    ALTER TABLE `Element_Folder` DROP CONSTRAINT `FK_Folder_inherits_Element`;

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;
    DROP TABLE IF EXISTS `Droit`;
    DROP TABLE IF EXISTS `Groupe`;
    DROP TABLE IF EXISTS `User`;
    DROP TABLE IF EXISTS `Element`;
    DROP TABLE IF EXISTS `Comment`;
    DROP TABLE IF EXISTS `Element_Item`;
    DROP TABLE IF EXISTS `Element_Folder`;
SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Droit'

CREATE TABLE `Droit` (
    `IdDroit` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `LirePublic` bool  NOT NULL,
    `EcrirePublic` bool  NOT NULL,
    `SuppPublic` bool  NOT NULL,
    `LirePrive` bool  NOT NULL,
    `EcrirePrive` bool  NOT NULL,
    `SuppPrive` bool  NOT NULL,
    `Admin` bool  NOT NULL
);

-- Creating table 'Groupe'

CREATE TABLE `Groupe` (
    `IdGroupe` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Nom` longtext  NOT NULL,
    `Descritpion` longtext  NULL,
    `DateCreation` datetime  NOT NULL,
    `DateMAJ` datetime  NOT NULL,
    `DroitIdDroit` int  NOT NULL
);

-- Creating table 'User'

CREATE TABLE `User` (
    `IdUser` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Nom` longtext  NOT NULL,
    `Prenom` longtext  NOT NULL,
    `Login` longtext  NOT NULL,
    `Password` longtext  NOT NULL,
    `DateCreation` datetime  NOT NULL,
    `DateMAJ` datetime  NOT NULL,
    `GroupeIdGroupe` int  NOT NULL
);

-- Creating table 'Element'

CREATE TABLE `Element` (
    `IdElement` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Nom` longtext  NOT NULL,
    `DateCreation` datetime  NOT NULL,
    `DateMAJ` datetime  NOT NULL,
    `UserIdUser` int  NOT NULL
);

-- Creating table 'Comment'

CREATE TABLE `Comment` (
    `IdComment` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Contenu` longtext  NOT NULL,
    `DateCreation` datetime  NOT NULL,
    `ItemIdElement` bigint  NOT NULL,
    `UserIdUser` int  NOT NULL
);

-- Creating table 'Element_Item'

CREATE TABLE `Element_Item` (
    `Descriptin` longtext  NULL,
    `Fichier` varbinary(100)  NULL,
    `UrlHD` longtext  NULL,
    `UrlLD` longtext  NULL,
    `Type` longtext  NOT NULL,
    `IdElement` bigint  NOT NULL
);

-- Creating table 'Element_Folder'

CREATE TABLE `Element_Folder` (
    `IdElement` bigint  NOT NULL
);



-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on `IdElement` in table 'Element_Item'

ALTER TABLE `Element_Item`
ADD CONSTRAINT `PK_Element_Item`
    PRIMARY KEY (`IdElement` );

-- Creating primary key on `IdElement` in table 'Element_Folder'

ALTER TABLE `Element_Folder`
ADD CONSTRAINT `PK_Element_Folder`
    PRIMARY KEY (`IdElement` );



-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on `DroitIdDroit` in table 'Groupe'

ALTER TABLE `Groupe`
ADD CONSTRAINT `FK_DroitGroupe`
    FOREIGN KEY (`DroitIdDroit`)
    REFERENCES `Droit`
        (`IdDroit`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DroitGroupe'

CREATE INDEX `IX_FK_DroitGroupe` 
    ON `Groupe`
    (`DroitIdDroit`);

-- Creating foreign key on `GroupeIdGroupe` in table 'User'

ALTER TABLE `User`
ADD CONSTRAINT `FK_GroupeUser`
    FOREIGN KEY (`GroupeIdGroupe`)
    REFERENCES `Groupe`
        (`IdGroupe`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupeUser'

CREATE INDEX `IX_FK_GroupeUser` 
    ON `User`
    (`GroupeIdGroupe`);

-- Creating foreign key on `UserIdUser` in table 'Element'

ALTER TABLE `Element`
ADD CONSTRAINT `FK_UserFolder`
    FOREIGN KEY (`UserIdUser`)
    REFERENCES `User`
        (`IdUser`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFolder'

CREATE INDEX `IX_FK_UserFolder` 
    ON `Element`
    (`UserIdUser`);

-- Creating foreign key on `ItemIdElement` in table 'Comment'

ALTER TABLE `Comment`
ADD CONSTRAINT `FK_ItemComment`
    FOREIGN KEY (`ItemIdElement`)
    REFERENCES `Element_Item`
        (`IdElement`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemComment'

CREATE INDEX `IX_FK_ItemComment` 
    ON `Comment`
    (`ItemIdElement`);

-- Creating foreign key on `UserIdUser` in table 'Comment'

ALTER TABLE `Comment`
ADD CONSTRAINT `FK_UserComment`
    FOREIGN KEY (`UserIdUser`)
    REFERENCES `User`
        (`IdUser`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserComment'

CREATE INDEX `IX_FK_UserComment` 
    ON `Comment`
    (`UserIdUser`);

-- Creating foreign key on `IdElement` in table 'Element_Item'

ALTER TABLE `Element_Item`
ADD CONSTRAINT `FK_Item_inherits_Element`
    FOREIGN KEY (`IdElement`)
    REFERENCES `Element`
        (`IdElement`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on `IdElement` in table 'Element_Folder'

ALTER TABLE `Element_Folder`
ADD CONSTRAINT `FK_Folder_inherits_Element`
    FOREIGN KEY (`IdElement`)
    REFERENCES `Element`
        (`IdElement`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
