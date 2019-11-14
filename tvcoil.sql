MySql

CREATE DATABASE tvcoil;

CREATE TABLE tvcoil.BLOG(
	blogId int AUTO_INCREMENT,
	blogCategory nvarchar(50) NOT NULL,
	blogName nvarchar(50) NOT NULL,
	blogPublisher nvarchar(50) NOT NULL,
	blogContent nvarchar(1000) NOT NULL,
	blogDate datetime NOT NULL,
	blogMainPictureLink nvarchar(50) NOT NULL,
	PRIMARY KEY ( blogId )
);

CREATE TABLE tvcoil.BLOGCOMMENT(
	commentId int AUTO_INCREMENT,
	blogId int NOT NULL,
	commentContent nvarchar(1000) NOT NULL,
	PRIMARY KEY ( commentId ),
	FOREIGN KEY (blogId) REFERENCES BLOG (blogId)
);

CREATE TABLE tvcoil.NEWS(
	newsID int AUTO_INCREMENT,
	newsCategory nvarchar(50) NOT NULL,
	newsGenre nvarchar(50) NOT NULL,
	newsName nvarchar(50) NOT NULL,
	newsDescription nvarchar(50) NOT NULL,
	newsDateTime datetime NOT NULL,
	newsMainPictureLink nvarchar(50) NOT NULL,
	newsVideoLink nvarchar(50) NOT NULL,
	newsPrefered bit NOT NULL,
	PRIMARY KEY ( newsID )
);

CREATE TABLE tvcoil.PROGRAM(
	programID int AUTO_INCREMENT,
	programCategory nvarchar(50) NOT NULL,
	programGenre nvarchar(50) NOT NULL,
	programName nvarchar(50) NOT NULL,
	programDescription nvarchar(50) NOT NULL,
	programDateTime datetime NOT NULL,
	programMainPictureLink nvarchar(50) NOT NULL,
	programVideoLink nvarchar(50) NOT NULL,
	PRIMARY KEY ( programID )
);

CREATE TABLE tvcoil.TRANSLATION(
	translationKey nvarchar(50),
	translationEnglish nvarchar(50) NULL,
	translationHebrew nvarchar(50) NULL,
	PRIMARY KEY ( translationKey )
);



Delimiter $$
CREATE PROCEDURE tvcoil.DeleteBlog (IN blogId int)
BEGIN
	DELETE FROM Blog WHERE Blog.blogId=blogId;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.DeleteBlogComment (IN commentId int)
BEGIN
	DELETE FROM BlogComment WHERE BlogComment.commentId = commentId;
END $$
Delimiter ;



Delimiter $$
CREATE PROCEDURE tvcoil.DeleteNews (IN newsID int)
BEGIN
	DELETE FROM News WHERE News.newsID=newsID;
END $$
Delimiter ;



Delimiter $$
CREATE PROCEDURE tvcoil.DeleteProgram (IN programID int)
BEGIN
	DELETE FROM Program WHERE Program.programID=programID;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.DeleteTranslation (IN translationKey varchar(50))
BEGIN
	DELETE FROM Translation WHERE Translation.translationKey=translationKey;
END $$
Delimiter ;



Delimiter $$
CREATE PROCEDURE tvcoil.GetAllBlog()
BEGIN
	SELECT * from Blog;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.GetAllBlogComment()
BEGIN
	SELECT * from BlogComment;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.GetAllNews()
BEGIN
	SELECT * from News;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.GetAllPrograms()
BEGIN
	SELECT * from Program;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.GetAllTranslation()
BEGIN
	SELECT * from Translation;
END $$
Delimiter ;



Delimiter $$
CREATE PROCEDURE tvcoil.GetBlogById (IN blogId int)
BEGIN
	SELECT * from Blog where Blog.blogId=blogId;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.GetBlogCommentById (IN commentId int)
BEGIN
	SELECT * from BlogComment WHERE BlogComment.commentId = commentId;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.GetBlogCommentsByBlogId (IN blogId int)
