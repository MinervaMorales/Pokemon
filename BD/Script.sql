--CREATE DATABASE [Pokemon] 

CREATE TABLE poderes(
    poder_id INT PRIMARY KEY IDENTITY (1, 1),
    descripcion VARCHAR (50) NOT NULL,
);


CREATE TABLE categoria(
    categoria_id INT PRIMARY KEY IDENTITY (1, 1),
    descripcion VARCHAR (50) NOT NULL,
);

CREATE TABLE pokem(
    poke_id INT PRIMARY KEY IDENTITY (1, 1),
    nombre VARCHAR (50) NOT NULL,
	categoria_id INT NOT NULL,
	salud INT NULL,
	observaciones VARCHAR (50) NULL,
    FOREIGN KEY (categoria_id) REFERENCES categoria (categoria_id),
);

CREATE TABLE poke_poder
(
  id PRIMARY KEY IDENTITY (1, 1),
  poke_id INT NOT NULL,
  poder_id INT NOT NULL,
  CONSTRAINT poke_poder_pk PRIMARY KEY (id),
  CONSTRAINT FK_poke 
      FOREIGN KEY (poke_id) REFERENCES pokem (poke_id),
  CONSTRAINT FK_poderes 
      FOREIGN KEY (poder_id) REFERENCES poderes (poder_id)
);


ALTER TABLE poke_poder  WITH CHECK ADD  CONSTRAINT [poke_id] FOREIGN KEY([poke_id])
REFERENCES pokem ([poke_id])
ON DELETE CASCADE

USE [Pokemon]
GO
INSERT INTO [dbo].[categoria] ([descripcion]) VALUES ('categoria 1');
INSERT INTO [dbo].[categoria] ([descripcion]) VALUES ('categoria 2');
INSERT INTO [dbo].[categoria] ([descripcion]) VALUES ('categoria 3');
INSERT INTO [dbo].[categoria] ([descripcion]) VALUES ('categoria 4');
INSERT INTO [dbo].[categoria] ([descripcion]) VALUES ('categoria 5');

INSERT INTO [dbo].[poderes] ([descripcion]) VALUES ('poder 1')
INSERT INTO [dbo].[poderes] ([descripcion]) VALUES ('poder 2')
INSERT INTO [dbo].[poderes] ([descripcion]) VALUES ('poder 3')
INSERT INTO [dbo].[poderes] ([descripcion]) VALUES ('poder 4')
INSERT INTO [dbo].[poderes] ([descripcion]) VALUES ('poder 5')

INSERT INTO [dbo].[poke_poder] ([poke_id],[poder_id]) VALUES (1,1)
INSERT INTO [dbo].[poke_poder] ([poke_id],[poder_id]) VALUES (2,2)
INSERT INTO [dbo].[poke_poder] ([poke_id],[poder_id]) VALUES (3,3)


INSERT  [dbo].[pokem] ([nombre],[categoria_id],[salud], [observaciones]) VALUES ('pikachu 42',2,400,'poderoso 2')
INSERT  [dbo].[pokem] ([nombre],[categoria_id],[salud], [observaciones]) VALUES ('pikachu 42',3,700,'poderoso 3')
INSERT  [dbo].[pokem] ([nombre],[categoria_id],[salud], [observaciones]) VALUES ('pikachu 42',1,100,'poderoso 4')
INSERT  [dbo].[pokem] ([nombre],[categoria_id],[salud], [observaciones]) VALUES ('pikachu 42',3,200,'poderoso 5')
INSERT  [dbo].[pokem] ([nombre],[categoria_id],[salud], [observaciones]) VALUES ('pikachu 42',1,300,'poderoso 6')
INSERT  [dbo].[pokem] ([nombre],[categoria_id],[salud], [observaciones]) VALUES ('pikachu 42',2,800,'poderoso 7')
INSERT  [dbo].[pokem] ([nombre],[categoria_id],[salud], [observaciones]) VALUES ('pikachu 42',3,900,'poderoso 8')

GO