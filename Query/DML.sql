INSERT INTO Languages VALUES('Bahasa Indonesia'),('English')

INSERT INTO AssessmentTypes VALUES('AssessmentIntelligence'),('AssessmentSensory'),('AssessmentProcrasinator')
	select * from AssessmentTypes

SELECT * FROM Assessments

SELECT * FROM ScoreProcrasinators


SELECT * FROM Transactions WHERE Status = 'YES' AND Jurusan = 'SOCS' AND NIM LIKE '19%'
SELECT * FROM Assessments
INSERT INTO Transactions(AssessmentID,NIM,Jurusan,[Status],TransactionDate)
VALUES
(1,'1901500578','SOCS','No',GETDATE()),
(1,'1901500598','SOCS','No',GETDATE()),
(1,'1901500528','SOIS','No',GETDATE()),
(2,'1901500518','DKV','No',GETDATE()),
(2,'1901500538','MTI','No',GETDATE()),
(3,'1901500558','Interior','No',GETDATE()),
(3,'1901500508','Architecture','No',GETDATE())

SELECT * FROM Transactions WHERE NIM = '1901500578' and AssessmentID = 1
UPDATE Transactions SET Status = 'No' WHERE TransactionID = 8


UPDATE ScoreProcrasinators SET EndValue = 5 


INSERT INTO StatementDetailIntelligences (StatementIntelligenceID,StatementDetailIntelligence) 
VALUES
(1,'I like read.'),
(1,'I enjoy finding out the meanings of new words.'),
(1,'I appreciate humor involving wordplay.'),
(1,'I enjoy telling or writing spoems or stories.'),
(1,'I recall written or verbal material well.'),

(2,'I like read.'),
(2,'I enjoy finding out the meanings of new words.'),
(2,'I appreciate humor involving wordplay.'),
(2,'I enjoy telling or writing spoems or stories.'),
(2,'I recall written or verbal material well.'),

(3,'I like read.'),
(3,'I enjoy finding out the meanings of new words.'),
(3,'I appreciate humor involving wordplay.'),
(3,'I enjoy telling or writing spoems or stories.'),
(3,'I recall written or verbal material well.'),

(4,'I like read.'),
(4,'I enjoy finding out the meanings of new words.'),
(4,'I appreciate humor involving wordplay.'),
(4,'I enjoy telling or writing spoems or stories.'),
(4,'I recall written or verbal material well.'),

(5,'I like read.'),
(5,'I enjoy finding out the meanings of new words.'),
(5,'I appreciate humor involving wordplay.'),
(5,'I enjoy telling or writing spoems or stories.'),
(5,'I recall written or verbal material well.'),

(6,'I like read.'),
(6,'I enjoy finding out the meanings of new words.'),
(6,'I appreciate humor involving wordplay.'),
(6,'I enjoy telling or writing spoems or stories.'),
(6,'I recall written or verbal material well.'),

(7,'I like read.'),
(7,'I enjoy finding out the meanings of new words.'),
(7,'I appreciate humor involving wordplay.'),
(7,'I enjoy telling or writing spoems or stories.'),
(7,'I recall written or verbal material well.'),

(8,'I like read.'),
(8,'I enjoy finding out the meanings of new words.'),
(8,'I appreciate humor involving wordplay.'),
(8,'I enjoy telling or writing spoems or stories.'),
(8,'I recall written or verbal material well.')


