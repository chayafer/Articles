--the first script load data from a json file to the db
--change the path of the json file

Declare @JSON varchar(max)
SELECT @JSON=BulkColumn
FROM OPENROWSET (BULK 'C:\Users\idphil\articles_data.json', SINGLE_CLOB) import
SELECT * INTO Articles FROM OPENJSON (@JSON)
 
WITH  (
   [Title] varchar(20),  
   [Image] varchar(200), 
   [CategoryId] int, 
   [Description] varchar(max)  
   );
   
--normalize the data
delete from Articles where Image is null

--add id col
ALTER TABLE Articles  ADD ID INT IDENTITY(1,1) NOT NULL

GO


--create Categories table

CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
	[Icon] [varchar](20) NULL
) ON [PRIMARY]
GO

--create [Favorite] table
CREATE TABLE [dbo].[Favorite](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](20) NULL,
	[ArticleId] [int] NOT NULL,
 CONSTRAINT [PK_Favorite_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