BEGIN
	SELECT * from BlogComment WHERE BlogComment.blogId = blogId;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.GetNewsById (IN newsID int)
BEGIN
	SELECT * from News where News.newsID=newsID;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.GetProgramById (IN programID int)
BEGIN
	SELECT * from Program where Program.programID=programID;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.GetTranslationByKey (IN translationKey varchar(50))
BEGIN
	SELECT * from Translation where Translation.translationKey=translationKey;
END $$
Delimiter ;





Delimiter $$
CREATE PROCEDURE tvcoil.PostBlog (IN blogCategory varchar(50), IN blogName varchar(50), IN blogPublisher varchar(50), IN blogContent varchar(1000), IN blogDate datetime, IN blogMainPictureLink varchar(50))
BEGIN
	INSERT INTO Blog (blogCategory, blogName, blogPublisher, blogContent, blogDate, blogMainPictureLink) VALUES (blogCategory, blogName, blogPublisher, blogContent, blogDate, blogMainPictureLink);
	SELECT * FROM Blog WHERE Blog.blogId = SCOPE_IDENTITY();
END $$
Delimiter ;



Delimiter $$
CREATE PROCEDURE tvcoil.PostBlogComment (IN blogId int, IN commentContent varchar(1000))
BEGIN
	INSERT INTO BlogComment (blogId, commentContent) VALUES (blogId, commentContent);
	SELECT * FROM BlogComment WHERE BlogComment.commentId = SCOPE_IDENTITY();
END $$
Delimiter ;



Delimiter $$
CREATE PROCEDURE tvcoil.PostNews (IN newsCategory varchar(50), IN newsGenre varchar(50), IN newsName varchar(50), IN newsDescription varchar(50), IN newsDateTime datetime, IN newsMainPictureLink varchar(50), IN newsVideoLink varchar(50), IN newsPrefered bit)
BEGIN
	INSERT INTO News (newsCategory,newsGenre,newsName,newsDescription,newsDateTime,newsMainPictureLink,newsVideoLink,newsPrefered) VALUES (newsCategory, newsGenre, newsName, newsDescription, newsDateTime, newsMainPictureLink, newsVideoLink, newsPrefered);
	SELECT * FROM News WHERE News.newsID = SCOPE_IDENTITY();
END $$
Delimiter ;



Delimiter $$
CREATE PROCEDURE tvcoil.PostProgram (IN programCategory varchar(50), IN programGenre varchar(50), IN programName varchar(50), IN programDescription varchar(50), IN programDateTime datetime, IN programMainPictureLink varchar(50), IN programVideoLink varchar(50))
BEGIN
	INSERT INTO Program (programCategory, programGenre, programName, programDescription, programDateTime, programMainPictureLink, programVideoLink) VALUES (programCategory, programGenre, programName, programDescription, programDateTime, programMainPictureLink, programVideoLink);
	SELECT * FROM Program WHERE Program.programId = SCOPE_IDENTITY();
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.PostTranslation (IN translationKey varchar(50), IN translationEnglish varchar(50), IN translationHebrew varchar(50))
BEGIN
	INSERT INTO Translation (translationKey, translationEnglish, translationHebrew) VALUES (translationKey, translationEnglish, translationHebrew);
	SELECT * FROM Translation WHERE Translation.translationKey = translationKey;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.TopSixBlog()
BEGIN
	SELECT TOP (6) FROM Blog;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.TopSixBlogComment()
BEGIN
	SELECT TOP (6) FROM BlogComment;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.TopSixNews()
BEGIN
	SELECT TOP (6) FROM News;
END $$
Delimiter ;


Delimiter $$
CREATE PROCEDURE tvcoil.TopSixPrograms()
BEGIN
	SELECT TOP (6) FROM Program;
END $$
Delimiter ;




