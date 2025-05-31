Create Database DocHudson
Go

Use DocHudson
Go

Create Table Perfiles(
Id_Perfil int identity(1,1),
Descripcion Varchar(50)
Primary Key (Id_Perfil)
)
Go

Create Table BackupR(
Id_Backup Int Identity(1,1),
Fecha_Registro Date
Primary Key (Id_Backup)
)
Go

--Creacion de la tabla de Domicilio y Localidad y Provincia
Create Table Provincia(
Id_Provincia Int identity(1,1),
Provincia Varchar(100),
Primary Key (Id_Provincia)
)
Go

Create Table Localidad(
Id_Localidad Int identity(1,1),
Localidad Varchar(100),
Id_Provincia Int,
Primary Key (Id_Localidad),
Foreign Key (Id_Provincia) References Provincia(Id_Provincia)
)
Go

Create table Domicilio(
Id_Domicilio Int Identity(1,1),
Calle Varchar(100),
Numero Int,
Id_Localidad Int,
Primary Key (Id_Domicilio),
Foreign Key (Id_Localidad) References Localidad(Id_Localidad)
)
Go
------------------------------------------------------
Create Table Persona(
Id_Persona Int Identity(1,1),
Nombre Varchar(150),
Apellido Varchar(150),
DNI Varchar(50) Unique,
Fecha_Nacimiento Date,
Id_Domicilio Int,
Mail Varchar(150) Unique,
Telefono Varchar(50)
Primary Key (Id_Persona)
Foreign Key (Id_Domicilio) References Domicilio(Id_Domicilio)
)
Go

Create Table Cliente(
Id_Cliente Int identity (1,1),
Id_Persona Int,
Licencia Varchar(100) Unique,
Estado Bit,
Primary Key (Id_Cliente),
Foreign Key (Id_Persona) References Persona(Id_Persona)
)
Go


Create Table Usuarios(
Id_Usuario int identity (1,1),
Id_Perfil int,
Usuario Varchar(50) Unique,
Contraseña Varchar(50),
Id_Persona Int,
Estado Bit
Primary Key (Id_Usuario)
Foreign Key (Id_Perfil) References Perfiles(Id_Perfil),
Foreign Key (Id_Persona) References Persona(Id_Persona)
)
Go

--Creacion de la tabla Modelo y Marca para la normalizacion
Create Table Marca(
Id_Marca Int Identity(1,1),
Marca Varchar(100),
Primary Key (Id_Marca)
)
Go

Create Table Modelo( 
Id_Modelo Int Identity(1,1),
Id_Marca Int,
Modelo Varchar(80),
Consumo Decimal(11,1),
Puertas Int,
Asientos Int
Primary Key (Id_Modelo),
Foreign Key (Id_Marca) References Marca(Id_Marca)
)
Go
------------------------------------------------------
Create Table Autos(
Id_Auto Int Identity(1,1),
Matricula Varchar(11),
Kilometros Decimal(11,2),
Año Int,
Imagen Varchar(200) Default '',
Reservado bit DEFAULT '0',
Estado bit,
Id_Modelo Int,
Primary Key (Id_Auto),
Foreign Key (Id_Modelo) References Modelo(Id_Modelo)
)
Go

Create Table Tipo_Pago(
Id_Tipopago Int identity(1,1),
Descripcion Varchar(80),
Estado bit
Primary Key (Id_Tipopago)
)
Go

Create Table Pago(
Id_Pago Int Identity(1,1),
Id_Tipopago Int,
Total FLoat,
Fecha_Pago Date Default GetDate(),
Estado Bit default 1
Primary Key (Id_Pago)
Foreign Key (Id_Tipopago) References Tipo_Pago (Id_Tipopago)
)
Go

Create Table Reserva(
Id_Reserva Int Identity(1,1),
Id_Auto Int,
Id_Pago Int,
Id_Cliente Int,
Id_Usuario Int,
Fecha_Inicio Date,
Fecha_Fin Date,
Estado Bit
Primary Key (Id_Reserva),
Foreign Key (Id_Auto) References Autos(Id_Auto),
Foreign Key (Id_Pago) References Pago(Id_Pago),
Foreign Key (Id_Cliente) References Cliente(Id_Cliente),
Foreign Key (Id_Usuario) References Usuarios(Id_Usuario) --Referencia al Usuario
)
Go

CREATE TABLE Negocio(
Id_Negocio int primary key identity(1,1),
Nombre varchar(60),
Imagen Varchar(200) default ''
)
go
--Comienzo de los procedimientos--
-- Procedimientos para la tabla Perfiles
-- Procedimiento para insertar perfiles con manejo de errores

CREATE OR ALTER PROCEDURE InsertarPerfil
    @Descripcion VARCHAR(50),
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET @Resultado = 0;
    SET @Mensaje = '';

    IF EXISTS (SELECT 1 FROM Perfiles WHERE Descripcion = @Descripcion)
    BEGIN
        SET @Mensaje = 'El perfil ya existe';
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO Perfiles (Descripcion) VALUES (@Descripcion);
        COMMIT;
        SET @Resultado = 1;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH;
END;
GO

-- Procedimiento para actualizar perfiles con seguridad
CREATE OR ALTER PROCEDURE ActualizarPerfil
    @Id_Perfil INT,
    @Descripcion VARCHAR(50),
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET @Resultado = 0;
    SET @Mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM Perfiles WHERE Id_Perfil = @Id_Perfil)
    BEGIN
        SET @Mensaje = 'El perfil no existe';
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE Perfiles SET Descripcion = @Descripcion WHERE Id_Perfil = @Id_Perfil;
        COMMIT;
        SET @Resultado = 1;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH;
END;
GO

-- Procedimiento para eliminar perfiles con validaci�n
CREATE OR ALTER PROCEDURE EliminarPerfil
    @Id_Perfil INT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET @Resultado = 0;
    SET @Mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM Perfiles WHERE Id_Perfil = @Id_Perfil)
    BEGIN
        SET @Mensaje = 'El perfil no existe';
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        DELETE FROM Perfiles WHERE Id_Perfil = @Id_Perfil;
        COMMIT;
        SET @Resultado = 1;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH;
