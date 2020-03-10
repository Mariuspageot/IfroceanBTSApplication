-- MySQL Script generated by MySQL Workbench
-- Tue Mar 10 10:24:40 2020
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema projettrans
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema projettrans
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `projettrans` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `projettrans` ;

-- -----------------------------------------------------
-- Table `projettrans`.`departement`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projettrans`.`departement` (
  `idDepartement` INT(11) NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idDepartement`))
ENGINE = InnoDB
AUTO_INCREMENT = 45
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `projettrans`.`commune`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projettrans`.`commune` (
  `idCommune` INT(11) NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NOT NULL,
  `idDepartement` INT(11) NOT NULL,
  PRIMARY KEY (`idCommune`),
  INDEX `idDep_idx` (`idDepartement` ASC) VISIBLE,
  CONSTRAINT `idDep`
    FOREIGN KEY (`idDepartement`)
    REFERENCES `projettrans`.`departement` (`idDepartement`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `projettrans`.`ensembleplage`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projettrans`.`ensembleplage` (
  `idEnsemblePlage` INT(11) NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idEnsemblePlage`))
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci
COMMENT = '	';


-- -----------------------------------------------------
-- Table `projettrans`.`equipe`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projettrans`.`equipe` (
  `idEquipe` INT(11) NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idEquipe`))
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `projettrans`.`espece`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projettrans`.`espece` (
  `idEspece` INT(11) NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idEspece`))
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `projettrans`.`etude`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projettrans`.`etude` (
  `idEtude` INT(11) NOT NULL AUTO_INCREMENT,
  `titre` VARCHAR(45) NOT NULL,
  `idEnsemblePlage` INT(11) NOT NULL,
  `date` DATETIME NOT NULL,
  `idEquipe` INT(11) NOT NULL,
  PRIMARY KEY (`idEtude`),
  INDEX `idEnsemblePlage_idx` (`idEnsemblePlage` ASC) VISIBLE,
  INDEX `equipe_idx` (`idEquipe` ASC) VISIBLE,
  CONSTRAINT `equipe`
    FOREIGN KEY (`idEquipe`)
    REFERENCES `projettrans`.`equipe` (`idEquipe`),
  CONSTRAINT `idEnsemblePlage/Etude`
    FOREIGN KEY (`idEnsemblePlage`)
    REFERENCES `projettrans`.`ensembleplage` (`idEnsemblePlage`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `projettrans`.`etude/espece`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projettrans`.`etude/espece` (
  `idEtude/Espece` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre` INT(11) NULL DEFAULT NULL,
  `idEspece` INT(11) NULL DEFAULT NULL,
  `idEtude` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idEtude/Espece`),
  INDEX `idEtude_idx` (`idEtude` ASC) VISIBLE,
  INDEX `idEspece_idx` (`idEspece` ASC) VISIBLE,
  CONSTRAINT `idEspece`
    FOREIGN KEY (`idEspece`)
    REFERENCES `projettrans`.`espece` (`idEspece`),
  CONSTRAINT `idEtude`
    FOREIGN KEY (`idEtude`)
    REFERENCES `projettrans`.`etude` (`idEtude`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `projettrans`.`groupe`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projettrans`.`groupe` (
  `idGroupe` INT(11) NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idGroupe`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `projettrans`.`personne`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projettrans`.`personne` (
  `idPersonne` INT(11) NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NOT NULL,
  `prenom` VARCHAR(45) NOT NULL,
  `idGroupe` INT(11) NOT NULL,
  `passwd` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`idPersonne`),
  UNIQUE INDEX `idPersonne_UNIQUE` (`idPersonne` ASC) VISIBLE,
  INDEX `idGroupe_idx` (`idGroupe` ASC) VISIBLE,
  CONSTRAINT `idGroupe`
    FOREIGN KEY (`idGroupe`)
    REFERENCES `projettrans`.`groupe` (`idGroupe`))
ENGINE = InnoDB
AUTO_INCREMENT = 23
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `projettrans`.`personne_has_equipe`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projettrans`.`personne_has_equipe` (
  `personne_idPersonne` INT(11) NOT NULL,
  `equipe_idEquipe` INT(11) NOT NULL,
  PRIMARY KEY (`personne_idPersonne`, `equipe_idEquipe`),
  INDEX `fk_personne_has_equipe_equipe1_idx` (`equipe_idEquipe` ASC) VISIBLE,
  INDEX `fk_personne_has_equipe_personne1_idx` (`personne_idPersonne` ASC) VISIBLE,
  CONSTRAINT `fk_personne_has_equipe_equipe1`
    FOREIGN KEY (`equipe_idEquipe`)
    REFERENCES `projettrans`.`equipe` (`idEquipe`),
  CONSTRAINT `fk_personne_has_equipe_personne1`
    FOREIGN KEY (`personne_idPersonne`)
    REFERENCES `projettrans`.`personne` (`idPersonne`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `projettrans`.`plage`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projettrans`.`plage` (
  `idPlage` INT(11) NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NOT NULL,
  `idCommune` INT(11) NOT NULL,
  `superficie` INT(11) NOT NULL,
  `XA` INT(11) NULL DEFAULT NULL,
  `XB` INT(11) NULL DEFAULT NULL,
  `XC` INT(11) NULL DEFAULT NULL,
  `XD` INT(11) NULL DEFAULT NULL,
  `YA` INT(11) NULL DEFAULT NULL,
  `YB` INT(11) NULL DEFAULT NULL,
  `YC` INT(11) NULL DEFAULT NULL,
  `YD` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idPlage`),
  INDEX `idCommune_idx` (`idCommune` ASC) VISIBLE,
  CONSTRAINT `idCommune`
    FOREIGN KEY (`idCommune`)
    REFERENCES `projettrans`.`commune` (`idCommune`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `projettrans`.`plage_has_ensembleplage`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projettrans`.`plage_has_ensembleplage` (
  `plage_idPlage` INT(11) NOT NULL,
  `ensembleplage_idEnsemblePlage` INT(11) NOT NULL,
  PRIMARY KEY (`plage_idPlage`, `ensembleplage_idEnsemblePlage`),
  INDEX `fk_plage_has_ensembleplage_ensembleplage1_idx` (`ensembleplage_idEnsemblePlage` ASC) VISIBLE,
  INDEX `fk_plage_has_ensembleplage_plage1_idx` (`plage_idPlage` ASC) VISIBLE,
  CONSTRAINT `fk_plage_has_ensembleplage_ensembleplage1`
    FOREIGN KEY (`ensembleplage_idEnsemblePlage`)
    REFERENCES `projettrans`.`ensembleplage` (`idEnsemblePlage`),
  CONSTRAINT `fk_plage_has_ensembleplage_plage1`
    FOREIGN KEY (`plage_idPlage`)
    REFERENCES `projettrans`.`plage` (`idPlage`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;