Delimiter $$
CREATE PROCEDURE tvcoil.UpdateBlog (IN blogId int, IN blogCategory varchar(50), IN blogName varchar(50), IN blogPublisher varchar(50), IN blogContent varchar(1000), IN blogDate datetime, IN blogMainPictureLink varchar(50))
BEGIN
	UPDATE Blog SET Blog.blogCategory = blogCategory, Blog.blogName = blogName, Blog.blogPublisher = blogPublisher, Blog.blogContent = blogContent, Blog.blogDate = blogDate, Blog.blogMainPictureLink = blogMainPictureLink WHERE Blog.blogId = blogId;
	SELECT * FROM Blog WHERE Blog.blogId=blogId;
END $$
Delimiter ;



Delimiter $$
CREATE PROCEDURE tvcoil.UpdateBlogComment (IN commentId int, IN blogId int, IN commentContent varchar(1000))
BEGIN
	UPDATE BlogComment SET BlogComment.commentContent = commentContent WHERE BlogComment.commentId = commentId AND BlogComment.blogId = blogId;
	SELECT * FROM BlogComment WHERE BlogComment.commentId = commentId;
END $$
Delimiter ;



Delimiter $$
CREATE PROCEDURE tvcoil.UpdateNews (IN newsID int, IN newsCategory varchar(50), IN newsGenre varchar(50), IN newsName varchar(50), IN newsDescription varchar(50), IN newsDateTime datetime, IN newsMainPictureLink varchar(50), IN newsVideoLink varchar(50), IN newsPrefered bit)
BEGIN
	UPDATE News SET News.newsCategory = newsCategory, News.newsGenre = newsGenre, News.newsName = newsName, News.newsDescription = newsDescription, News.newsDateTime = newsDateTime, News.newsMainPictureLink = newsMainPictureLink, News.newsVideoLink = newsVideoLink, News.newsPrefered = newsPrefered  WHERE News.newsID = newsID;
	SELECT * FROM News WHERE News.newsID = newsID;
END $$
Delimiter ;



Delimiter $$
CREATE PROCEDURE tvcoil.UpdateProgram (IN programID int, IN programCategory varchar(50), IN programGenre varchar(50), IN programName varchar(50), IN programDescription varchar(50), IN programDateTime datetime, IN programMainPictureLink varchar(50), IN programVideoLink varchar(50))
BEGIN
	UPDATE Program SET Program.programCategory = programCategory, Program.programGenre = programGenre, Program.programName = programName, Program.programDescription = programDescription, Program.programDateTime = programDateTime, Program.programMainPictureLink = programMainPictureLink, Program.programVideoLink = programVideoLink WHERE Program.programId = programId;
	SELECT * FROM Program WHERE Program.programId = programId;
END $$
Delimiter ;



Delimiter $$
CREATE PROCEDURE tvcoil.UpdateTranslation (IN translationKey varchar(50), IN translationEnglish varchar(50), IN translationHebrew varchar(50))
BEGIN
	UPDATE Translation SET Translation.translationEnglish = translationEnglish, Translation.translationHebrew = translationHebrew WHERE Translation.translationKey = translationKey;
	SELECT * FROM Translation WHERE Translation.translationKey = translationKey;
END $$
Delimiter ;



//-------------------------------------------------------------------------------------------------------------------------//
Sql

CREATE DATABASE tvcoil;

CREATE TABLE BLOG(
	blogId int IDENTITY PRIMARY KEY,
	blogCategory nvarchar(50) NOT NULL,
	blogName nvarchar(50) NOT NULL,
	blogPublisher nvarchar(50) NOT NULL,
	blogContent nvarchar(max) NOT NULL,
	blogDate datetime NOT NULL,
	blogMainPictureLink nvarchar(50) NOT NULL
);

CREATE TABLE BLOGCOMMENT(
	commentId int IDENTITY PRIMARY KEY,
	blogId int NOT NULL FOREIGN KEY REFERENCES BLOG(blogId),
	commentContent nvarchar(max) NOT NULL
);