END;
GO

--Procedimiento para listar perfiles
CREATE OR ALTER PROCEDURE ListarPerfiles
AS
BEGIN
    SELECT p.Id_Perfil, p.Descripcion
    FROM Perfiles p
END;
GO

--Procedimientos de la tabla persona
CREATE OR ALTER PROCEDURE InsertarPersona
    @Nombre Varchar(150),
    @Apellido Varchar(150),
    @DNI Varchar(50),
    @Fecha_Nacimiento Date,
    @Id_Domicilio Int,
    @Mail Varchar(150),
    @Telefono Varchar(50),
    @IdResultado Int OUTPUT,
    @Mensaje Varchar(500) OUTPUT
AS
BEGIN
    SET @IdResultado = 0;
    SET @Mensaje = '';

    -- Buscar si ya existe por DNI o Mail
    DECLARE @IdExistente INT;

    SELECT @IdExistente = Id_Persona
    FROM Persona
    WHERE DNI = @DNI OR Mail = @Mail;

    IF @IdExistente IS NOT NULL
    BEGIN
        SET @IdResultado = @IdExistente;
        RETURN;
    END

    -- Si no existe, se inserta
    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO Persona (Nombre, Apellido, DNI, Fecha_Nacimiento, Id_Domicilio, Mail, Telefono)
        VALUES (@Nombre, @Apellido, @DNI, @Fecha_Nacimiento, @Id_Domicilio, @Mail, @Telefono);

        SET @IdResultado = SCOPE_IDENTITY();
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE ActualizarPersona(
    @Id_Persona INT,
    @Nombre VARCHAR(150),
    @Apellido VARCHAR(150),
    @DNI VARCHAR(50),
    @Fecha_Nacimiento DATE,
    @Id_Domicilio INT,
    @Mail VARCHAR(150),
    @Telefono VARCHAR(50),
    @IdResultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @IdResultado = 0;
    SET @Mensaje = '';
		 -- Validar que el mail no esta en otra persona
            IF EXISTS (SELECT 1 FROM Persona WHERE Mail = @Mail AND Id_Persona <> @Id_Persona)
            BEGIN
                SET @Mensaje = 'El correo electronico ya esta en uso por otra persona.';
                RETURN;
            END

    IF NOT EXISTS (
        SELECT 1 FROM Persona 
        WHERE (DNI = @DNI OR Mail = @Mail)
        AND Id_Persona <> @Id_Persona
    )
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE Persona 
            SET Nombre = @Nombre,
                Apellido = @Apellido,
                DNI = @DNI,
                Fecha_Nacimiento = @Fecha_Nacimiento,
                Id_Domicilio = @Id_Domicilio,
                Mail = @Mail,
                Telefono = @Telefono
            WHERE Id_Persona = @Id_Persona;

            SET @IdResultado = @Id_Persona;
            COMMIT;
        END TRY
        BEGIN CATCH
            ROLLBACK;
            SET @Mensaje = ERROR_MESSAGE();
        END CATCH
    END
    ELSE
    BEGIN
        SET @Mensaje = 'Ya existe otra persona con ese numero de DNI o correo.';
    END
END
GO

--Procedimiento para listar Personas
CREATE OR ALTER PROCEDURE ListarPersonas
AS 
BEGIN
	SELECT p.Id_Persona, p.DNI, p.Nombre, p.Apellido, p.Mail, p.Telefono,
           p.Id_Domicilio, p.Fecha_Nacimiento,
           d.Calle, d.Numero, d.Id_Localidad,
           l.Localidad, l.Id_Provincia,
           pr.Provincia
           FROM Persona p
           INNER JOIN Domicilio d ON d.Id_Domicilio = p.Id_Domicilio
           INNER JOIN Localidad l ON l.Id_Localidad = d.Id_Localidad
           INNER JOIN Provincia pr ON pr.Id_Provincia = l.Id_Provincia
END;
GO

-- Procedimientos para la tabla Usuarios
CREATE OR ALTER PROCEDURE InsertarUsuario
	--Datos del Usuario--
	@Id_Persona Int,
    @Usuario VARCHAR(50),
    @Contraseña VARCHAR(50),
    @Id_Perfil INT,
    @Estado BIT,
    @IdUsuarioResultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET @IdUsuarioResultado = 0;
    SET @Mensaje = '';

    BEGIN TRANSACTION;
    BEGIN TRY
        -- Validar que no exista el usuario ya registrado
        IF EXISTS (SELECT 1 FROM Usuarios WHERE Usuario = @Usuario)
        BEGIN
            SET @Mensaje = 'Ese nombre de usuario ya existe.';
            ROLLBACK;
            RETURN;
        END

        -- Verificamos que la persona no esta ya registrada como usuario
        IF EXISTS (SELECT 1 FROM Usuarios WHERE Id_Persona = @Id_Persona)
        BEGIN
            SET @Mensaje = 'La persona ya esta registrada como usuario.';
            ROLLBACK;
            RETURN;
        END
        -- Insertar usuario vinculado a persona
        INSERT INTO Usuarios (Id_Perfil, Usuario, Contraseña, Id_Persona, Estado)
        VALUES (@Id_Perfil, @Usuario, @Contraseña, @Id_Persona, @Estado);

        SET @IdUsuarioResultado = SCOPE_IDENTITY();
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE ActualizarUsuario
    @Id_Usuario INT,
    @Id_Perfil INT,
    @Usuario VARCHAR(50),
    @Contraseña VARCHAR(50),
    @Estado BIT,
	@Id_Persona Int,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET @Resultado = 0;
    SET @Mensaje = '';

    IF EXISTS (SELECT 1 FROM Usuarios WHERE Id_Usuario = @Id_Usuario)
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY

            -- Validar que no exista otro usuario con el mismo nombre de usuario
            IF EXISTS (SELECT 1 FROM Usuarios WHERE Usuario = @Usuario AND Id_Usuario <> @Id_Usuario)
            BEGIN
                SET @Mensaje = 'Ese nombre de usuario ya esta en uso por otro.';
                ROLLBACK;
                RETURN;
            END
            -- Actualizar datos en tabla Usuarios
            UPDATE Usuarios
            SET Id_Perfil = @Id_Perfil,
				Id_Persona = @Id_Persona,
                Usuario = @Usuario,
                Contraseña = @Contraseña,
                Estado = @Estado
            WHERE Id_Usuario = @Id_Usuario;

            COMMIT;
            SET @Resultado = 1;
        END TRY
        BEGIN CATCH
            ROLLBACK;
            SET @Mensaje = ERROR_MESSAGE();
        END CATCH;
    END
    ELSE
    BEGIN
        SET @Mensaje = 'El usuario especificado no existe.';
    END
END;
GO

CREATE OR ALTER PROCEDURE EliminarUsuario
    @Id_Usuario INT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET @Resultado = 0;
    SET @Mensaje = '';

    IF EXISTS (SELECT 1 FROM Usuarios WHERE Id_Usuario = @Id_Usuario)
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE Usuarios SET Estado = 0 WHERE Id_Usuario = @Id_Usuario;
            COMMIT;
            SET @Resultado = 1;
        END TRY
        BEGIN CATCH
            ROLLBACK;
            SET @Mensaje = ERROR_MESSAGE();
        END CATCH;
    END
    ELSE
    BEGIN
        SET @Mensaje = 'El usuario especificado no existe';
    END
END;
GO

-- Procedimiento para listar usuarios.
CREATE OR AlTER PROCEDURE ListarUsuarios
AS
BEGIN
	SELECT u.Id_Usuario, u.Usuario, u.Contraseña, per.DNI, u.Estado, p.Id_Perfil, p.Descripcion
	FROM Usuarios u
	INNER JOIN Persona per ON per.Id_Persona = u.Id_Persona
	INNER JOIN Perfiles p ON p.Id_Perfil = u.Id_Perfil
END;
GO
	
-- Procedimientos para la tabla Cliente
CREATE OR ALTER PROCEDURE InsertarCliente
	--Datos de la Persona--
	@Id_Persona Int,
	--Datos del Cliente--
	@Licencia Varchar(100),
    @Estado BIT,
	@IdUsuarioResultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN

    SET @IdUsuarioResultado = 0;
    SET @Mensaje = '';

    BEGIN TRANSACTION;
    BEGIN TRY

        -- Verificamos que la persona no esta ya registrada como cliente
        IF EXISTS (SELECT 1 FROM Cliente WHERE Id_Persona = @Id_Persona)
        BEGIN
            SET @Mensaje = 'La persona ya esta registrada como cliente.';
            ROLLBACK;
            RETURN;
        END
		        -- Verificamos que la persona no esta ya registrada como usuario
        IF EXISTS (SELECT 1 FROM Cliente WHERE Licencia = @Licencia)
        BEGIN
            SET @Mensaje = 'Ya existe un cliente con esa licencia';
            ROLLBACK;
            RETURN;
        END

        -- Insertar cliente vinculado a persona
        INSERT INTO Cliente (Id_Persona,Licencia, Estado)
        VALUES (@Id_Persona,@Licencia ,@Estado);

        SET @IdUsuarioResultado = SCOPE_IDENTITY();
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
GO
	
-- Procedimientos para la tabla Cliente
CREATE OR ALTER PROCEDURE ActualizarCliente
    @Id_Cliente INT,
	--Datos de la Persona--
	@Id_Persona Int,
	--Datos del Cliente--
	@Licencia Varchar(100),
    @Estado BIT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET @Resultado = 0;
    SET @Mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM Cliente WHERE Id_Cliente = @Id_Cliente)
    BEGIN
        SET @Mensaje = 'El cliente no existe';
        RETURN;
    END
	    IF EXISTS (SELECT 1 FROM Cliente WHERE Licencia = @Licencia and Id_Cliente <> @Id_Cliente)
    BEGIN
        SET @Mensaje = 'Ya existe un cliente con esa licencia';
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
      
        -- Actualizar cliente (solo campos propios)
        UPDATE Cliente
        SET Estado = @Estado,
		Licencia = @Licencia,
		Id_Persona = @Id_Persona
        WHERE Id_Cliente = @Id_Cliente;

        COMMIT;
        SET @Resultado = 1;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE EliminarCliente
    @Id_Cliente INT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET @Resultado = 0;
    SET @Mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM Cliente WHERE Id_Cliente = @Id_Cliente)
    BEGIN
        SET @Mensaje = 'El cliente no existe';
        RETURN;
    END;

    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE Cliente SET Estado = 0 WHERE Id_Cliente = @Id_Cliente;
        
        COMMIT;
        SET @Resultado = 1;
    END TRY
    BEGIN CATCH
        SET @Mensaje = 'No se pudo eliminar el cliente';
        ROLLBACK;
    END CATCH;
