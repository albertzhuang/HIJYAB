USE Binus

DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR

SET @Cursor = CURSOR FAST_FORWARD FOR
SELECT DISTINCT sql = 'ALTER TABLE [' + tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + ']'
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME =rc1.CONSTRAINT_NAME

OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql

WHILE (@@FETCH_STATUS = 0)
BEGIN
Exec sp_executesql @Sql
FETCH NEXT FROM @Cursor INTO @Sql
END

CLOSE @Cursor DEALLOCATE @Cursor
GO

EXEC sp_MSforeachtable 'DROP TABLE ?'
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

CREATE TABLE Transactions
(
	TransactionID INT PRIMARY KEY IDENTITY(1,1),
	AssessmentID INT FOREIGN KEY(AssessmentID) REFERENCES Assessments(AssessmentID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	NIM VARCHAR(MAX) NOT NULL,
	[Status] VARCHAR(MAX) NOT NULL,
	TransactionDate DATETIME NOT NULL,
	LastUpdate DATETIME NOT NULL,
)

CREATE TABLE ResultAssessments
(
	ResultAssessmentID INT PRIMARY KEY IDENTITY(1,1),
	AssessmentID INT FOREIGN KEY(AssessmentID) REFERENCES Assessments(AssessmentID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	ResultWord VARCHAR(MAX) NOT NULL,
	ResultValue INT NOT NULL
)


--resultAssessment with student data
CREATE TABLE ResultAssessments
(
	ResultAssessmentID int primary key identity(1,1),
	AssessmentID int FOREIGN KEY(AssessmentID) REFERENCES Assessments(AssessmentID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	Institution VARCHAR(MAX) NOT NULL,
	AcademikCareer VARCHAR(MAX) NOT NULL,
	Campus VARCHAR(MAX) NOT NULL,
	AcademicGroup VARCHAR(MAX) NOT NULL,
	AcademicOrganization VARCHAR(MAX) NOT NULL,
	AcademicProgram VARCHAR(MAX) NOT NULL,
	AcademicYear VARCHAR(MAX) NOT NULL,
	[Status] VARCHAR(MAX) NOT NULL,
	BinusianID VARCHAR(MAX) NOT NULL,
	Result varchar(MAX) NOT NULL,
	Describe varchar(MAX) NOT NULL
)


-- transaction with student data
CREATE TABLE Transactions
(
    TransactionID int primary key identity(1,1),
    AssessmentID int FOREIGN KEY(AssessmentID) REFERENCES Assessments(AssessmentID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
    Institution VARCHAR(MAX) NOT NULL,
    AcademikCareer VARCHAR(MAX) NOT NULL,
    Campus VARCHAR(MAX) NOT NULL,
    AcademicGroup VARCHAR(MAX) NOT NULL,
    AcademicOrganization VARCHAR(MAX) NOT NULL,
    AcademicProgram VARCHAR(MAX) NOT NULL,
    AcademicYear VARCHAR(MAX) NOT NULL,
    [Status] VARCHAR(MAX) NOT NULL,
    BinusianID VARCHAR(MAX) NOT NULL,
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

CREATE TABLE Sensories
(
	SensoryID INT PRIMARY KEY IDENTITY(1,1),
	Sensory VARCHAR(MAX) NOT NULL
)

CREATE TABLE StatementSensories
(
	StatementSensoryID INT PRIMARY KEY IDENTITY(1,1),
	SensoryID INT FOREIGN KEY(SensoryID) REFERENCES Sensories(SensoryID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	AssessmentSensoryID INT FOREIGN KEY(AssessmentSensoryID) REFERENCES AssessmentSensories(AssessmentSensoryID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	StatementSensory VARCHAR(MAX) NOT NULL,	
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




USE BINUS

DROP TABLE Users

CREATE TABLE Users
(
	UserID INT PRIMARY KEY IDENTITY(1,1),
	Username VARCHAR(MAX) NOT NULL,
	Password VARCHAR(MAX) NOT NULL
)

INSERT INTO Users VALUES('test', 'test')




