USE [laboratorio_2]
GO

/****** Object:  Table [dbo].[usuarios]    Script Date: 10/8/2022 07:20:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[usuarios](
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[dni] [int] NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[clave] [varchar](50) NOT NULL
) ON [PRIMARY]
GO

INSERT INTO [dbo].[usuarios] ([nombre],
	[apellido],
	[dni],
	[correo],
	[clave])
	VALUES
	('Juan', 'Perez', 111222, 'juan@perez.com', '123456'),
	('Enrique', 'Gonzalez', 444555, 'enrique@gonzalez.com', '123456'),
	('Maria', 'Bustamante', 777888, 'maria@bustamante.com.ar', '123456'),
	('Roberto', 'Carlos', 23555888, 'roberto@carlos.com', '123456'),
	('Ricardo', 'Antunez', 85666333, 'ricardo@antunez.com', '123456'),
	('Susana', 'Gimenez', 9666333, 'susana@gimenez.com', '123456'),
	('Hernan', 'Lopez', 8889990, 'lopez@mail.com', '123456'),
	('Patricia', 'Lopez', 66332211, 'pato@lopez.com', '123456'),
	('Julio', 'Lopez', 77788899, 'julio@lopez.com.ar', '123456');

GO

							