END;
GO

CREATE OR ALTER PROCEDURE BuscarClientes
  @Texto VARCHAR(200)
AS
BEGIN
  SET NOCOUNT ON;

  SELECT 
    c.Id_Cliente,
	c.Licencia,
	p.Id_Persona,
    p.DNI,
    p.Nombre,
    p.Apellido,
    p.Mail,
    p.Telefono,
    p.Fecha_Nacimiento,
	p.Id_Domicilio AS Id_Domicilio, 
    d.Calle,
    d.Numero,
    l.Id_Localidad,
    l.Localidad AS localidad,
    pr.Id_Provincia,
    pr.Provincia AS provincia,
    c.Estado
  FROM Cliente c
  INNER JOIN Persona p      ON p.Id_Persona  = c.Id_Persona
  INNER JOIN Domicilio d    ON d.Id_Domicilio = p.Id_Domicilio
  INNER JOIN Localidad l    ON l.Id_Localidad = d.Id_Localidad
  INNER JOIN Provincia pr   ON pr.Id_Provincia= l.Id_Provincia
  WHERE  
    p.Nombre   LIKE '%' + @Texto + '%'
    OR p.Apellido LIKE '%' + @Texto + '%'
    OR p.DNI      LIKE '%' + @Texto + '%'
    OR p.Mail      LIKE '%' + @Texto + '%';
