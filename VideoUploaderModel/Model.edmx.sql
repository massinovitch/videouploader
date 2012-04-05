



-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 04/05/2012 23:24:56
-- Generated from EDMX file: C:\Users\IBM_ADMIN\Documents\Visual Studio 2010\Projects\VideoUploader\VideoUploaderModel\Model.edmx
-- Target version: 2.0.0.0
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------

--    ALTER TABLE `VUGroupe` DROP CONSTRAINT `FK_DroitGroupe`;
--    ALTER TABLE `VUUser` DROP CONSTRAINT `FK_GroupeUser`;
--    ALTER TABLE `VUElement` DROP CONSTRAINT `FK_UserFolder`;
--    ALTER TABLE `VUComment` DROP CONSTRAINT `FK_ItemComment`;
--    ALTER TABLE `VUComment` DROP CONSTRAINT `FK_UserComment`;
--    ALTER TABLE `VUElement` DROP CONSTRAINT `FK_VUFolderVUElement`;
--    ALTER TABLE `VUElement` DROP CONSTRAINT `FK_VUDroitElementVUElement`;
--    ALTER TABLE `VUElement_VUItem` DROP CONSTRAINT `FK_VUItem_inherits_VUElement`;
--    ALTER TABLE `VUElement_VUFolder` DROP CONSTRAINT `FK_VUFolder_inherits_VUElement`;

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;
    DROP TABLE IF EXISTS `VUDroit`;
    DROP TABLE IF EXISTS `VUGroupe`;
    DROP TABLE IF EXISTS `VUUser`;
    DROP TABLE IF EXISTS `VUElement`;
    DROP TABLE IF EXISTS `VUComment`;
    DROP TABLE IF EXISTS `VUDroitElement`;
    DROP TABLE IF EXISTS `VUElement_VUItem`;
    DROP TABLE IF EXISTS `VUElement_VUFolder`;
SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'VUDroit'

CREATE TABLE `VUDroit` (
    `IdDroit` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Admin` bool  NOT NULL
);

-- Creating table 'VUGroupe'

CREATE TABLE `VUGroupe` (
    `IdGroupe` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Nom` longtext  NOT NULL,
    `Description` longtext  NULL,
    `DateCreation` datetime  NOT NULL,
    `DateMAJ` datetime  NOT NULL,
    `DroitIdDroit` int  NOT NULL
);

-- Creating table 'VUUser'

CREATE TABLE `VUUser` (
    `IdUser` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Nom` longtext  NOT NULL,
    `Prenom` longtext  NOT NULL,
    `Login` longtext  NOT NULL,
    `Password` longtext  NOT NULL,
    `DateCreation` datetime  NOT NULL,
    `DateMAJ` datetime  NOT NULL,
    `GroupeIdGroupe` int  NOT NULL
);

-- Creating table 'VUElement'

CREATE TABLE `VUElement` (
    `IdElement` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Nom` longtext  NOT NULL,
    `DateCreation` datetime  NOT NULL,
    `DateMAJ` datetime  NOT NULL,
    `UserIdUser` int  NOT NULL,
    `VUFolderIdElement` bigint  NULL,
    `VUDroitElementIdVUDroitElement` int  NOT NULL
);

-- Creating table 'VUComment'

