USE Gehirnjogging;
GO

EXEC sp_rename 'Levels.ThreeStartime', 'ThreeStarTime', 'COLUMN';
GO

EXEC sp_rename 'Levels.TwoStartime', 'TwoStarTime', 'COLUMN';
GO

EXEC sp_rename 'Levels.OneStartime', 'OneStarTime', 'COLUMN';
GO

ALTER TABLE Levels ALTER Column ThreeStarTime INT NOT NULL;
GO

ALTER TABLE Levels ALTER Column TwoStarTime INT NOT NULL;
GO

ALTER TABLE Levels ALTER Column OneStarTime INT NOT NULL;
GO