END;
GO

-- Procedimiento para listar clientes
CREATE OR ALTER PROCEDURE ListarClientes
AS
BEGIN
    Select Id_Cliente, Licencia, pe.DNI, pe.Id_Persona, pe.Nombre, pe.Apellido, p.Id_Provincia, p.Provincia, l.Id_Localidad,l.Localidad, d.Calle,d.Id_Domicilio, d.Numero, pe.Fecha_Nacimiento, pe.Mail, pe.Telefono, Estado from Cliente c
    inner join Persona pe on pe.Id_Persona = c.Id_Persona
    inner join Domicilio d on d.Id_Domicilio = pe.Id_Domicilio
    inner join Localidad l on d.Id_Localidad = l.Id_Localidad
    inner join Provincia p on l.Id_Provincia = p.Id_Provincia
END;
GO
	
-- Procedimientos para la tabla Autos
CREATE OR ALTER PROCEDURE InsertarAuto
    @Estado bit,
    @Matricula VARCHAR(11),
    @Kilometros DECIMAL(11,2),
    @Año INT,
	@Imagen VARCHAR(200),
	@Id_Modelo int,
	@IdAutoResultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET @IdAutoResultado = 0;
    SET @Mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM Autos WHERE Matricula = @Matricula)
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO Autos (Estado, Id_Modelo, Matricula, Kilometros, Año, Imagen)
            VALUES (@Estado, @Id_Modelo, @Matricula, @Kilometros, @Año, @Imagen);
            COMMIT;
            SET @IdAutoResultado = SCOPE_IDENTITY();
        END TRY
        BEGIN CATCH
            ROLLBACK;
            SET @Mensaje = ERROR_MESSAGE();
        END CATCH;
    END
    ELSE
    BEGIN
        SET @Mensaje = 'Ya existe un auto con ese numero de matricula';
    END
END;
GO

CREATE OR ALTER PROCEDURE ActualizarAuto
    @Id_Auto INT,
    @Estado VARCHAR(20),
    @Matricula VARCHAR(11),
    @Kilometros DECIMAL(11,2),
    @Año INT,
	@Imagen VARCHAR(200),
	@Id_Modelo Int,
	@Reservado bit,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET @Resultado = 0;
    SET @Mensaje = '';

	IF EXISTS (SELECT 1 FROM Autos WHERE Matricula = @Matricula and Id_Auto != @Id_Auto)
    BEGIN
        SET @Mensaje = 'El auto ya existe';
        RETURN;
    END;

    IF NOT EXISTS (SELECT 1 FROM Autos WHERE Id_Auto = @Id_Auto)
    BEGIN
        SET @Mensaje = 'El auto no existe';
        RETURN;
    END;

	IF EXISTS (SELECT 1 FROM Reserva r WHERE r.Id_Auto = @Id_Auto and r.Estado = 1)
    BEGIN
        SET @Mensaje = 'El auto esta reservado';
        RETURN;
    END;

    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE Autos
        SET Estado = @Estado, 
        Id_Modelo = @Id_Modelo, 
        Matricula = @Matricula,
            Kilometros = @Kilometros, 
            Año = @Año, 
			Imagen = @Imagen, 
            Reservado = @Reservado
        WHERE Id_Auto = @Id_Auto;
        
        COMMIT;
        SET @Resultado = 1;
    END TRY
    BEGIN CATCH
        SET @Mensaje = 'No se pudo actualizar el auto';
        ROLLBACK;
    END CATCH;
END;
GO

CREATE OR ALTER PROCEDURE EliminarAuto
    @Id_Auto INT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET @Resultado = 0;
    SET @Mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM Autos WHERE Id_Auto = @Id_Auto)
    BEGIN
        SET @Mensaje = 'El auto no existe';
        RETURN;
    END;

	   IF EXISTS (SELECT 1 FROM Reserva r WHERE r.Id_Auto = @Id_Auto and r.Estado = 1)
    BEGIN
        SET @Mensaje = 'El auto esta reservado';
        RETURN;
    END;

    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE Autos SET Estado = 0 WHERE Id_Auto = @Id_Auto;
        
        COMMIT;
        SET @Resultado = 1;
    END TRY
    BEGIN CATCH
        SET @Mensaje = 'No se pudo eliminar el auto';
        ROLLBACK;
    END CATCH;
END;
GO

CREATE OR ALTER PROCEDURE BuscarAutos
  @Texto VARCHAR(100)
AS
BEGIN
  SET NOCOUNT ON;

  SELECT
    a.Id_Auto,
    a.Matricula,
    a.Kilometros,
    a.Año,
    a.Imagen,
    a.Reservado,
    a.Estado,
    a.Id_Modelo,
    m.Modelo   AS NombreModelo,
    m.Consumo,
    m.Puertas,
    m.Asientos,
    m.Id_Marca,
    ma.Marca   AS NombreMarca
  FROM Autos a
  INNER JOIN Modelo m ON m.Id_Modelo = a.Id_Modelo
  INNER JOIN Marca  ma ON ma.Id_Marca   = m.Id_Marca
  WHERE
    a.Matricula LIKE '%' + @Texto + '%'
    OR m.Modelo   LIKE '%' + @Texto + '%'
    OR ma.Marca   LIKE '%' + @Texto + '%';
END;
GO

