
DROP DATABASE Binus
CREATE DATABASE Binus

USE Binus

DROP TABLE AssessmentTypes
DROP TABLE Languages
DROP TABLE ScoreIntelligences
DROP TABLE StatementIntelligences
DROP TABLE StatementDetailIntelligences
DROP TABLE AssessmentIntelligences

DROP TABLE ScoreSensories
DROP TABLE StatementSensories
DROP TABLE Sensories
DROP TABLE AssessmentProcrasinators

DROP TABLE ScoreProcrasinators
DROP TABLE StatementProcrasinators
DROP TABLE Agreements
DROP TABLE AssessmentProcrasinators

DROP TABLE Transactions
DROP TABLE ResultAssessments

GO

CREATE TABLE AssessmentTypes
(
	AssessmentTypeID int primary key identity(1,1),
	AssessmentType varchar(MAX) NOT NULL
)	
CREATE TABLE Languages
(
	LanguageID int PRIMARY KEY IDENTITY(1,1),
	[Language] varchar(MAX) NOT NULL
)

CREATE TABLE Assessments
(
	AssessmentID INT PRIMARY KEY IDENTITY(1,1),
	AssessmentTypeID int FOREIGN KEY(AssessmentTypeID) REFERENCES AssessmentTypes(AssessmentTypeID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	AssessmentTitle VARCHAR(MAX) NOT NULL,
	AssessmentDescription VARCHAR(MAX) NOT NULL,
	LastUpdate DATETIME NOT NULL
)

--CREATE TABLE Transactions
--(
--	TransactionID INT PRIMARY KEY IDENTITY(1,1),
--	AssessmentID int FOREIGN KEY(AssessmentID) REFERENCES Assessments(AssessmentID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
--	TransactionDate DATETIME NOT NULL,
--	LastUpdate DATETIME NOT NULL,
--)

CREATE TABLE ResultAssessments
(
	ResultAssessmentID int primary key identity(1,1),
	AssessmentID int FOREIGN KEY(AssessmentID) REFERENCES Assessments(AssessmentID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	NIM VARCHAR(MAX) NOT NULL,
	ResultWord varchar(MAX) NOT NULL,
	Note varchar(MAX) NOT NULL
)
drop table ResultAssessments


SELECT * FROM ResultAssessments
update Transactions SET status = 'NO' WHERE TransactionID = 2

CREATE TABLE Transactions
(
    TransactionID int primary key identity(1,1),
    AssessmentID int FOREIGN KEY(AssessmentID) REFERENCES Assessments(AssessmentID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	NIM VARCHAR(MAX) NOT NULL,
	[Jurusan] VARCHAR(MAX) NOT NULL,
	[Status] VARCHAR(MAX) NOT NULL,
    TransactionDate DATETIME NOT NULL
) 


--START INTELLIGENCE
CREATE TABLE AssessmentIntelligences
(
	AssessmentIntelligenceID INT PRIMARY KEY IDENTITY(1,1),
	AssessmentID int FOREIGN KEY(AssessmentID) REFERENCES Assessments(AssessmentID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL
 )


CREATE TABLE StatementIntelligences
(
	StatementIntelligenceID INT primary key IDENTITY(1,1),
	AssessmentIntelligenceID INT FOREIGN KEY(AssessmentIntelligenceID) REFERENCES AssessmentIntelligences(AssessmentIntelligenceID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	StatementIntelligence VARCHAR(MAX) NOT NULL
)

CREATE TABLE StatementDetailIntelligences
(
	StatementDetailIntelligenceID INT PRIMARY KEY IDENTITY(1,1),
	StatementIntelligenceID INT FOREIGN KEY(StatementIntelligenceID) REFERENCES StatementIntelligences(StatementIntelligenceID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	StatementDetailIntelligence VARCHAR(MAX) NOT NULL
)

CREATE TABLE ScoreIntelligences
(
	ScoreIntelligenceID INT PRIMARY KEY IDENTITY(1,1),
	AssessmentIntelligenceID INT FOREIGN KEY(AssessmentIntelligenceID) REFERENCES AssessmentIntelligences(AssessmentIntelligenceID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	ScoreValue INT NOT NULL,
	ScoreWord VARCHAR(MAX) NOT NULL
)
--END INTELLIGENCE


--START SENSORY
CREATE TABLE AssessmentSensories
(
	AssessmentSensoryID INT PRIMARY KEY IDENTITY(1,1),
	AssessmentID int FOREIGN KEY(AssessmentID) REFERENCES Assessments(AssessmentID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL
)


CREATE TABLE StatementSensories
(
	StatementSensoryID INT PRIMARY KEY IDENTITY(1,1),
	AssessmentSensoryID INT FOREIGN KEY(AssessmentSensoryID) REFERENCES AssessmentSensories(AssessmentSensoryID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	SensoryID INT FOREIGN KEY(SensoryID) REFERENCES Sensories(SensoryID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	StatementSensory VARCHAR(MAX) NOT NULL,
)



CREATE TABLE Sensories
(
	SensoryID INT PRIMARY KEY IDENTITY(1,1),
	Sensory VARCHAR(MAX) NOT NULL
)



CREATE TABLE ScoreSensories
(
	ScoreSensoryID INT PRIMARY KEY IDENTITY(1,1),
	AssessmentSensoryID INT FOREIGN KEY(AssessmentSensoryID) REFERENCES AssessmentSensories(AssessmentSensoryID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	ScoreValue INT NOT NULL,
	ScoreWord VARCHAR(MAX) NOT NULL
)
--END SENSORY

--START PROCRASINATOR
Create TABLE AssessmentProcrasinators
(
	AssessmentProcrasinatorID INT PRIMARY KEY IDENTITY(1,1),
	AssessmentID int FOREIGN KEY(AssessmentID) REFERENCES Assessments(AssessmentID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL
)

CREATE TABLE StatementProcrasinators
(
	StatementProcrasiantorID INT PRIMARY KEY IDENTITY(1,1),
	AssessmentProcrasinatorID INT FOREIGN KEY(AssessmentProcrasinatorID) REFERENCES AssessmentProcrasinators(AssessmentProcrasinatorID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	StatementProcrasinator VARCHAR(MAX) NOT NULL
)

CREATE TABLE Agreements
(
	AgreementID INT PRIMARY KEY IDENTITY(1,1),
	AssessmentProcrasinatorID INT FOREIGN KEY(AssessmentProcrasinatorID) REFERENCES AssessmentProcrasinators(AssessmentProcrasinatorID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	Agreement VARCHAR(MAX) NOT NULL
)

CREATE TABLE ScoreProcrasinators
(
	ScoreProcrasinatorID INT PRIMARY KEY IDENTITY(1,1),
	AssessmentProcrasinatorID INT FOREIGN KEY(AssessmentProcrasinatorID) REFERENCES AssessmentProcrasinators(AssessmentProcrasinatorID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	ScoreWord VARCHAR(MAX) NOT NULL,
	StartValue INT NOT NULL,
	EndValue INT NOT NULL
)

--END PROCRASINATOR