CREATE TABLE NEWS(
	newsID int IDENTITY PRIMARY KEY,
	newsCategory nvarchar(50) NOT NULL,
	newsGenre nvarchar(50) NOT NULL,
	newsName nvarchar(50) NOT NULL,
	newsDescription nvarchar(50) NOT NULL,
	newsDateTime datetime NOT NULL,
	newsMainPictureLink nvarchar(50) NOT NULL,
	newsVideoLink nvarchar(50) NOT NULL,
	newsPrefered bit NOT NULL
);

CREATE TABLE PROGRAM(
	programID int IDENTITY PRIMARY KEY,
	programCategory nvarchar(50) NOT NULL,
	programGenre nvarchar(50) NOT NULL,
	programName nvarchar(50) NOT NULL,
	programDescription nvarchar(50) NOT NULL,
	programDateTime datetime NOT NULL,
	programMainPictureLink nvarchar(50) NOT NULL,
	programVideoLink nvarchar(50) NOT NULL
);

CREATE TABLE TRANSLATION(
	translationKey nvarchar(50) PRIMARY KEY,
	translationEnglish nvarchar(50) NULL,
	translationHebrew nvarchar(50) NULL
);


CREATE PROCEDURE [dbo].[DeleteBlog] @blogId int
AS
DELETE FROM Blog WHERE blogId=@blogId;


CREATE PROCEDURE [dbo].[DeleteBlogComment] @commentId int
AS
DELETE FROM BlogComment WHERE commentId = @commentId;


CREATE PROCEDURE [dbo].[DeleteNews] @newsID int
AS
DELETE FROM News WHERE newsID=@newsID;


CREATE PROCEDURE [dbo].[DeleteProgram] @programID int
AS
DELETE FROM Program WHERE programID=@programID;


CREATE PROCEDURE [dbo].[DeleteTranslation] @translationKey nvarchar(50)
AS
DELETE FROM Translation WHERE translationKey=@translationKey;


CREATE PROCEDURE [dbo].[GetAllBlog]
AS
SELECT * from Blog;


CREATE PROCEDURE [dbo].[GetAllBlogComment]
AS
SELECT * from BlogComment;


CREATE PROCEDURE [dbo].[GetAllNews]
AS
SELECT * from News;


CREATE PROCEDURE [dbo].[GetAllPrograms]
AS
SELECT * from Program;


CREATE PROCEDURE [dbo].[GetAllTranslation]
AS
SELECT * from Translation;


CREATE PROCEDURE [dbo].[GetBlogById] @blogId int
AS
SELECT * from Blog where blogId=@blogId;


CREATE PROCEDURE [dbo].[GetBlogCommentById] @commentId int
AS
SELECT * from BlogComment WHERE commentId = @commentId;


CREATE PROCEDURE [dbo].[GetBlogCommentsByBlogId] @blogId int
AS
SELECT * from BlogComment WHERE blogId = @blogId;


CREATE PROCEDURE [dbo].[GetNewsById] @newsID int
AS
SELECT * from News where newsID=@newsID;


CREATE PROCEDURE [dbo].[GetProgramById] @programID int
AS
SELECT * from Program where programID=@programID;


CREATE PROCEDURE [dbo].[GetTranslationByKey] @translationKey nvarchar(50)
AS
SELECT * from Translation where translationKey=@translationKey;


CREATE PROCEDURE [dbo].[PostBlog] (@blogCategory nvarchar(50), @blogName nvarchar(50), @blogPublisher nvarchar(50), @blogContent nvarchar(MAX), @blogDate datetime, @blogMainPictureLink nvarchar(50))
AS
INSERT INTO Blog (blogCategory, blogName, blogPublisher, blogContent, blogDate, blogMainPictureLink) VALUES (@blogCategory, @blogName, @blogPublisher, @blogContent, @blogDate, @blogMainPictureLink);
SELECT * FROM Blog WHERE blogId = SCOPE_IDENTITY();


