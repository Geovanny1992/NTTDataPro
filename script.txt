IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'BaseDatos')
  BEGIN
CREATE DATABASE [BaseDatos]
END
GO
    USE [BaseDatos]
GO

IF OBJECT_ID('dbo.Movimientos', 'U') IS NOT NULL 
DROP TABLE dbo.Movimientos; 
go
IF OBJECT_ID('dbo.Cuentas', 'U') IS NOT NULL 
DROP TABLE dbo.Cuentas; 
go
IF OBJECT_ID('dbo.Clientes', 'U') IS NOT NULL 
 DROP TABLE dbo.Clientes; 
 go


CREATE TABLE [dbo].[Clientes](
	[Id] numeric(10,0) primary key IDENTITY(1,1) NOT NULL,
	[Contrasena] nvarchar (100) NULL,
	[Estado] bit NOT NULL,
	[Nombres] nvarchar (200) NULL,
	[Genero]  int NOT NULL,
	[FechaNacimiento] date NOT NULL,
	[Identificacion] varchar (13) NULL,
	[Direccion] nvarchar (150) NULL,
	[Telefono] varchar (13) NULL)


CREATE TABLE [dbo].[Cuentas](
	[Id] numeric(10,0) primary key IDENTITY(1,1) NOT NULL,
	[NumeroCuenta] varchar(15) NULL,
	[TipoCuenta] int NOT NULL,
	[SaldoInicial] decimal(10, 2) NOT NULL,
	[Estado] bit NOT NULL,
	[ClienteId]  numeric(10,0) NOT NULL,
	Constraint Fk_Cuentas_Cliente_clienteId foreign key (ClienteId) references Clientes(Id))


  CREATE TABLE [dbo].[Movimientos](
	[Id] numeric(10,0) primary key IDENTITY(1,1) NOT NULL,
	[Fecha] datetime NULL,
	[TipoMovimiento] int NOT NULL,
	[Valor] decimal(10, 2) NOT NULL,
	[Saldo] decimal(10, 2) NOT NULL,
	[CuentaId] numeric(10,0) NOT NULL,
	[CupoDiario] numeric(10,0) NOT NULL,
	Constraint FK_Movimientos_Cuentas_CuentaId foreign key (CuentaId) references Cuentas(id)
	)

insert into Clientes values('123456',1,'Admin',1,CONVERT (datetime, '01/01/2017', 103) ,'0938756788','Cdla Guayacanes','042546253')
insert into Cuentas values('45236',1,1000,1,1)
--insert into Movimientos values(getdate(),2,500,500,1,0)



--sp
IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_nttdata_transaccones]'))
DROP PROCEDURE [dbo].[sp_nttdata_transaccones]
GO
Create procedure [dbo].[sp_nttdata_transaccones]
@opcion					 varchar(5),
@valor					decimal(10,2)=null,
@NumeroCuenta			varchar(15)=null,
@tipo					int=null,
@Fecha					datetime=null

as
begin
--001 sin cupo
--002 cupo expirado

declare @cod varchar(4)='000', 
		@msg varchar(20)='OK',
		@saldoInicial decimal=0,
		@cupoDiario decimal=0,
		@clienteID numeric(10,0)=0,
		@cuentaID numeric(10,0)=0,
		@Saldo numeric(10,0)=0
declare @table as table 
(CupoDiario numeric(10,0))
declare @valordiario numeric(10,0)=0

if(@opcion='1')--Débito (-)
Begin

	select top 1
	@saldoInicial= SaldoInicial,
	@cuentaID=Id
	from Cuentas
	where NumeroCuenta=@NumeroCuenta
	
	
	    insert into @table (CupoDiario)
		SELECT case when CupoDiario < 0 then sum(CupoDiario) end CupoDiario FROM Movimientos
		where Fecha >= DATEADD(day, -1, GETDATE())
		and CuentaId=2
		group by CupoDiario
				
	set @valordiario=(select SUM(CupoDiario) from @table)	
	if((@valordiario*(-1)) >= 1000)
	begin
	set @cod='002'
	set @msg='Cupo excedido'
		Select @cod as codError, @msg as mensaje
	return;
	End

	if (@saldoInicial <> 0)
		Begin 
		 --   update Cuentas set 
			--SaldoInicial-=@valor
			--where NumeroCuenta=@NumeroCuenta
			
			select top 1
			@saldoInicial=SaldoInicial,
			@clienteID=Id from Cuentas 			
			where NumeroCuenta=@NumeroCuenta

			set @Saldo=isnull((select top 1 Saldo from Movimientos where CuentaId=@clienteID),@saldoInicial)

			insert into Movimientos values(GETDATE(),@tipo,@valor,(@Saldo-@valor),@clienteID,-@valor)		
			Select @cod as codError, @msg as mensaje
		End
		else
			Begin
				Set @cod='001'--sin cupo
				set @msg='OK'
				Select @cod as codError, @msg as mensaje
			End
End
if(@opcion='2')--Crédito(+)
Begin
			
			select
			@saldoInicial=SaldoInicial,
			@clienteID=Id from Cuentas 			
			where NumeroCuenta=@NumeroCuenta

			set @Saldo=isnull((select top 1 Saldo from Movimientos where CuentaId=@clienteID),@saldoInicial)

			insert into Movimientos values(GETDATE(),@tipo,@valor,(@Saldo+@valor),@clienteID,@valor)		
			Select @cod as codError, @msg as mensaje
End

if(@opcion='3')
Begin
if(len(@Fecha)>0)
Begin
	select top(100) m.Fecha,c.Nombres,
	cta.NumeroCuenta,cta.TipoCuenta,SaldoInicial,cta.Estado,CupoDiario,Saldo

	from Clientes c
	join Cuentas cta on c.Id=cta.ClienteId
	join Movimientos m on m.CuentaId=cta.Id
	where Fecha <=@Fecha
end
else 
	Begin
	Set @cod ='0001'
		Select @cod as codError, @msg as mensaje
	End 
End
if(@opcion='4')
	Begin 
		select top(1)
		m.Fecha,
		c.Nombres,
		cta.NumeroCuenta,
		cta.TipoCuenta,
		SaldoInicial,
		Saldo ,
		cta.Estado 
		from Clientes c
		join Cuentas cta on c.Id=cta.ClienteId
		join Movimientos m on m.CuentaId=cta.Id
		where NumeroCuenta =@NumeroCuenta
		order by m.Id

	End
End