CREATE OR ALTER PROCEDURE ListarAutosDisponibles
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        a.Id_Auto,
        a.Matricula,
        a.Kilometros,
        a.Año,
        a.Imagen,
        a.Reservado,
        a.Estado,
        a.Id_Modelo,
        m.Modelo       AS NombreModelo,
        m.Consumo,
        m.Puertas,
        m.Asientos,
        m.Id_Marca,
        ma.Marca       AS NombreMarca
    FROM Autos a
    INNER JOIN Modelo m ON m.Id_Modelo = a.Id_Modelo
    INNER JOIN Marca  ma ON ma.Id_Marca   = m.Id_Marca
    WHERE a.Reservado = 'False'
    ORDER BY a.Id_Auto;
END;
GO

-- Procedimientos CRUD para Tipo_Pago con Transacciones y Validaciones
CREATE OR ALTER PROCEDURE InsertarTipoPago
    @Descripcion VARCHAR(80),
	@Estado bit,
	@IdResultado Int output,
	@Mensaje Varchar(500) output
AS
BEGIN
	Set @IdResultado = 0;
	Set @Mensaje = '';
    IF EXISTS (SELECT 1 FROM Tipo_Pago WHERE Descripcion = @Descripcion)
    BEGIN
        Set @Mensaje ='El tipo de pago ya existe.';
        RETURN;
    END
    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO Tipo_Pago (Descripcion,Estado)
        VALUES (@Descripcion,@Estado);
        COMMIT TRANSACTION;
		SET @IdResultado = SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
		SET @Mensaje = ERROR_MESSAGE();
        THROW;
    END CATCH;
END
GO

CREATE OR ALTER PROCEDURE ActualizarTipoPago
    @Id_Tipopago INT,
    @Descripcion VARCHAR(80),
	@Estado bit,
	@Resultado bit output,
	@Mensaje Varchar(500) output
AS
BEGIN
	Set @Resultado = 0
	Set @Mensaje = ''

    IF NOT EXISTS (SELECT 1 FROM Tipo_Pago WHERE Id_Tipopago = @Id_Tipopago)
    BEGIN
		Set @Mensaje = 'El tipo de pago no existe.'
        RETURN;
    END
	    IF EXISTS (SELECT 1 FROM Tipo_Pago WHERE Descripcion = @Descripcion)
    BEGIN
        Set @Mensaje ='El tipo de pago ya existe.';
        RETURN;
    END
	    IF EXISTS (
		SELECT 1 FROM Tipo_Pago tp
		inner join Pago p on tp.Id_Tipopago = p.Id_Tipopago
		WHERE tp.Id_Tipopago = @Id_Tipopago)
    BEGIN
        Set @Mensaje ='El tipo de pago existe en una reserva.';
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE Tipo_Pago
        SET Descripcion = @Descripcion, Estado = @Estado
        WHERE Id_Tipopago = @Id_Tipopago;
        COMMIT TRANSACTION;
		Set @Resultado = 1
		
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
		Set @Mensaje = ERROR_MESSAGE();
        THROW;
    END CATCH;
END
GO

CREATE OR ALTER PROCEDURE EliminarTipoPago
    @Id_Tipopago INT,
	@Resultado bit output,
	@Mensaje Varchar(500) output
AS
BEGIN
	Set @Resultado = 0;
	Set @Mensaje = ''

    IF NOT EXISTS (SELECT 1 FROM Tipo_Pago WHERE Id_Tipopago = @Id_Tipopago)
    BEGIN
		Set @Mensaje = 'El tipo de pago no existe';
        RETURN;
    END
		    IF EXISTS (
		SELECT 1 FROM Tipo_Pago tp
		inner join Pago p on tp.Id_Tipopago = p.Id_Tipopago
		WHERE tp.Id_Tipopago = @Id_Tipopago)
    BEGIN
        Set @Mensaje ='El tipo de pago existe en una reserva.';
        RETURN;
    END
    BEGIN TRANSACTION;
    BEGIN TRY
        Update Tipo_Pago 
		Set Estado = 0  
		WHERE Id_Tipopago = @Id_Tipopago;
        COMMIT TRANSACTION;
		Set @Resultado = 1
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
		Set @Mensaje = ERROR_MESSAGE();
        THROW;
    END CATCH;
END
GO

-- Procedimiento para listar tipo pagos
CREATE OR ALTER PROCEDURE ListarTipoPagos
AS
BEGIN
	SELECT tp.Id_Tipopago, tp.Descripcion, tp.Estado
	FROM Tipo_Pago tp
END;
GO
	
-- Procedimientos CRUD para Pago con Transacciones
CREATE OR ALTER PROCEDURE InsertarPago
    @Id_Tipopago INT,
    @Total FLOAT,
    @Fecha_Pago DATE,
    @Estado BIT,
	@Resultado int output,
	@Mensaje varchar(500) output
AS
BEGIN
	Set @Resultado = 0
	Set @Mensaje = ''

    IF @Total <= 0
    BEGIN
        Set @Mensaje = 'El total debe ser mayor a cero.';
        RETURN;
    END
    IF NOT EXISTS (SELECT 1 FROM Tipo_Pago WHERE Id_Tipopago = @Id_Tipopago)
    BEGIN
        Set @Mensaje ='El tipo de pago no existe.';
        RETURN;
    END
    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO Pago (Id_Tipopago, Total, Fecha_Pago, Estado)
        VALUES (@Id_Tipopago, @Total, @Fecha_Pago, @Estado);
		Set @Resultado = SCOPE_IDENTITY();
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
		Set @Mensaje = ERROR_MESSAGE();
        THROW;
    END CATCH;
END
GO

CREATE OR ALTER PROCEDURE ActualizarPago
    @Id_Pago INT,
    @Id_Tipopago INT,
    @Total FLOAT,
    @Fecha_Pago DATE,
    @Estado BIT,
	@Resultado int output,
	@Mensaje varchar (500) output
AS
BEGIN
	Set @Resultado = 0;
	Set @Mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM Pago WHERE Id_Pago = @Id_Pago)
    BEGIN
        Set @Mensaje = 'El pago no existe.';
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE Pago
        SET Id_Tipopago = @Id_Tipopago, Total = @Total, Fecha_Pago = @Fecha_Pago, Estado = @Estado
        WHERE Id_Pago = @Id_Pago;
        COMMIT TRANSACTION;
		Set @Resultado = 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
		Set @Mensaje = ERROR_MESSAGE();
        THROW;
    END CATCH;
