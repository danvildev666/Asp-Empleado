USE [GestionEmpleadosDB]
GO
/****** Object:  Table [dbo].[Acceso]    Script Date: 20-11-2019 14:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acceso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Pass] [nvarchar](50) NULL,
	[Fecha_Ultima_Conexion] [datetime] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_Acceso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Afp]    Script Date: 20-11-2019 14:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Afp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[comision] [float] NULL,
 CONSTRAINT [PK_Afp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asignacion_familiar]    Script Date: 20-11-2019 14:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignacion_familiar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[valor] [float] NULL,
	[tramo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Parametros_CargaFam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Beneficio_Antiguedad]    Script Date: 20-11-2019 14:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficio_Antiguedad](
	[Id] [int] NOT NULL,
	[Annos_Antiguedad] [int] NULL,
	[porcentaje_antiguedad] [float] NULL,
 CONSTRAINT [PK_Beneficio_Antiguedad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Descuento]    Script Date: 20-11-2019 14:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Descuento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rut_empleado] [int] NOT NULL,
	[descuento_afp] [float] NULL,
	[seguro_vida] [float] NULL,
	[descuento_salud] [float] NULL,
	[seguro_cesantia] [float] NULL,
	[total_descuentos] [float] NULL,
 CONSTRAINT [PK_Descuento] PRIMARY KEY CLUSTERED 
(
	[rut_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 20-11-2019 14:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[rut] [int] NOT NULL,
	[dv] [nvarchar](50) NULL,
	[nombre] [nvarchar](50) NULL,
	[apaterno] [nvarchar](50) NULL,
	[amaterno] [nvarchar](50) NULL,
	[annos_experiencia] [int] NULL,
	[genero] [nvarchar](50) NULL,
	[fecha_nacimiento] [date] NULL,
	[email] [nvarchar](50) NULL,
	[telefono] [int] NULL,
	[direccion] [nvarchar](50) NULL,
	[nombre_profesion] [nvarchar](50) NULL,
	[numero_cargas] [int] NULL,
	[fecha_contrato] [date] NULL,
	[salud_id] [int] NULL,
	[afp_id] [int] NULL,
	[desc_id] [int] NULL,
	[asignacion_id] [int] NULL,
	[antiguedad_id] [int] NULL,
	[sueldo_base] [float] NULL,
	[sueldo_liquido] [float] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[rut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Haberes]    Script Date: 20-11-2019 14:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Haberes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rut_empleado] [int] NOT NULL,
	[hora_extra] [float] NULL,
	[comision] [float] NULL,
	[bono] [float] NULL,
	[colacion] [float] NULL,
	[movilizacion] [float] NULL,
	[sueldo_base] [float] NULL,
	[monto_familiar] [float] NULL,
	[total_haberes] [float] NULL,
 CONSTRAINT [PK_Haberes] PRIMARY KEY CLUSTERED 
(
	[rut_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Otros_Descuentos]    Script Date: 20-11-2019 14:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Otros_Descuentos](
	[id] [int] IDENTITY(10,10) NOT NULL,
	[seguro_vida] [float] NULL,
	[seguro_cesantia] [float] NULL,
 CONSTRAINT [PK_Otros_descuentos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salud]    Script Date: 20-11-2019 14:06:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salud](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[tipo_salud] [nvarchar](50) NULL,
	[descuento_salud] [float] NULL,
 CONSTRAINT [PK_Salud] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Descuento]  WITH CHECK ADD  CONSTRAINT [FK_Descuento_Empleado] FOREIGN KEY([rut_empleado])
REFERENCES [dbo].[Empleado] ([rut])
GO
ALTER TABLE [dbo].[Descuento] CHECK CONSTRAINT [FK_Descuento_Empleado]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Afp] FOREIGN KEY([afp_id])
REFERENCES [dbo].[Afp] ([Id])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Afp]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Asignacion_familiar] FOREIGN KEY([asignacion_id])
REFERENCES [dbo].[Asignacion_familiar] ([Id])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Asignacion_familiar]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Beneficio_Antiguedad] FOREIGN KEY([antiguedad_id])
REFERENCES [dbo].[Beneficio_Antiguedad] ([Id])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Beneficio_Antiguedad]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Otros_Descuentos] FOREIGN KEY([desc_id])
REFERENCES [dbo].[Otros_Descuentos] ([id])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Otros_Descuentos]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Salud] FOREIGN KEY([salud_id])
REFERENCES [dbo].[Salud] ([Id])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Salud]
GO
ALTER TABLE [dbo].[Haberes]  WITH CHECK ADD  CONSTRAINT [FK_Haberes_Empleado] FOREIGN KEY([rut_empleado])
REFERENCES [dbo].[Empleado] ([rut])
GO
ALTER TABLE [dbo].[Haberes] CHECK CONSTRAINT [FK_Haberes_Empleado]
GO
