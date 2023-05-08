CREATE TABLE Producto (
    ID int IDENTITY(1,1) PRIMARY KEY,
    Tipo int not null ,
    Precio int not null,
    FechaCreacion DateTime,
);