CREATE PROCEDURE [dbo].[PostBlogComment] (@blogId int, @commentContent nvarchar(MAX))
AS
INSERT INTO BlogComment (blogId, commentContent) VALUES (@blogId, @commentContent);
SELECT * FROM BlogComment WHERE commentId = SCOPE_IDENTITY();


CREATE PROCEDURE [dbo].[PostNews] (@newsCategory nvarchar(50), @newsGenre nvarchar(50), @newsName nvarchar(50), @newsDescription nvarchar(50), @newsDateTime datetime, @newsMainPictureLink nvarchar(50), @newsVideoLink nvarchar(50), @newsPrefered bit)
AS
INSERT INTO News (newsCategory,newsGenre,newsName,newsDescription,newsDateTime,newsMainPictureLink,newsVideoLink,newsPrefered) VALUES (@newsCategory, @newsGenre, @newsName, @newsDescription, @newsDateTime, @newsMainPictureLink, @newsVideoLink, @newsPrefered);
SELECT * FROM News WHERE newsID = SCOPE_IDENTITY();


CREATE PROCEDURE [dbo].[PostProgram] (@programCategory nvarchar(50), @programGenre nvarchar(50), @programName nvarchar(50), @programDescription nvarchar(50), @programDateTime datetime, @programMainPictureLink nvarchar(50), @programVideoLink nvarchar(50))
AS
INSERT INTO Program (programCategory, programGenre, programName, programDescription, programDateTime, programMainPictureLink, programVideoLink) VALUES (@programCategory, @programGenre, @programName, @programDescription, @programDateTime, @programMainPictureLink, @programVideoLink);
SELECT * FROM Program WHERE programId = SCOPE_IDENTITY();


CREATE PROCEDURE [dbo].[PostTranslation] (@translationKey nvarchar(50), @translationEnglish nvarchar(50), @translationHebrew nvarchar(50))
AS
INSERT INTO Translation (translationKey, translationEnglish, translationHebrew) VALUES (@translationKey, @translationEnglish, @translationHebrew);
SELECT * FROM Translation WHERE translationKey = @translationKey;


CREATE PROCEDURE [dbo].[TopSixBlog]
AS
SELECT TOP (6) * FROM Blog;


CREATE PROCEDURE [dbo].[TopSixBlogComment]
AS
SELECT TOP (6) * FROM BlogComment;


CREATE PROCEDURE [dbo].[TopSixNews]
AS
SELECT TOP (6) * FROM News;


CREATE PROCEDURE [dbo].[TopSixPrograms]
AS
SELECT TOP (6) * FROM Program;


CREATE PROCEDURE [dbo].[UpdateBlog] (@blogId int, @blogCategory nvarchar(50), @blogName nvarchar(50), @blogPublisher nvarchar(50), @blogContent nvarchar(MAX), @blogDate datetime, @blogMainPictureLink nvarchar(50))
AS
UPDATE Blog SET blogCategory = @blogCategory, blogName = @blogName, blogPublisher = @blogPublisher, blogContent = @blogContent, blogDate = @blogDate, blogMainPictureLink = @blogMainPictureLink WHERE blogId = @blogId;
SELECT * FROM Blog WHERE blogId=@blogId;


CREATE PROCEDURE [dbo].[UpdateBlogComment] (@commentId int, @blogId int, @commentContent nvarchar(MAX))
AS
UPDATE BlogComment SET commentContent = @commentContent WHERE commentId = @commentId AND blogId = @blogId;
SELECT * FROM BlogComment WHERE commentId = @commentId;


CREATE PROCEDURE [dbo].[UpdateNews] (@newsID int, @newsCategory nvarchar(50), @newsGenre nvarchar(50), @newsName nvarchar(50), @newsDescription nvarchar(50), @newsDateTime datetime, @newsMainPictureLink nvarchar(50), @newsVideoLink nvarchar(50), @newsPrefered bit)
AS
UPDATE News SET newsCategory = @newsCategory, newsGenre = @newsGenre, newsName = @newsName, newsDescription = @newsDescription, newsDateTime = @newsDateTime, newsMainPictureLink = @newsMainPictureLink, newsVideoLink = @newsVideoLink, newsPrefered = @newsPrefered  WHERE newsID = @newsID;
SELECT * FROM News WHERE newsID = @newsID;