END
GO

CREATE OR ALTER PROCEDURE EliminarPago
    @Id_Pago INT,
	@Resultado int output,
	@Mensaje varchar(500) output
AS
BEGIN
	Set @Resultado = 0;
	Set @Mensaje = ''

    IF NOT EXISTS (SELECT 1 FROM Pago WHERE Id_Pago = @Id_Pago)
    BEGIN
        Set @Mensaje = 'El pago no existe.';
        RETURN;
    END
    BEGIN TRANSACTION;
    BEGIN TRY
        Update Pago Set Estado = 0 WHERE Id_Pago = @Id_Pago;
        COMMIT TRANSACTION;
		Set @Resultado = 1
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
		Set @Mensaje = ERROR_MESSAGE();
        THROW;
    END CATCH;
END
GO

--Procedimiento para listar pagos
CREATE OR ALTER PROCEDURE ListarPagos
AS
BEGIN
    SELECT p.Id_Pago, p.Id_Tipopago, tp.Descripcion, p.Total, p.Fecha_Pago, p.Estado
    FROM Pago p
    Inner join Tipo_Pago tp on tp.Id_Tipopago = p.Id_Tipopago
END;
GO
	
-- Procedimientos CRUD para Reserva con Transacciones
CREATE OR ALTER PROCEDURE InsertarReserva
    @Id_Auto INT,
    @Id_Pago INT,
    @Id_Cliente INT,
	@Id_Usuario INT,
    @Fecha_Inicio DATE,
    @Fecha_Fin DATE,
    @Estado BIT,
	@Resultado int output,
	@Mensaje varchar(500) output
AS
BEGIN
	Set @Resultado = 0;
	Set @Mensaje = ''

    IF @Fecha_Fin < @Fecha_Inicio
    BEGIN
        Set @Mensaje ='La fecha de fin no puede ser anterior a la fecha de inicio.';
        RETURN;
    END
    IF NOT EXISTS (SELECT 1 FROM Autos WHERE Id_Auto = @Id_Auto)
    BEGIN
        Set @Mensaje ='El auto no existe.';
        RETURN;
    END
    IF NOT EXISTS (SELECT 1 FROM Pago WHERE Id_Pago = @Id_Pago)
    BEGIN
        Set @Mensaje = 'El pago no existe.';
        RETURN;
    END
    IF NOT EXISTS (SELECT 1 FROM Cliente WHERE Id_Cliente = @Id_Cliente)
    BEGIN
        Set @Mensaje ='El cliente no existe.';
        RETURN;
    END
    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO Reserva (Id_Auto, Id_Pago, Id_Cliente,Id_Usuario, Fecha_Inicio, Fecha_Fin, Estado)
        VALUES (@Id_Auto, @Id_Pago, @Id_Cliente,@Id_Usuario, @Fecha_Inicio, @Fecha_Fin, @Estado);
        COMMIT TRANSACTION;
		Set @Resultado = SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
		Set @Mensaje = ERROR_MESSAGE();
        THROW;
    END CATCH;
END
GO

CREATE OR ALTER PROCEDURE ModificarReserva
    @Id_Reserva INT,
    @Id_Auto INT,
    @Id_Pago INT,
    @Id_Cliente INT,
    @Fecha_Inicio DATE,
    @Fecha_Fin DATE,
    @Estado BIT,
	@Resultado bit output,
	@Mensaje varchar(500) output

AS
BEGIN
	Set @Resultado = 0;
	Set @Mensaje = ''

    IF NOT EXISTS (SELECT 1 FROM Reserva WHERE Id_Reserva = @Id_Reserva)
    BEGIN
        Set @Mensaje ='La reserva no existe.';
        RETURN;
    END    
	IF NOT EXISTS (SELECT 1 FROM Pago WHERE Id_Pago = @Id_Pago)
    BEGIN
        Set @Mensaje = 'El pago no existe.';
        RETURN;
    END
    IF NOT EXISTS (SELECT 1 FROM Cliente WHERE Id_Cliente = @Id_Cliente)
    BEGIN
        Set @Mensaje ='El cliente no existe.';
        RETURN;
    END
	IF NOT EXISTS (SELECT 1 FROM Autos WHERE Id_Auto = @Id_Auto)
    BEGIN
        SET @Mensaje = 'El auto no existe.';
        RETURN;
    END
    IF @Fecha_Fin < @Fecha_Inicio
    BEGIN
        Set @Mensaje ='La fecha de fin no puede ser anterior a la fecha de inicio.';
        RETURN;
    END
    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE Reserva
        SET Id_Auto = @Id_Auto, Id_Pago = @Id_Pago, Id_Cliente = @Id_Cliente, Fecha_Inicio = @Fecha_Inicio, Fecha_Fin = @Fecha_Fin, Estado = @Estado
        WHERE Id_Reserva = @Id_Reserva;
        COMMIT TRANSACTION;
		Set @Resultado = 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
		Set @Mensaje = ERROR_MESSAGE();
        THROW;
    END CATCH;
END
GO

CREATE OR ALTER PROCEDURE BuscarReserva
  @Id_Reserva INT
