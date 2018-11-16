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
	AssessmentTypeID int FOREIGN KEY(AssessmentTypeID) REFERENCES AssessmentTypes(AssessmentTypeID) ON DELETE CASCADE ON UPDATE CASCADE,
	AssessmentTitle VARCHAR(MAX) NOT NULL,
	AssessmentDescription VARCHAR(MAX) NOT NULL,
	LastUpdate DATETIME
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
	StatementSensory VARCHAR(MAX) NOT NULL,
	Sensory VARCHAR(MAX) NOT NULL
)

--CREATE TABLE Sensories
--(
--	SensoryID INT PRIMARY KEY IDENTITY(1,1),
--	StatementSensoryID INT FOREIGN KEY(StatementSensoryID) REFERENCES StatementSensories(StatementSensoryID) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
--	Sensory VARCHAR(MAX) NOT NULL
--)



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



INSERT INTO Languages VALUES('Bahasa Indonesia'),('English')

INSERT INTO AssessmentTypes VALUES('Assessment Intelligence'),('Assessment Sensory'),('Assessment Procrasinator')
	
SELECT * FROM StatementIntelligences


SELECT * FROM StatementDetailIntelligences








