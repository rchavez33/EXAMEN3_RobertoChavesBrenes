CREATE DATABASE DBROBERTO_CHAVES

USE DBROBERTO_CHAVES
GO

CREATE TABLE Encuestas
(
    EncuestaID INT IDENTITY(1,1) PRIMARY KEY,
    NombreParticipante VARCHAR(100) NOT NULL,
    Edad INT NOT NULL,
    CorreoElectronico VARCHAR(100) NOT NULL,
    PartidoID INT
    FOREIGN KEY (PartidoID) REFERENCES PartidosPoliticos(PartidoID)
);

CREATE TABLE PartidosPoliticos
(
    PartidoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);
Select * from PartidosPoliticos


INSERT INTO PartidosPoliticos (Nombre) VALUES ('PLN'), ('PUSC'), ('PAC');



CREATE PROCEDURE AgregarEncuesta
    @NombreParticipante VARCHAR(100),
    @Edad INT,
    @CorreoElectronico VARCHAR(100),
    @PartidoID INT
AS
BEGIN
    INSERT INTO Encuestas (NombreParticipante, Edad, CorreoElectronico, PartidoID)
    VALUES (@NombreParticipante, @Edad, @CorreoElectronico, @PartidoID);
END;


CREATE PROCEDURE ObtenerEncuestas
AS
BEGIN
    SELECT 
        E.EncuestaID,
        E.NombreParticipante,
        E.Edad,
        E.CorreoElectronico,
        P.Nombre AS PartidoPolitico
    FROM Encuestas E
    INNER JOIN PartidosPoliticos P ON E.PartidoID = P.PartidoID;
END;