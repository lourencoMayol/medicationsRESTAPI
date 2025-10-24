-- =============================================
-- createMedicationDb.sql
-- Creates the MedicationDb database and Medications table
-- =============================================

-- Create the database (only if it doesn’t exist)
IF NOT EXISTS (
    SELECT name FROM sys.databases WHERE name = N'MedicationDb'
)
BEGIN
    CREATE DATABASE MedicationDb;
    PRINT 'Database MedicationDb created successfully.';
END
ELSE
BEGIN
    PRINT 'Database MedicationDb already exists.';
END
GO

USE MedicationDb;
GO

IF OBJECT_ID('dbo.Medications', 'U') IS NOT NULL
    DROP TABLE dbo.Medications;
GO

CREATE TABLE dbo.Medications (
    MedId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    CreationDate DATETIME NOT NULL
);
GO

PRINT 'Table Medications created successfully.';
GO