CREATE PROCEDURE [dbo].[UpdateProgram] (@programID int, @programCategory nvarchar(50), @programGenre nvarchar(50), @programName nvarchar(50), @programDescription nvarchar(50), @programDateTime datetime, @programMainPictureLink nvarchar(50), @programVideoLink nvarchar(50))
AS
UPDATE Program SET programCategory = @programCategory, programGenre = @programGenre, programName = @programName, programDescription = @programDescription, programDateTime = @programDateTime, programMainPictureLink = @programMainPictureLink, programVideoLink = @programVideoLink WHERE programId = @programId;
SELECT * FROM Program WHERE programId = @programId;


CREATE PROCEDURE [dbo].[UpdateTranslation] (@translationKey nvarchar(50), @translationEnglish nvarchar(50), @translationHebrew nvarchar(50))
AS
UPDATE Translation SET translationEnglish = @translationEnglish, translationHebrew = @translationHebrew WHERE translationKey = @translationKey;
SELECT * FROM Translation WHERE translationKey = @translationKey;








INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('header-nav-homePage', N'דף הבית');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('header-nav-programs', N'תוכניות');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('header-nav-news', N'חדשות');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('header-nav-blog', N'בלוג');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('header-nav-contacts', N'צור קשר');

INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('header-signUp', N'הרשמה');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('header-signIn', N'כניסה');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('header-search', N'חיפוש');

INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('program-nav-sport', N'ספורט');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('program-nav-music', N'מוזיקה');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('program-nav-video', N'וידיאו');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('program-nav-education', N'חינוך');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('program-nav-game', N'משחק');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('program-nav-talkshow', N'טאוק-שואו');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('program-nav-analytics', N'אנאליטיקה');

INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-homePage', N'דף הבית');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-television', N'טלויזיה');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-radio', N'רדיאו');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-production', N'הפקה');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-support', N'תמיכה');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-FAQs', N'FAQs');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-usageRules', N'חוקי שימוש');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-policy', N'מדיניות');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-journalism', N'עיתונאות');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-communication', N'דרכי תקשורת');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-careers', N'הצעות עבודה');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-aboutUs', N'על החברה');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-digitalMedia', N'מדיה דגיטלי');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-ourTeam', N'צוות שלנו');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-events', N'אירועים');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-advertisers', N'מפרסמים');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-broadcastMode', N'אופן שידור');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-broadcastQuality', N'איכות שידור');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-businessOffers', N'להצעות עסקיים');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('footer-nav-worldBroadcast', N'שידור עולמי');

INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('section-watchTonight', N'צפו הערב:');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('section-newVideo', N'וידיאו חדש:');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('section-whatsNew', N'מה חדש:');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('section-allPrograms', N'כל התוכניות:');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('section-chooseByDate', N'בחר לפי תאריך:');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('section-preferedNews', N'חדשות מומלצות:');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('section-sportEvents', N'אירועי ספורט:');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('section-highlights', N'עיקרי הדברים:');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('section-latestBlogs', N'הודעות האחרונות:');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('section-blogCategories', N'קטגוריות:');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('section-blogArchives', N'ארכיון:');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('section-findUs', N'מצא אותנו:');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('section-contactUs', N'ליצירת קשר:');

INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('form-name', N'*שם');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('form-telephone', N'*טלפון');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('form-email', N'*כתובת אלקטרוני');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('form-message', N'*רשום הודעה כאן');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('form-cancel', N'*מחק');
INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('form-submit', N'*שלח');

INSERT INTO tvcoil.TRANSLATION (translationKey, translationHebrew) VALUES ('button-more', N'לקרוא עוד...');