CREATE DATABASE GrupoCOS

USE GrupoCOS

CREATE TABLE Usuarios (
    UsuarioId INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Correo NVARCHAR(100) UNIQUE,
    ContraseñaHash NVARCHAR(255),
    FechaRegistro DATETIME DEFAULT GETDATE()
);

CREATE TABLE Posts (
    PostId INT PRIMARY KEY IDENTITY,
    Titulo NVARCHAR(200),
    Contenido TEXT,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    UsuarioId INT,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId)
);

CREATE TABLE Comentarios (
    ComentarioId INT PRIMARY KEY IDENTITY,
    Contenido TEXT,
    FechaComentario DATETIME DEFAULT GETDATE(),
    UsuarioId INT,
    PostId INT,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId),
    FOREIGN KEY (PostId) REFERENCES Posts(PostId)
);

<!--Insert-->

-- Inserta usuarios
INSERT INTO Usuarios (Nombre, Correo, ContraseñaHash, FechaRegistro)
VALUES 
('Ana Pérez', 'ana@example.com', 'hashedpassword1', GETDATE()),
('Carlos Gómez', 'carlos@example.com', 'hashedpassword2', GETDATE()),
('Laura Ríos', 'laura@example.com', 'hashedpassword3', GETDATE());

-- Inserta posts (usando los IDs de los usuarios anteriores)
INSERT INTO Posts (Titulo, Contenido, FechaCreacion, UsuarioId)
VALUES 
('Primer post de Ana', 'Este es el contenido del primer post de Ana.', GETDATE(), 1),
('Reflexiones de Carlos', 'Carlos comparte sus pensamientos sobre .NET.', GETDATE(), 2),
('Guía de baile', 'Laura explica su rutina de baile favorita.', GETDATE(), 3),
('Más sobre .NET', 'Carlos continúa hablando sobre Entity Framework.', GETDATE(), 2);

-- Inserta comentarios (referenciando usuarios y posts)
INSERT INTO Comentarios (Contenido, FechaComentario, UsuarioId, PostId)
VALUES 
('Muy buen post, Ana!', GETDATE(), 2, 1),
('Gracias por compartir, Carlos.', GETDATE(), 3, 2),
('¡Qué interesante! No sabía eso de EF.', GETDATE(), 1, 4),
('Excelente rutina de baile.', GETDATE(), 1, 3);

SELECT * FROM Usuarios;
SELECT * FROM Comentarios;