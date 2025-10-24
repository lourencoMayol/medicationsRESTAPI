-- =============================================
-- seedMedications.sql
-- Inserts sample data into Medications table
-- =============================================

USE MedicationDb;
GO

INSERT INTO dbo.Medications (Name, Quantity, CreationDate)
VALUES
('Amoxicillin', 50, '2025-01-10'),
('Ibuprofen', 200, '2025-02-05'),
('Paracetamol', 300, '2025-03-12'),
('Aspirin', 150, '2025-04-08'),
('Loratadine', 120, '2025-05-02'),
('Cetirizine', 100, '2025-06-15'),
('Metformin', 250, '2025-07-21'),
('Atorvastatin', 180, '2025-08-30'),
('Omeprazole', 90, '2025-09-10'),
('Azithromycin', 75, '2025-10-05');
GO

PRINT 'Sample data inserted successfully.';
GO