CREATE TABLE `VUComment` (
    `IdComment` bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Contenu` longtext  NOT NULL,
    `DateCreation` datetime  NOT NULL,
    `ItemIdElement` bigint  NOT NULL,
    `UserIdUser` int  NOT NULL
);

-- Creating table 'VUDroitElement'

CREATE TABLE `VUDroitElement` (
    `IdVUDroitElement` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `EcrireUser` bool  NULL,
    `LireUser` bool  NULL,
    `EcrireGroupe` bool  NULL,
    `LireGroupe` bool  NULL,
    `EcrireAutre` bool  NULL,
    `LireAutre` bool  NULL
);

-- Creating table 'VUElement_VUItem'

CREATE TABLE `VUElement_VUItem` (
    `Description` longtext  NULL,
    `FichierHD` varbinary(100)  NULL,
    `UrlHD` longtext  NULL,
    `UrlLD` longtext  NULL,
    `Type` longtext  NOT NULL,
    `FichierLD` varbinary(100)  NULL,
    `IdElement` bigint  NOT NULL
);

-- Creating table 'VUElement_VUFolder'

CREATE TABLE `VUElement_VUFolder` (
    `IdElement` bigint  NOT NULL
);



-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on `IdElement` in table 'VUElement_VUItem'

ALTER TABLE `VUElement_VUItem`
ADD CONSTRAINT `PK_VUElement_VUItem`
    PRIMARY KEY (`IdElement` );

-- Creating primary key on `IdElement` in table 'VUElement_VUFolder'

ALTER TABLE `VUElement_VUFolder`
ADD CONSTRAINT `PK_VUElement_VUFolder`
    PRIMARY KEY (`IdElement` );



-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on `DroitIdDroit` in table 'VUGroupe'

ALTER TABLE `VUGroupe`
ADD CONSTRAINT `FK_DroitGroupe`
    FOREIGN KEY (`DroitIdDroit`)
    REFERENCES `VUDroit`
        (`IdDroit`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DroitGroupe'

CREATE INDEX `IX_FK_DroitGroupe` 
    ON `VUGroupe`
    (`DroitIdDroit`);

-- Creating foreign key on `GroupeIdGroupe` in table 'VUUser'

ALTER TABLE `VUUser`
ADD CONSTRAINT `FK_GroupeUser`
    FOREIGN KEY (`GroupeIdGroupe`)
    REFERENCES `VUGroupe`
        (`IdGroupe`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupeUser'

CREATE INDEX `IX_FK_GroupeUser` 
    ON `VUUser`
    (`GroupeIdGroupe`);

-- Creating foreign key on `UserIdUser` in table 'VUElement'

ALTER TABLE `VUElement`
ADD CONSTRAINT `FK_UserFolder`
    FOREIGN KEY (`UserIdUser`)
    REFERENCES `VUUser`
        (`IdUser`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFolder'

CREATE INDEX `IX_FK_UserFolder` 
    ON `VUElement`
    (`UserIdUser`);

-- Creating foreign key on `ItemIdElement` in table 'VUComment'

ALTER TABLE `VUComment`
ADD CONSTRAINT `FK_ItemComment`
    FOREIGN KEY (`ItemIdElement`)
    REFERENCES `VUElement_VUItem`
        (`IdElement`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemComment'

CREATE INDEX `IX_FK_ItemComment` 
    ON `VUComment`
    (`ItemIdElement`);

-- Creating foreign key on `UserIdUser` in table 'VUComment'

ALTER TABLE `VUComment`
ADD CONSTRAINT `FK_UserComment`
    FOREIGN KEY (`UserIdUser`)
    REFERENCES `VUUser`
        (`IdUser`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserComment'

CREATE INDEX `IX_FK_UserComment` 
    ON `VUComment`
    (`UserIdUser`);

-- Creating foreign key on `VUFolderIdElement` in table 'VUElement'

ALTER TABLE `VUElement`
ADD CONSTRAINT `FK_VUFolderVUElement`
    FOREIGN KEY (`VUFolderIdElement`)
    REFERENCES `VUElement_VUFolder`
        (`IdElement`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VUFolderVUElement'

CREATE INDEX `IX_FK_VUFolderVUElement` 
    ON `VUElement`
    (`VUFolderIdElement`);

-- Creating foreign key on `VUDroitElementIdVUDroitElement` in table 'VUElement'

ALTER TABLE `VUElement`
ADD CONSTRAINT `FK_VUDroitElementVUElement`
    FOREIGN KEY (`VUDroitElementIdVUDroitElement`)
    REFERENCES `VUDroitElement`
        (`IdVUDroitElement`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VUDroitElementVUElement'

CREATE INDEX `IX_FK_VUDroitElementVUElement` 
    ON `VUElement`
    (`VUDroitElementIdVUDroitElement`);

-- Creating foreign key on `IdElement` in table 'VUElement_VUItem'

ALTER TABLE `VUElement_VUItem`
ADD CONSTRAINT `FK_VUItem_inherits_VUElement`
    FOREIGN KEY (`IdElement`)
    REFERENCES `VUElement`
        (`IdElement`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on `IdElement` in table 'VUElement_VUFolder'

ALTER TABLE `VUElement_VUFolder`
ADD CONSTRAINT `FK_VUFolder_inherits_VUElement`
    FOREIGN KEY (`IdElement`)
    REFERENCES `VUElement`
        (`IdElement`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
