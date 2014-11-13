use Gas_test2
go
--create schema dbo
--go

if exists (select * from dbo.sysobjects where id = object_id(N'EquipTypeAbl') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table EquipTypeAbl
go

create table EquipTypeAbl (
    AutoID INT   IDENTITY(1,1) NOT NULL ,
    EquipName NVARCHAR(10)  NULL ,
    ETabName VARCHAR(10)  NULL 
) 
go

alter table EquipTypeAbl add 
    CONSTRAINT pk_EquipTypeAbl PRIMARY KEY  CLUSTERED 
    (
        AutoID
    ) 
go
DECLARE @v sql_variant
SET @v = N'可选设备种类表'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'EquipTypeAbl', NULL, NULL
go

DECLARE @v sql_variant
SET @v = N'自动编号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'EquipTypeAbl', N'column', N'AutoID'
go
DECLARE @v sql_variant
SET @v = N'设备名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'EquipTypeAbl', N'column', N'EquipName'
go
DECLARE @v sql_variant
SET @v = N'设备简称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'EquipTypeAbl', N'column', N'ETabName'
go

if exists (select * from dbo.sysobjects where id = object_id(N'EquipTypeSlet') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table EquipTypeSlet
go

create table EquipTypeSlet (
    EquipName NVARCHAR(10)  NULL ,
    ETabName VARCHAR(10)  NOT NULL ,
    EquipNum INT  NULL ,
    L1 VARCHAR(128)  NULL ,
    L2 VARCHAR(128)  NULL ,
    L3 VARCHAR(128)  NULL 
) 
go

alter table EquipTypeSlet add 
    CONSTRAINT pk_EquipTypeSlet PRIMARY KEY  CLUSTERED 
    (
        ETabName
    ) 
go
DECLARE @v sql_variant
SET @v = N'选择设备种类表'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'EquipTypeSlet', NULL, NULL
go

DECLARE @v sql_variant
SET @v = N'EquipName'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'EquipTypeSlet', N'column', N'EquipName'
go
DECLARE @v sql_variant
SET @v = N'ETabName'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'EquipTypeSlet', N'column', N'ETabName'
go
DECLARE @v sql_variant
SET @v = N'EquipNum'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'EquipTypeSlet', N'column', N'EquipNum'
go
DECLARE @v sql_variant
SET @v = N'L1'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'EquipTypeSlet', N'column', N'L1'
go
DECLARE @v sql_variant
SET @v = N'L2'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'EquipTypeSlet', N'column', N'L2'
go
DECLARE @v sql_variant
SET @v = N'L3'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'EquipTypeSlet', N'column', N'L3'
go

if exists (select * from dbo.sysobjects where id = object_id(N'AlgTypeAbl') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table AlgTypeAbl
go

create table AlgTypeAbl (
    AutoID INT   IDENTITY(1,1) NOT NULL ,
    AlgName NVARCHAR(10)  NULL ,
    ATabName VARCHAR(10)  NULL ,
    AlgRoute VARCHAR(128)  NULL 
) 
go

alter table AlgTypeAbl add 
    CONSTRAINT pk_AlgTypeAbl PRIMARY KEY  CLUSTERED 
    (
        AutoID
    ) 
go
DECLARE @v sql_variant
SET @v = N'可选算法种类表'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'AlgTypeAbl', NULL, NULL
go

DECLARE @v sql_variant
SET @v = N'自动编号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'AlgTypeAbl', N'column', N'AutoID'
go
DECLARE @v sql_variant
SET @v = N'算法名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'AlgTypeAbl', N'column', N'AlgName'
go
DECLARE @v sql_variant
SET @v = N'算法简称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'AlgTypeAbl', N'column', N'ATabName'
go
DECLARE @v sql_variant
SET @v = N'算法路径'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'AlgTypeAbl', N'column', N'AlgRoute'
go

if exists (select * from dbo.sysobjects where id = object_id(N'AlgTypeSlet') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table AlgTypeSlet
go

create table AlgTypeSlet (
    AlgName NVARCHAR(10)  NULL ,
    ATabName VARCHAR(10)  NOT NULL 
) 
go

alter table AlgTypeSlet add 
    CONSTRAINT pk_AlgTypeSlet PRIMARY KEY  CLUSTERED 
    (
        ATabName
    ) 
go
DECLARE @v sql_variant
SET @v = N'选择算法种类表'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'AlgTypeSlet', NULL, NULL
go

DECLARE @v sql_variant
SET @v = N'AlgName'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'AlgTypeSlet', N'column', N'AlgName'
go
DECLARE @v sql_variant
SET @v = N'ATabName'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'table', N'AlgTypeSlet', N'column', N'ATabName'
go