AS
BEGIN
  SET NOCOUNT ON;
  SELECT
    r.Id_Reserva,
    r.Fecha_Inicio,
    r.Fecha_Fin,

    -- Auto
    a.Id_Auto,
    a.Matricula,
    a.Kilometros,
    a.Año,
    a.Imagen,
    a.Reservado,
    a.Estado       AS EstadoAuto,
    m.Id_Modelo,
    m.Modelo       AS NombreModelo,
    m.Consumo,
    m.Puertas,
    m.Asientos,
    ma.Id_Marca,
    ma.Marca       AS NombreMarca,

    -- Cliente / Persona / Domicilio / Localidad / Provincia
    c.Id_Cliente,
    c.Licencia,
    c.Estado       AS EstadoCliente,
    p.Id_Persona,
    p.DNI,
    p.Nombre      AS NombrePersona,
    p.Apellido,
    p.Fecha_Nacimiento,
    p.Mail,
    p.Telefono,
    d.Id_Domicilio,
    d.Calle,
    d.Numero,
    l.Id_Localidad,
    l.Localidad,
    pr.Id_Provincia,
    pr.Provincia,

    -- Pago
    pay.Id_Pago,
    pay.Total,
    pay.Fecha_Pago,
    pay.Estado   AS EstadoPago

  FROM Reserva r
  INNER JOIN Autos     a   ON a.Id_Auto      = r.Id_Auto
  INNER JOIN Modelo    m   ON m.Id_Modelo    = a.Id_Modelo
  INNER JOIN Marca     ma  ON ma.Id_Marca    = m.Id_Marca

  INNER JOIN Cliente   c   ON c.Id_Cliente   = r.Id_Cliente
  INNER JOIN Persona   p   ON p.Id_Persona   = c.Id_Persona
  INNER JOIN Domicilio d   ON d.Id_Domicilio = p.Id_Domicilio
  INNER JOIN Localidad l   ON l.Id_Localidad = d.Id_Localidad
  INNER JOIN Provincia pr  ON pr.Id_Provincia= l.Id_Provincia

  INNER JOIN Pago      pay ON pay.Id_Pago     = r.Id_Pago

  WHERE r.Id_Reserva = @Id_Reserva;
END;
GO

CREATE OR ALTER PROCEDURE LiberarReserva
    @Id_Reserva INT,
	@Resultado int output,
	@Mensaje varchar(500) output
AS
BEGIN
    SET @Resultado = 0;
    SET @Mensaje   = '';

    -- Validar que exista la reserva
    IF NOT EXISTS (SELECT 1 FROM Reserva WHERE Id_Reserva = @Id_Reserva)
    BEGIN
        SET @Mensaje = 'La reserva no existe.';
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        -- 1) Marcar la reserva como inactiva
        UPDATE Reserva
           SET Estado = 0
         WHERE Id_Reserva = @Id_Reserva;

        COMMIT TRANSACTION;
        SET @Resultado = 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @Mensaje = ERROR_MESSAGE();
        THROW;
    END CATCH;
END;
GO

--Procedimiento para listar reservas
CREATE OR ALTER PROCEDURE ListarReservas
AS 
BEGIN
	SELECT r.Id_Reserva, r.Id_Auto, r.Id_Pago, r.Id_Cliente, r.Fecha_Inicio, r.Fecha_Fin, r.Estado
    FROM Reserva r
END;
GO

--//true=ocupado, false=disponible
CREATE OR ALTER PROCEDURE CambiarEstadoAuto
    @Id_Auto    INT,
    @Reservado  BIT,
    @Resultado  BIT OUTPUT,
    @Mensaje    VARCHAR(500) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Resultado = 0;
    SET @Mensaje   = '';

    IF NOT EXISTS (SELECT 1 FROM Autos WHERE Id_Auto = @Id_Auto)
    BEGIN
        SET @Mensaje = 'Auto no encontrado.';
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE Autos
           SET Reservado = @Reservado
         WHERE Id_Auto = @Id_Auto;

        COMMIT;
        SET @Resultado = 1;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH;
END
GO

	CREATE OR ALTER   PROCEDURE EditarDomicilio(
    @Id_Domicilio INT,
    @Calle VARCHAR(100),
    @Numero INT,
    @Id_Localidad INT,
	@Resultado Int output,
    @Mensaje VARCHAR(500) OUTPUT
)AS
BEGIN
    SET @Mensaje = '';
	SET @Resultado = 0;

    BEGIN TRANSACTION;
    BEGIN TRY
        -- Validamos que el domicilio exista
        IF NOT EXISTS (SELECT 1 FROM Domicilio WHERE Id_Domicilio = @Id_Domicilio)
        BEGIN
            SET @Mensaje = 'El domicilio especificado no existe.';
            ROLLBACK;
            RETURN;
        END

        -- Validamos que la localidad exista
        IF NOT EXISTS (SELECT 1 FROM Localidad WHERE Id_Localidad = @Id_Localidad)
        BEGIN
            SET @Mensaje = 'La localidad especificada no existe.';
            ROLLBACK;
            RETURN;
        END

        -- Actualizamos el domicilio
        UPDATE Domicilio
        SET Calle = @Calle,
            Numero = @Numero,
            Id_Localidad = @Id_Localidad
        WHERE Id_Domicilio = @Id_Domicilio;
		SET @Resultado = @Id_Domicilio;
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
GO

CREATE OR ALTER   PROCEDURE InsertarDomicilio(
    @Calle VARCHAR(100),
    @Numero INT,
    @Id_Localidad INT,
    @IdResultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)AS
BEGIN
    SET @IdResultado = 0;
    SET @Mensaje = '';

    BEGIN TRANSACTION;
    BEGIN TRY
        -- Validamos que la localidad exista
        IF NOT EXISTS (SELECT 1 FROM Localidad WHERE Id_Localidad = @Id_Localidad)
        BEGIN
            SET @Mensaje = 'La localidad especificada no existe.';
            ROLLBACK;
            RETURN;
        END

        -- Insertamos el domicilio
        INSERT INTO Domicilio (Calle, Numero, Id_Localidad)
        VALUES (@Calle, @Numero, @Id_Localidad);

        SET @IdResultado = SCOPE_IDENTITY();
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
GO

--Inserciones basicas para el sistema