INSERT INTO Assessments (AssessmentTypeID,AssessmentTitle,AssessmentDescription,LastUpdate) 
VALUES(3,'Are You a Procrastinator ?',
'For each item, place a check mark in the column that most applies to you. Give yourself 4 points for each item you checked strongly agree, 
3 points for each item you checked mildly agree, 2 points for each item you checked mildly disagree, and 1 point for each item you checked strongly disagree. 
Total your points: if you scored above 30, you likely are a severe procrastinator, 21-30 a chronic procrastinator, and 20 or 
below an occasional procrastinator. 
If your score is 21 or above, seriously consider going to the college counseling center for some guidance in conquering procrastination.',GETDATE())




INSERT INTO Agreements(AssessmentProcrasinatorID,Agreement) 
VALUES
(1,'Strongly Agree'),
(1,'Midly Agree'),
(1,'Strongly Disagree'),
(1,'Midly Disagree')

SELECT * FROM ScoreProcrasinators

INSERT INTO ScoreProcrasinators (AssessmentProcrasinatorID,StartValue,EndValue,ScoreWord)
VALUES
(1,31,40,'Severe Procrastinator'),
(1,21,30,'Chronic Procrastinator'),
(1,0,20,'Occasional Procrastinator')


 

INSERT INTO StatementProcrasinators(AssessmentProcrasinatorID,StatementProcrasinator)
VALUES
(1,'I usually find reasons for not acting immediately on a difficult assignment.'),
(1,'I know what I have to do but frequently find that i have done something else.'),
(1,'I carry my books/work assignments with me to various places but do not open them.'),
(1,'I work best at the "last minute" when the pressure is really on.'),
(1,'There are too many interruptions that interfere with my accomplishing my top priorities.'),
(1,'I avoid forthright answers when pressed for an unpleasant or difficult decision.'),
(1,'I take half measures which will avoid or delay unpleasant or difficult action.'),
(1,'I have been too tired, nervous, or upset to do the difficult task that faces me.'),
(1,'I like to get my room in order before starting a difficult task.'),
(1,'I find myself waiting for inspiration before becoming involved in important study/work tasks.')


INSERT INTO Assessments(AssessmentTypeID,AssessmentTitle,AssessmentDescription,LastUpdate) 
VALUES
(2,'Sensory Preference Inventory',
'Using the scale below enter the appropriate rating to each self-description in the open box.<br>
Often = 5 points.<br>
Sometimes = 3 points.<br>
Seldom = 1 points.<br>
Then add up the numbers in each column to find out your dominant sensory preference.',GETDATE()
)


INSERT INTO Sensories(Sensory)
VALUES
('Visual'),
('Audio'),
('Tactile')

INSERT INTO ScoreSensories(AssessmentSensoryID,ScoreValue,ScoreWord)
VALUES
(1,5,'Often'),
(1,3,'Sometimes'),
(1,1,'Seldom')

INSERT INTO AssessmentSensories(AssessmentID) VALUES(3)

SELECT * FROM StatementSensories
INSERT INTO StatementSensories(AssessmentSensoryID,SensoryID,StatementSensory)
VALUES
(1,2,'I can remember best about a subject by listening to a lecture that includes information, explanations, and discussion.'),
(1,1,'I prefer to see information written on a chalkboard and supplemented by visual aids and assigned readings.'),
(1,1,'I like to write things down or take notes for visual review.'),
(1,3,'I prefer to use posters, models, or actual practice and do other activities in class.'),
(1,2,'I require explanations of diagrams, graphs, or visual directions.'),
(1,3,'I enjoy working with my hands or making things.'),
(1,1,'I am skillful with and enjoy developing and making graphs and charts.'),
(1,2,'I can tell if sounds match when presented with pairs of sounds.'),
(1,3,'I remember best by writing things down several times.'),
(1,1,'I can easily understand and follow directions on maps.'),


(1,2,'I do best in academic subjects by listening to lectures and tapes.'),
(1,3,'I play with coins or keys in my pocket.'),
(1,2,'I learn to spell better by repeating words out loud than by writing the words on paper.'),
(1,1,'I can understand a news article better by reading about it in the newspaper than by listening to a report about it on the radio.'),
(1,3,'I chew gum, smoke, or snack while studying.'),
(1,1,'I think the best way to remember something is to picture it in your head.'),
(1,3,'I learn the spelling of words by "finger spelling" them.'),
(1,2,'I would rather listen to a good lecture or speech than read about the same material in a textbook.'),
(1,1,'I am good at working and solving jigsaw puzzles and mazes.'),
(1,3,'I grip objects in my hands during learning periods.'),


(1,2,'I prefer listening to the news on the radio rather than reading about it in the newspaper.'),
(1,1,'I prefer obtaining information about an interesting subject by reading about it.'),
(1,3,'I feel very comfortable touching others, hugging, handshaking, etc.'),
(1,2,'I follow oral directions better than written ones.')
