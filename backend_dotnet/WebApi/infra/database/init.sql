IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'myknowledge')
BEGIN
    CREATE DATABASE myknowledge;
    PRINT 'Database myknowledge created successfully!';
END
ELSE
BEGIN
    PRINT 'Database myknowledge already exists!';
END