CREATE OR ALTER PROCEDURE AgregarProvinciasArgentinas
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Provincias TABLE (Provincia VARCHAR(50));

    INSERT INTO @Provincias (Provincia)
    VALUES
        ('Buenos Aires'),
        ('Catamarca'),
        ('Chaco'),
        ('Chubut'),
        ('Cordoba'),
        ('Corrientes'),
        ('Entre Rios'),
        ('Formosa'),
        ('Jujuy'),
        ('La Pampa'),
        ('La Rioja'),
        ('Mendoza'),
        ('Misiones'),
        ('Neuquen'),
        ('Rio Negro'),
        ('Salta'),
        ('San Juan'),
        ('San Luis'),
        ('Santa Cruz'),
        ('Santa Fe'),
        ('Santiago del Estero'),
        ('Tierra del Fuego'),
        ('Tucuman'),
        ('Ciudad Autonoma de Buenos Aires');

    INSERT INTO Provincia (Provincia)
    SELECT p.Provincia
    FROM @Provincias p
    WHERE NOT EXISTS (
        SELECT 1 FROM Provincia WHERE p.Provincia = Provincia
    );
END;
Go

EXEC AgregarProvinciasArgentinas;
INSERT INTO Localidad(Id_Provincia, Localidad) VALUES
	('1', 'VILLA SANTOS TESEI '),	('1', 'HURLINGHAM '),	('1', 'WILLIAM C. MORRIS '),
	('2', 'LA FALDA DE SAN ANTONIO '),	('2', 'EL HUECO '),	('2', 'LA TERCENA '),
	('3', 'EL QUEBRACHO BALEADO '),	('3', 'SAN LORENZO '),	('3', 'RESISTENCIA'),
	('4', 'BARRIO CALETA CORDOVA '),	('4', 'BARRIO CIUDADELA '),	('4', 'COMODORO RIVADAVIA '),
	('5', 'BELL VILLE '),	('5', 'COLONIA COMPIANI '),	('5', 'CORDOBA'),
	('6', 'BELLA VISTA'),	('6', 'CORRIENTES'),	('6', 'GOYA'),
	('7', 'MOLINO PUBLICO '),	('7', 'LA SELVA '),	('7', 'ESTAQUITAS '),
	('8', 'LA COLONIA '),	('8', 'FORMOSA '),	('8', 'POSTA CAMBIO ZALAZAR '),
	('9', 'TUSAQUILLAS '),	('9', 'SANTA ANA '),	('9', 'TRANCAS '),
	('10', 'TORTUGAS '),	('10', 'LIHUEL CALEL '),	('10', 'PUELCHES '),
	('11', 'LA CORTADA '),	('11', 'LA SERENA '),	('11', 'SAN RAFAEL '),
	('12', 'LAS LEÑAS '),	('12', 'EL CHACAY '),	('12', 'AGUA ESCONDIDA '),
	('13', 'EL SALTO '),	('13', '1 DE MAYO '),	('13', 'POSADAS '),
	('14', 'NAHUEL HUAPI '),	('14', 'LA LIPELA '),	('14', 'HUEMUL '),
	('15', 'VIEDMA '),	('15', 'EL JUNCAL '),	('15', 'EL PASO '),
	('16', 'CHASICO '),	('16', 'MOJOTORO '),	('16', 'ISLAS DE VAQUEROS '),
	('17', 'CHASICO '),	('17', 'MOJOTORO '),	('17', 'ISLAS DE VAQUEROS '),
	('18', 'RAWSON '),	('18', 'BALCARCE '),	('18', 'CORTADERAS '),	
	('19', 'EL CHALTEN '),	('19', 'PERITO MORENO '),	('19', 'RIO GALLEGOS '),
	('20', 'ARRUFO '),	('20', 'SAN RAFAEL '),	('20', 'LA VANGUARDIA '),
	('21', 'LA FLORIDA '),	('21', 'LA RIVERA '),	('21', 'SAN RAMON '),
	('22', 'USHUAIA '),	('22', 'PUERTO DARWIN '),	('22', 'PUERTO ARGENTINO '),
	('23', 'EL FORTIN '),	('23', 'LA FLORIDA '),	('23', 'EL TALAR '),
	('24', 'BOCA '),	('24', 'NUñEZ '),	('24', 'RECOLETA ')
GO

--Procedimiento para listar Provincias
CREATE OR ALTER PROCEDURE ListarProvincias
AS 
BEGIN
	SELECT Id_Provincia, Provincia FROM Provincia
END;
GO

--Procedimiento para listar negocios
CREATE OR ALTER PROCEDURE ListarNegocios
AS
BEGIN
    SELECT Id_Negocio,Nombre,Imagen 
    FROM Negocio WHERE Id_Negocio = 1
END;
GO

--Procedimiento para listar Marcas
CREATE OR ALTER PROCEDURE ListarMarcas
AS
BEGIN
    SELECT Id_Marca, marca 
    FROM Marca
END;
GO

--Procedimiento para listar localidades
CREATE OR ALTER PROCEDURE ListarLocalidades
AS
BEGIN
    SELECT Id_Localidad, Id_Provincia, localidad 
    FROM Localidad
END;
GO

insert into Marca (Marca) values ('Nissan'), ('Audi');

insert into Modelo (Id_Marca, Modelo, Consumo, Puertas, Asientos) values 
('1', 'Skyline GT-R R34', '200', '3', '4'), ('2', 'TT', '150' , '5' , '4'), ('1', '350z', '300', '2', '2');

Insert into Perfiles (Descripcion) values ('Gerente')
Insert into Perfiles (Descripcion) values ('Encargado')

Insert Into Domicilio(Id_Localidad,Calle,Numero) Values (7,'Libertad',565)

Insert into Persona(DNI,Nombre,Apellido,Fecha_Nacimiento,Mail,Telefono,Id_Domicilio) values ('15963251','Jose Emilio','Perez','2002-04-24','Josesito234@Gmail.com','3444589625',1)

Insert into Usuarios (Id_Perfil,Usuario,Contraseña,Estado,Id_Persona) values (1,'Josesito234','admin',1,1)

INSERT into Tipo_Pago (Descripcion, estado) values ('Tarjeta', 1), ('Efectivo', 1);

Insert into Negocio (Nombre) Values ('Doc Hudson')
