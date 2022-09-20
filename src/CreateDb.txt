
/*==============================================================*/
/* Data model and Data for the 'Ultra' database                 */
/* Copyright (C), Data & Object Factory, LLC                    */
/* All rights reserved. www.dofactory.com                       */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Error') and o.name = 'FK_ERROR_REFERENCE_USER')
alter table Error
   drop constraint FK_ERROR_REFERENCE_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Login') and o.name = 'FK_LOGIN_REFERENCE_USER')
alter table Login
   drop constraint FK_LOGIN_REFERENCE_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ThingA') and o.name = 'FK_THINGA_REFERENCE_THINGB')
alter table ThingA
   drop constraint FK_THINGA_REFERENCE_THINGB
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ThingA') and o.name = 'FK_CAMPAIGN_REF1_USER')
alter table ThingA
   drop constraint FK_CAMPAIGN_REF1_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ThingA') and o.name = 'FK_THINGA_REFERENCE_THINGC')
alter table ThingA
   drop constraint FK_THINGA_REFERENCE_THINGC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ThingB') and o.name = 'FK_THINGB_REFERENCE_USER')
alter table ThingB
   drop constraint FK_THINGB_REFERENCE_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ThingC') and o.name = 'FK_CAMPAIGN_REF2_USER')
alter table ThingC
   drop constraint FK_CAMPAIGN_REF2_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ThingD') and o.name = 'FK_THINGD_REFERENCE_USER')
alter table ThingD
   drop constraint FK_THINGD_REFERENCE_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ThingE') and o.name = 'FK_THINGE_REFERENCE_THINGD')
alter table ThingE
   drop constraint FK_THINGE_REFERENCE_THINGD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ThingE') and o.name = 'FK_THINGE_REFERENCE_THINGA')
alter table ThingE
   drop constraint FK_THINGE_REFERENCE_THINGA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ThingE') and o.name = 'FK_THINGE_REFERENCE_USER')
alter table ThingE
   drop constraint FK_THINGE_REFERENCE_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Viewed') and o.name = 'FK_VIEWED_REFERENCE_USER')
alter table Viewed
   drop constraint FK_VIEWED_REFERENCE_USER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Error')
            and   name  = 'IndexErrorErrorDate'
            and   indid > 0
            and   indid < 255)
   drop index Error.IndexErrorErrorDate
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Error')
            and   type = 'U')
   drop table Error
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Login')
            and   name  = 'IndexLoginLoginDate'
            and   indid > 0
            and   indid < 255)
   drop index Login.IndexLoginLoginDate
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Login')
            and   name  = 'IndexLoginUserIdLoginDate'
            and   indid > 0
            and   indid < 255)
   drop index Login.IndexLoginUserIdLoginDate
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Login')
            and   type = 'U')
   drop table Login
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingA')
            and   name  = 'IndexThingAOwnerAlias'
            and   indid > 0
            and   indid < 255)
   drop index ThingA.IndexThingAOwnerAlias
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingA')
            and   name  = 'IndexThingAStatus'
            and   indid > 0
            and   indid < 255)
   drop index ThingA.IndexThingAStatus
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingA')
            and   name  = 'IndexThingALookup'
            and   indid > 0
            and   indid < 255)
   drop index ThingA.IndexThingALookup
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingA')
            and   name  = 'IndexThingAText'
            and   indid > 0
            and   indid < 255)
   drop index ThingA.IndexThingAText
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingA')
            and   name  = 'IndexThingAThingCId'
            and   indid > 0
            and   indid < 255)
   drop index ThingA.IndexThingAThingCId
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingA')
            and   name  = 'IndexThingAThingCName'
            and   indid > 0
            and   indid < 255)
   drop index ThingA.IndexThingAThingCName
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingA')
            and   name  = 'IndexThingAThingBId'
            and   indid > 0
            and   indid < 255)
   drop index ThingA.IndexThingAThingBId
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingA')
            and   name  = 'IndexThingAThingBName'
            and   indid > 0
            and   indid < 255)
   drop index ThingA.IndexThingAThingBName
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingA')
            and   name  = 'IndexThingAName'
            and   indid > 0
            and   indid < 255)
   drop index ThingA.IndexThingAName
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ThingA')
            and   type = 'U')
   drop table ThingA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingB')
            and   name  = 'IndexThingBOwnerAlias'
            and   indid > 0
            and   indid < 255)
   drop index ThingB.IndexThingBOwnerAlias
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingB')
            and   name  = 'IndexThingBStatus'
            and   indid > 0
            and   indid < 255)
   drop index ThingB.IndexThingBStatus
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingB')
            and   name  = 'IndexThingBDateTime'
            and   indid > 0
            and   indid < 255)
   drop index ThingB.IndexThingBDateTime
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingB')
            and   name  = 'IndexThingBMoney'
            and   indid > 0
            and   indid < 255)
   drop index ThingB.IndexThingBMoney
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingB')
            and   name  = 'IndexThingBLookup'
            and   indid > 0
            and   indid < 255)
   drop index ThingB.IndexThingBLookup
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingB')
            and   name  = 'IndexThingBText'
            and   indid > 0
            and   indid < 255)
   drop index ThingB.IndexThingBText
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingB')
            and   name  = 'IndexThingBName'
            and   indid > 0
            and   indid < 255)
   drop index ThingB.IndexThingBName
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ThingB')
            and   type = 'U')
   drop table ThingB
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingC')
            and   name  = 'IndexThingCOwnerAlias'
            and   indid > 0
            and   indid < 255)
   drop index ThingC.IndexThingCOwnerAlias
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingC')
            and   name  = 'IndexThingCStatus'
            and   indid > 0
            and   indid < 255)
   drop index ThingC.IndexThingCStatus
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingC')
            and   name  = 'IndexThingCDateTime'
            and   indid > 0
            and   indid < 255)
   drop index ThingC.IndexThingCDateTime
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingC')
            and   name  = 'IndexThingCMoney'
            and   indid > 0
            and   indid < 255)
   drop index ThingC.IndexThingCMoney
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingC')
            and   name  = 'IndexThingCLookup'
            and   indid > 0
            and   indid < 255)
   drop index ThingC.IndexThingCLookup
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingC')
            and   name  = 'IndexThingCText'
            and   indid > 0
            and   indid < 255)
   drop index ThingC.IndexThingCText
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingC')
            and   name  = 'IndexThingCName'
            and   indid > 0
            and   indid < 255)
   drop index ThingC.IndexThingCName
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ThingC')
            and   type = 'U')
   drop table ThingC
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingD')
            and   name  = 'IndexThingDOwnerAlias'
            and   indid > 0
            and   indid < 255)
   drop index ThingD.IndexThingDOwnerAlias
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingD')
            and   name  = 'IndexThingDStatus'
            and   indid > 0
            and   indid < 255)
   drop index ThingD.IndexThingDStatus
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingD')
            and   name  = 'IndexThingDDateTime'
            and   indid > 0
            and   indid < 255)
   drop index ThingD.IndexThingDDateTime
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingD')
            and   name  = 'IndexThingDMoney'
            and   indid > 0
            and   indid < 255)
   drop index ThingD.IndexThingDMoney
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingD')
            and   name  = 'IndexThingDLookup'
            and   indid > 0
            and   indid < 255)
   drop index ThingD.IndexThingDLookup
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingD')
            and   name  = 'IndexThingDText'
            and   indid > 0
            and   indid < 255)
   drop index ThingD.IndexThingDText
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingD')
            and   name  = 'IndexThingDName'
            and   indid > 0
            and   indid < 255)
   drop index ThingD.IndexThingDName
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ThingD')
            and   type = 'U')
   drop table ThingD
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingE')
            and   name  = 'IndexThingEOwnerAlias'
            and   indid > 0
            and   indid < 255)
   drop index ThingE.IndexThingEOwnerAlias
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingE')
            and   name  = 'IndexThingEStatus'
            and   indid > 0
            and   indid < 255)
   drop index ThingE.IndexThingEStatus
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingE')
            and   name  = 'IndexThingEMoney'
            and   indid > 0
            and   indid < 255)
   drop index ThingE.IndexThingEMoney
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingE')
            and   name  = 'IndexThingELookup'
            and   indid > 0
            and   indid < 255)
   drop index ThingE.IndexThingELookup
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingE')
            and   name  = 'IndexThingEText'
            and   indid > 0
            and   indid < 255)
   drop index ThingE.IndexThingEText
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingE')
            and   name  = 'IndexThingEObjectDName'
            and   indid > 0
            and   indid < 255)
   drop index ThingE.IndexThingEObjectDName
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingE')
            and   name  = 'IndexThingEObjectDId'
            and   indid > 0
            and   indid < 255)
   drop index ThingE.IndexThingEObjectDId
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingE')
            and   name  = 'IndexThingEObjectAName'
            and   indid > 0
            and   indid < 255)
   drop index ThingE.IndexThingEObjectAName
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingE')
            and   name  = 'IndexThingEObject1Id'
            and   indid > 0
            and   indid < 255)
   drop index ThingE.IndexThingEObject1Id
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ThingE')
            and   name  = 'IndexThingEName'
            and   indid > 0
            and   indid < 255)
   drop index ThingE.IndexThingEName
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ThingE')
            and   type = 'U')
   drop table ThingE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"User"')
            and   name  = 'IndexUserLastLoginDate'
            and   indid > 0
            and   indid < 255)
   drop index "User".IndexUserLastLoginDate
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"User"')
            and   name  = 'IndexUserDepartment'
            and   indid > 0
            and   indid < 255)
   drop index "User".IndexUserDepartment
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"User"')
            and   name  = 'IndexUserEmployeeNumber'
            and   indid > 0
            and   indid < 255)
   drop index "User".IndexUserEmployeeNumber
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"User"')
            and   name  = 'IndexUserAlias'
            and   indid > 0
            and   indid < 255)
   drop index "User".IndexUserAlias
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"User"')
            and   name  = 'IndexUserIdentityName'
            and   indid > 0
            and   indid < 255)
   drop index "User".IndexUserIdentityName
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"User"')
            and   name  = 'IndexUserIdentityId'
            and   indid > 0
            and   indid < 255)
   drop index "User".IndexUserIdentityId
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"User"')
            and   name  = 'IndexUserEmail'
            and   indid > 0
            and   indid < 255)
   drop index "User".IndexUserEmail
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"User"')
            and   name  = 'IndexUserLastName'
            and   indid > 0
            and   indid < 255)
   drop index "User".IndexUserLastName
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"User"')
            and   type = 'U')
   drop table "User"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Viewed')
            and   name  = 'IndexViewedWhatWhat'
            and   indid > 0
            and   indid < 255)
   drop index Viewed.IndexViewedWhatWhat
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Viewed')
            and   name  = 'IndexViewedUserWhatWhat'
            and   indid > 0
            and   indid < 255)
   drop index Viewed.IndexViewedUserWhatWhat
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Viewed')
            and   type = 'U')
   drop table Viewed
go

/*==============================================================*/
/* Table: Error                                                 */
/*==============================================================*/
create table Error (
   Id                   int                  identity,
   UserId               int                  null,
   ErrorDate            datetime2            not null default getdate(),
   Message              nvarchar(600)        not null,
   Exception            nvarchar(max)        null,
   IpAddress            nvarchar(40)         null,
   Url                  nvarchar(400)        null,
   HttpReferer          nvarchar(400)        null,
   UserAgent            nvarchar(400)        null,
   CreatedOn            datetime2            not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime2            not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_ERROR primary key (Id)
)
go

/*==============================================================*/
/* Index: IndexErrorErrorDate                                   */
/*==============================================================*/
create index IndexErrorErrorDate on Error (
ErrorDate ASC
)
go

/*==============================================================*/
/* Table: Login                                                 */
/*==============================================================*/
create table Login (
   Id                   int                  identity,
   UserId               int                  null,
   LastName             nvarchar(50)         null,
   FirstName            nvarchar(50)         null,
   Email                nvarchar(100)        not null,
   LoginDate            datetime2            not null default getdate(),
   Result               nvarchar(10)         not null,
   IpAddress            nvarchar(40)         null,
   CreatedOn            datetime2            not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime2            not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_LOGIN primary key (Id)
)
go

/*==============================================================*/
/* Index: IndexLoginUserIdLoginDate                             */
/*==============================================================*/
create index IndexLoginUserIdLoginDate on Login (
UserId ASC,
LoginDate ASC
)
go

/*==============================================================*/
/* Index: IndexLoginLoginDate                                   */
/*==============================================================*/
create index IndexLoginLoginDate on Login (
LoginDate ASC
)
go

/*==============================================================*/
/* Table: ThingA                                                */
/*==============================================================*/
create table ThingA (
   Id                   int                  identity,
   Name                 nvarchar(100)        not null,
   ThingBId             int                  null,
   ThingBName           nvarchar(100)        null,
   ThingCId             int                  null,
   ThingCName           nvarchar(100)        null,
   Text                 nvarchar(40)         null,
   Lookup               nvarchar(40)         null,
   Money                decimal(16,2)        null,
   DateTime             datetime2            null,
   Status               nvarchar(40)         null,
   Integer              int                  null,
   Boolean              bit                  null,
   LongText             nvarchar(max)        null,
   TotalThingsE         int                  not null default 0,
   CreatedDate          datetime2            not null default getdate(),
   OwnerId              int                  not null,
   OwnerAlias           nvarchar(20)         not null,
   CreatedOn            datetime2            not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime2            not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_THINGA primary key (Id)
)
go

/*==============================================================*/
/* Index: IndexThingAName                                       */
/*==============================================================*/
create index IndexThingAName on ThingA (
Name ASC
)
go

/*==============================================================*/
/* Index: IndexThingAThingBName                                 */
/*==============================================================*/
create index IndexThingAThingBName on ThingA (
ThingBName ASC
)
go

/*==============================================================*/
/* Index: IndexThingAThingBId                                   */
/*==============================================================*/
create index IndexThingAThingBId on ThingA (
ThingBId ASC
)
go

/*==============================================================*/
/* Index: IndexThingAThingCName                                 */
/*==============================================================*/
create index IndexThingAThingCName on ThingA (
ThingCName ASC
)
go

/*==============================================================*/
/* Index: IndexThingAThingCId                                   */
/*==============================================================*/
create index IndexThingAThingCId on ThingA (
ThingCId ASC
)
go

/*==============================================================*/
/* Index: IndexThingAText                                       */
/*==============================================================*/
create index IndexThingAText on ThingA (
Text ASC
)
go

/*==============================================================*/
/* Index: IndexThingALookup                                     */
/*==============================================================*/
create index IndexThingALookup on ThingA (
Lookup ASC
)
go

/*==============================================================*/
/* Index: IndexThingAStatus                                     */
/*==============================================================*/
create index IndexThingAStatus on ThingA (
Status ASC
)
go

/*==============================================================*/
/* Index: IndexThingAOwnerAlias                                 */
/*==============================================================*/
create index IndexThingAOwnerAlias on ThingA (
OwnerAlias ASC
)
go

/*==============================================================*/
/* Table: ThingB                                                */
/*==============================================================*/
create table ThingB (
   Id                   int                  identity,
   Name                 nvarchar(100)        not null,
   Text                 nvarchar(40)         null,
   Lookup               nvarchar(40)         null,
   Money                decimal(16,2)        null,
   DateTime             datetime2            null,
   Status               nvarchar(40)         null,
   Integer              int                  null,
   Boolean              bit                  null,
   LongText             nvarchar(max)        null,
   TotalThingsA         int                  not null default 0,
   OwnerId              int                  not null,
   OwnerAlias           nvarchar(20)         not null,
   CreatedDate          datetime2            not null default getdate(),
   CreatedOn            datetime2            not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime2            not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_THINGB primary key (Id)
)
go

/*==============================================================*/
/* Index: IndexThingBName                                       */
/*==============================================================*/
create index IndexThingBName on ThingB (
Name ASC
)
go

/*==============================================================*/
/* Index: IndexThingBText                                       */
/*==============================================================*/
create index IndexThingBText on ThingB (
Text ASC
)
go

/*==============================================================*/
/* Index: IndexThingBLookup                                     */
/*==============================================================*/
create index IndexThingBLookup on ThingB (
Lookup ASC
)
go

/*==============================================================*/
/* Index: IndexThingBMoney                                      */
/*==============================================================*/
create index IndexThingBMoney on ThingB (
Money ASC
)
go

/*==============================================================*/
/* Index: IndexThingBDateTime                                   */
/*==============================================================*/
create index IndexThingBDateTime on ThingB (
DateTime ASC
)
go

/*==============================================================*/
/* Index: IndexThingBStatus                                     */
/*==============================================================*/
create index IndexThingBStatus on ThingB (
Status ASC
)
go

/*==============================================================*/
/* Index: IndexThingBOwnerAlias                                 */
/*==============================================================*/
create index IndexThingBOwnerAlias on ThingB (
OwnerAlias ASC
)
go

/*==============================================================*/
/* Table: ThingC                                                */
/*==============================================================*/
create table ThingC (
   Id                   int                  identity,
   Name                 nvarchar(100)        null,
   Text                 nvarchar(40)         null,
   Lookup               nvarchar(40)         null,
   Money                decimal(16,2)        null,
   DateTime             datetime2            null,
   Status               nvarchar(40)         null,
   Integer              int                  null,
   Boolean              bit                  null,
   LongText             nvarchar(max)        null,
   TotalThingsA         int                  not null default 0,
   CreatedDate          datetime2            not null default getdate(),
   OwnerId              int                  not null,
   OwnerAlias           nvarchar(20)         not null,
   CreatedOn            datetime2            not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime2            not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_THINGC primary key (Id)
)
go

/*==============================================================*/
/* Index: IndexThingCName                                       */
/*==============================================================*/
create index IndexThingCName on ThingC (
Name ASC
)
go

/*==============================================================*/
/* Index: IndexThingCText                                       */
/*==============================================================*/
create index IndexThingCText on ThingC (
Text ASC
)
go

/*==============================================================*/
/* Index: IndexThingCLookup                                     */
/*==============================================================*/
create index IndexThingCLookup on ThingC (
Lookup ASC
)
go

/*==============================================================*/
/* Index: IndexThingCMoney                                      */
/*==============================================================*/
create index IndexThingCMoney on ThingC (
Money ASC
)
go

/*==============================================================*/
/* Index: IndexThingCDateTime                                   */
/*==============================================================*/
create index IndexThingCDateTime on ThingC (
DateTime ASC
)
go

/*==============================================================*/
/* Index: IndexThingCStatus                                     */
/*==============================================================*/
create index IndexThingCStatus on ThingC (
Status ASC
)
go

/*==============================================================*/
/* Index: IndexThingCOwnerAlias                                 */
/*==============================================================*/
create index IndexThingCOwnerAlias on ThingC (
OwnerAlias ASC
)
go

/*==============================================================*/
/* Table: ThingD                                                */
/*==============================================================*/
create table ThingD (
   Id                   int                  identity,
   Name                 nvarchar(100)        not null,
   Text                 nvarchar(40)         null,
   Lookup               nvarchar(40)         null,
   Money                decimal(16,2)        null,
   DateTime             datetime2            null,
   Status               nvarchar(40)         null,
   Integer              int                  null,
   Boolean              bit                  null,
   LongText             nvarchar(max)        null,
   TotalThingsE         int                  not null default 0,
   OwnerId              int                  not null,
   OwnerAlias           nvarchar(20)         not null,
   CreatedDate          datetime2            not null default getdate(),
   CreatedOn            datetime2            not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime2            not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_THINGD primary key (Id)
)
go

/*==============================================================*/
/* Index: IndexThingDName                                       */
/*==============================================================*/
create index IndexThingDName on ThingD (
Name ASC
)
go

/*==============================================================*/
/* Index: IndexThingDText                                       */
/*==============================================================*/
create index IndexThingDText on ThingD (
Text ASC
)
go

/*==============================================================*/
/* Index: IndexThingDLookup                                     */
/*==============================================================*/
create index IndexThingDLookup on ThingD (
Lookup ASC
)
go

/*==============================================================*/
/* Index: IndexThingDMoney                                      */
/*==============================================================*/
create index IndexThingDMoney on ThingD (
Money ASC
)
go

/*==============================================================*/
/* Index: IndexThingDDateTime                                   */
/*==============================================================*/
create index IndexThingDDateTime on ThingD (
DateTime ASC
)
go

/*==============================================================*/
/* Index: IndexThingDStatus                                     */
/*==============================================================*/
create index IndexThingDStatus on ThingD (
Status ASC
)
go

/*==============================================================*/
/* Index: IndexThingDOwnerAlias                                 */
/*==============================================================*/
create index IndexThingDOwnerAlias on ThingD (
OwnerAlias ASC
)
go

/*==============================================================*/
/* Table: ThingE                                                */
/*==============================================================*/
create table ThingE (
   Id                   int                  identity,
   Name                 nvarchar(100)        not null,
   ThingAId             int                  null,
   ThingAName           nvarchar(100)        null,
   ThingDId             int                  null,
   ThingDName           nvarchar(100)        null,
   Text                 nvarchar(40)         null,
   Lookup               nvarchar(40)         null,
   Money                decimal(16,2)        null,
   DateTime             datetime2            null,
   Status               nvarchar(40)         null,
   Integer              int                  null,
   Boolean              bit                  null,
   LongText             nvarchar(max)        null,
   OwnerId              int                  not null,
   OwnerAlias           nvarchar(20)         not null,
   CreatedDate          datetime2            not null default getdate(),
   CreatedOn            datetime2            not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime2            not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_THINGE primary key (Id)
)
go

/*==============================================================*/
/* Index: IndexThingEName                                       */
/*==============================================================*/
create index IndexThingEName on ThingE (
Name ASC
)
go

/*==============================================================*/
/* Index: IndexThingEObject1Id                                  */
/*==============================================================*/
create index IndexThingEObject1Id on ThingE (
ThingAId ASC
)
go

/*==============================================================*/
/* Index: IndexThingEObjectAName                                */
/*==============================================================*/
create index IndexThingEObjectAName on ThingE (
ThingAName ASC
)
go

/*==============================================================*/
/* Index: IndexThingEObjectDId                                  */
/*==============================================================*/
create index IndexThingEObjectDId on ThingE (
ThingDId ASC
)
go

/*==============================================================*/
/* Index: IndexThingEObjectDName                                */
/*==============================================================*/
create index IndexThingEObjectDName on ThingE (
ThingDName ASC
)
go

/*==============================================================*/
/* Index: IndexThingEText                                       */
/*==============================================================*/
create index IndexThingEText on ThingE (
Text ASC
)
go

/*==============================================================*/
/* Index: IndexThingELookup                                     */
/*==============================================================*/
create index IndexThingELookup on ThingE (
Lookup ASC
)
go

/*==============================================================*/
/* Index: IndexThingEMoney                                      */
/*==============================================================*/
create index IndexThingEMoney on ThingE (
Money ASC
)
go

/*==============================================================*/
/* Index: IndexThingEStatus                                     */
/*==============================================================*/
create index IndexThingEStatus on ThingE (
Status ASC
)
go

/*==============================================================*/
/* Index: IndexThingEOwnerAlias                                 */
/*==============================================================*/
create index IndexThingEOwnerAlias on ThingE (
OwnerAlias ASC
)
go

/*==============================================================*/
/* Table: "User"                                                */
/*==============================================================*/
create table "User" (
   Id                   int                  identity,
   FirstName            nvarchar(50)         not null,
   LastName             nvarchar(50)         not null,
   Email                nvarchar(100)        not null,
   Alias                nvarchar(20)         not null,
   City                 nvarchar(50)         null,
   Country              nvarchar(50)         null,
   EmployeeNumber       nvarchar(40)         null,
   Department           nvarchar(40)         null,
   LastLoginDate        datetime2            null,
   TotalThingsA         int                  not null default 0,
   TotalThingsB         int                  not null default 0,
   TotalThingsC         int                  not null default 0,
   TotalThingsD         int                  not null default 0,
   TotalThingsE         int                  not null default 0,
   Role                 nvarchar(20)         not null default User,
   IdentityId           nvarchar(50)         null,
   IdentityName         nvarchar(50)         null,
   CreatedDate          datetime2            not null default getdate(),
   ActivationCode       nvarchar(30)         null,
   ActivationDate       datetime2            null,
   ResetCode            nvarchar(30)         null,
   ResetDate            datetime2            null,
   AppKey               nvarchar(50)         null,
   AppSecret            nvarchar(100)        null,
   CreatedOn            datetime2            not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime2            not null default getdate(),
   ChangedBy            int                  null,
   DeletedOn            datetime2            null,
   DeletedBy            int                  null,
   IsDeleted            bit                  not null,
   constraint PK_USER primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IndexUserLastName                                     */
/*==============================================================*/
create index IndexUserLastName on "User" (
LastName ASC
)
go

/*==============================================================*/
/* Index: IndexUserEmail                                        */
/*==============================================================*/
create unique index IndexUserEmail on "User" (
Email ASC
)
go

/*==============================================================*/
/* Index: IndexUserIdentityId                                   */
/*==============================================================*/
create index IndexUserIdentityId on "User" (
IdentityId ASC
)
go

/*==============================================================*/
/* Index: IndexUserIdentityName                                 */
/*==============================================================*/
create index IndexUserIdentityName on "User" (
IdentityName ASC
)
go

/*==============================================================*/
/* Index: IndexUserAlias                                        */
/*==============================================================*/
create unique index IndexUserAlias on "User" (
Alias ASC
)
go

/*==============================================================*/
/* Index: IndexUserEmployeeNumber                               */
/*==============================================================*/
create index IndexUserEmployeeNumber on "User" (
EmployeeNumber ASC
)
go

/*==============================================================*/
/* Index: IndexUserDepartment                                   */
/*==============================================================*/
create index IndexUserDepartment on "User" (
Department ASC
)
go

/*==============================================================*/
/* Index: IndexUserLastLoginDate                                */
/*==============================================================*/
create index IndexUserLastLoginDate on "User" (
LastLoginDate ASC
)
go

/*==============================================================*/
/* Table: Viewed                                                */
/*==============================================================*/
create table Viewed (
   Id                   int                  identity,
   UserId               int                  not null,
   WhatId               int                  not null,
   WhatType             nvarchar(20)         not null,
   WhatName             nvarchar(120)        null,
   ViewDate             datetime2            not null default getdate(),
   CreatedOn            datetime2            not null default getdate(),
   CreatedBy            int                  null,
   ChangedOn            datetime2            not null default getdate(),
   ChangedBy            int                  null,
   constraint PK_VIEWED primary key (Id)
)
go

/*==============================================================*/
/* Index: IndexViewedUserWhatWhat                               */
/*==============================================================*/
create index IndexViewedUserWhatWhat on Viewed (
UserId ASC,
WhatId ASC,
WhatType ASC
)
go

/*==============================================================*/
/* Index: IndexViewedWhatWhat                                   */
/*==============================================================*/
create index IndexViewedWhatWhat on Viewed (
WhatId ASC,
WhatType ASC
)
go

alter table Error
   add constraint FK_ERROR_REFERENCE_USER foreign key (UserId)
      references "User" (Id)
go

alter table Login
   add constraint FK_LOGIN_REFERENCE_USER foreign key (UserId)
      references "User" (Id)
go

alter table ThingA
   add constraint FK_THINGA_REFERENCE_THINGB foreign key (ThingBId)
      references ThingB (Id)
go

alter table ThingA
   add constraint FK_CAMPAIGN_REF1_USER foreign key (OwnerId)
      references "User" (Id)
go

alter table ThingA
   add constraint FK_THINGA_REFERENCE_THINGC foreign key (ThingCId)
      references ThingC (Id)
go

alter table ThingB
   add constraint FK_THINGB_REFERENCE_USER foreign key (OwnerId)
      references "User" (Id)
go

alter table ThingC
   add constraint FK_CAMPAIGN_REF2_USER foreign key (OwnerId)
      references "User" (Id)
go

alter table ThingD
   add constraint FK_THINGD_REFERENCE_USER foreign key (OwnerId)
      references "User" (Id)
go

alter table ThingE
   add constraint FK_THINGE_REFERENCE_THINGD foreign key (ThingDId)
      references ThingD (Id)
go

alter table ThingE
   add constraint FK_THINGE_REFERENCE_THINGA foreign key (ThingAId)
      references ThingA (Id)
go

alter table ThingE
   add constraint FK_THINGE_REFERENCE_USER foreign key (OwnerId)
      references "User" (Id)
go

alter table Viewed
   add constraint FK_VIEWED_REFERENCE_USER foreign key (UserId)
      references "User" (Id)
go


/*==============================================================*/
/* Insert data into 'Ultra' database                            */
/*==============================================================*/


SET IDENTITY_INSERT [User] ON
INSERT INTO [User] ([Id],[FirstName],[LastName],[Email],[Alias],[City],[Country],[EmployeeNumber],[Department],[LastLoginDate],[TotalThingsA],[TotalThingsB],[TotalThingsC],[TotalThingsD],[TotalThingsE],[Role],[IdentityId],[IdentityName],[CreatedDate],[ActivationCode],[ActivationDate],[ResetCode],[ResetDate],[AppKey],[AppSecret],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy],[DeletedOn],[DeletedBy],[IsDeleted])VALUES(1,'Debbie','Anderson','debbie@company.com','danderson','New York','USA','21006','Sales','2018-08-29 12:25:50.0875515',28,29,22,25,25,'Admin','9aaf5823-6e45-45ce-b6f8-a78f43faae7b','f9e00f46-859d-4163-ad31-d560a559e919','2017-11-27 16:01:23.8018872','7yt49bb','2017-11-27 17:01:23.8018872',NULL,NULL,NULL,NULL,'2017-11-27 16:01:23.8018872',NULL,'2018-04-15 19:39:37.2599655',1,NULL,NULL,0)
INSERT INTO [User] ([Id],[FirstName],[LastName],[Email],[Alias],[City],[Country],[EmployeeNumber],[Department],[LastLoginDate],[TotalThingsA],[TotalThingsB],[TotalThingsC],[TotalThingsD],[TotalThingsE],[Role],[IdentityId],[IdentityName],[CreatedDate],[ActivationCode],[ActivationDate],[ResetCode],[ResetDate],[AppKey],[AppSecret],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy],[DeletedOn],[DeletedBy],[IsDeleted])VALUES(2,'Ronald','Graef','ronald@company.com','rgraef','New York','USA','21082','Marketing','2017-12-03 18:18:06.8834768',7,9,9,6,6,'Admin','18404d8b-8ab3-4f16-914f-d7db45721174','1f845492-c45d-4f9f-b008-65b62750a7fe','2017-11-27 16:01:24.4014394','ki9tt5wx','2017-11-27 18:01:24.4014394',NULL,NULL,NULL,NULL,'2017-11-27 16:01:24.4014394',NULL,'2017-11-27 16:01:24.4014394',1,NULL,NULL,0)
INSERT INTO [User] ([Id],[FirstName],[LastName],[Email],[Alias],[City],[Country],[EmployeeNumber],[Department],[LastLoginDate],[TotalThingsA],[TotalThingsB],[TotalThingsC],[TotalThingsD],[TotalThingsE],[Role],[IdentityId],[IdentityName],[CreatedDate],[ActivationCode],[ActivationDate],[ResetCode],[ResetDate],[AppKey],[AppSecret],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy],[DeletedOn],[DeletedBy],[IsDeleted])VALUES(3,'Peter','Kuster','peter@company.com','pkuster','Boston','USA','21230','Sales','2017-11-29 10:54:00.9659528',0,0,1,4,3,'User','d9aae1ff-fe0d-4bfa-8e96-b8ed5178bb7c','64aedfdc-8bab-463f-b590-d80d5bc64820','2017-11-29 10:54:00.9659528','rcwpzzw','2017-11-30 10:54:00.9659528','xox88p5','2017-08-21 10:53:02.2365769',NULL,NULL,'2017-11-29 10:54:00.9659528',1,'2017-11-29 10:54:00.9659528',1,NULL,NULL,0)
INSERT INTO [User] ([Id],[FirstName],[LastName],[Email],[Alias],[City],[Country],[EmployeeNumber],[Department],[LastLoginDate],[TotalThingsA],[TotalThingsB],[TotalThingsC],[TotalThingsD],[TotalThingsE],[Role],[IdentityId],[IdentityName],[CreatedDate],[ActivationCode],[ActivationDate],[ResetCode],[ResetDate],[AppKey],[AppSecret],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy],[DeletedOn],[DeletedBy],[IsDeleted])VALUES(4,'Christine','Wirtz','christine@company.com','cwirtz','Los Angeles','USA','21036','Marketing','2017-11-23 10:58:09.3272598',0,0,0,0,0,'User','4a4a3f55-b667-4202-905b-3442db50bfd4','b7deaacc-1169-4e45-9b0b-48cc05f2f914','2017-11-27 18:22:59.5291462','ajt8jur','2017-11-27 18:44:59.5291462',NULL,NULL,NULL,NULL,'2017-11-28 18:22:59.5291462',1,'2017-11-28 18:22:59.5291462',1,NULL,NULL,0)
INSERT INTO [User] ([Id],[FirstName],[LastName],[Email],[Alias],[City],[Country],[EmployeeNumber],[Department],[LastLoginDate],[TotalThingsA],[TotalThingsB],[TotalThingsC],[TotalThingsD],[TotalThingsE],[Role],[IdentityId],[IdentityName],[CreatedDate],[ActivationCode],[ActivationDate],[ResetCode],[ResetDate],[AppKey],[AppSecret],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy],[DeletedOn],[DeletedBy],[IsDeleted])VALUES(5,'Fen E','Hsiung','fene@company.com','fehsiung','Houston','USA','21003','Sales','2017-12-03 11:00:25.1678485',0,0,0,0,0,'User','87279326-ef9a-4e2a-817d-720cec4c8f4e','85accc8b-066c-4fff-b690-96e3f4287d3a','2017-11-27 18:24:39.5854697','7lys3s7','2017-12-03 11:00:10.3723221',NULL,NULL,NULL,NULL,'2017-11-28 18:22:59.5291462',1,'2017-11-28 18:22:59.5291462',1,NULL,NULL,0)
INSERT INTO [User] ([Id],[FirstName],[LastName],[Email],[Alias],[City],[Country],[EmployeeNumber],[Department],[LastLoginDate],[TotalThingsA],[TotalThingsB],[TotalThingsC],[TotalThingsD],[TotalThingsE],[Role],[IdentityId],[IdentityName],[CreatedDate],[ActivationCode],[ActivationDate],[ResetCode],[ResetDate],[AppKey],[AppSecret],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy],[DeletedOn],[DeletedBy],[IsDeleted])VALUES(6,'Troy','Watson','troy@company.com','twatson','Boston','USA','21155','Marketing','2017-12-02 11:02:11.7536277',0,0,0,0,0,'User','95e02adc-4a30-47f6-b63f-1f4bb3502a5d','5f311161-b3eb-47f2-881a-7f0d73dda4d7','2017-11-27 18:27:40.8182170','nkm4b4a','2017-12-02 11:01:55.9457993',NULL,NULL,NULL,NULL,'2017-11-28 18:23:59.5291462',1,'2017-11-28 18:23:59.5291462',1,NULL,NULL,0)
INSERT INTO [User] ([Id],[FirstName],[LastName],[Email],[Alias],[City],[Country],[EmployeeNumber],[Department],[LastLoginDate],[TotalThingsA],[TotalThingsB],[TotalThingsC],[TotalThingsD],[TotalThingsE],[Role],[IdentityId],[IdentityName],[CreatedDate],[ActivationCode],[ActivationDate],[ResetCode],[ResetDate],[AppKey],[AppSecret],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy],[DeletedOn],[DeletedBy],[IsDeleted])VALUES(7,'Henriette','Doiron','henriette@company.com','hdoiron','New York','USA','21036','Sales',NULL,0,0,0,0,0,'User','565f1c4b-21db-4ab9-a9ff-f1383ad8c57e','8ea9ac23-9543-4861-9ed4-fddf2bdb0fde','2017-11-28 11:04:04.0365628','s6nrrq5',NULL,NULL,NULL,NULL,NULL,'2017-11-30 18:22:59.5291462',1,'2017-11-30 18:22:59.5291462',1,NULL,NULL,0)
SET IDENTITY_INSERT [User] OFF

SET IDENTITY_INSERT [ThingB] ON
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(1,'Snowy Slippers','Automobile','Primary',400.00,'2017-12-14 00:00:00.0000000','Silver',334,1,NULL,1,2,'rgraef','2017-12-06 18:15:59.1074037','2017-12-06 18:15:59.1074037',1,'2017-12-07 19:47:07.6402194',1)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(2,'Dapper Clogs','Heaven','Secondary',6500.00,'2017-12-21 00:00:00.0000000','Bronze',800,1,'And Some more',1,1,'danderson','2017-12-06 18:16:32.0853676','2017-12-06 18:16:32.0853676',1,'2017-12-07 19:46:53.8489488',1)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(3,'Stupendous Stop','Shoes','Tertiary',24000.00,NULL,'Gold',NULL,NULL,NULL,3,1,'danderson','2017-12-07 16:15:14.6296662','2017-12-07 16:15:14.6292850',1,'2017-12-07 16:55:20.2269349',1)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(4,'Chilly Plough','Hole','Primary',98000.00,NULL,'Bronze',NULL,1,NULL,2,1,'danderson','2017-12-07 16:15:14.7218902','2017-12-07 16:15:14.7218870',1,'2017-12-07 16:55:12.7075569',1)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(5,'Debonair Jeans','Cracker','Primary',32500.00,NULL,'Silver',NULL,NULL,NULL,2,1,'danderson','2017-12-07 16:15:14.7473421','2017-12-07 16:15:14.7473389',1,'2017-12-07 16:15:14.7473417',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(6,'Deep Vegetable','Queen','Primary',23500.00,NULL,'Silver',NULL,NULL,NULL,2,2,'rgraef','2017-12-07 16:15:14.7524262','2017-12-07 16:15:14.7524233',1,'2017-12-07 16:15:14.7524258',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(7,'Daring Spade','Structure','Tertiary',43900.00,NULL,'Bronze',NULL,NULL,NULL,2,1,'danderson','2017-12-07 16:15:14.7582168','2017-12-07 16:15:14.7582122',1,'2017-12-07 16:15:14.7582164',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(8,'Eight Finger','Chance','Primary',43000.00,NULL,'Silver',NULL,NULL,NULL,2,1,'danderson','2017-12-07 16:15:14.7826941','2017-12-07 16:15:14.7826913',1,'2017-12-07 16:15:14.7826941',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(9,'Wicked Ship','Horses','Tertiary',80000.00,NULL,'Silver',NULL,NULL,NULL,0,2,'rgraef','2017-12-07 16:15:14.8098979','2017-12-07 16:15:14.8098936',1,'2017-12-07 16:15:14.8098975',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(10,'Redundant Fork','Income','Tertiary',83500.00,'2017-12-23 00:00:00.0000000','Platinum',760,NULL,NULL,1,2,'rgraef','2017-12-07 16:15:14.8337598','2017-12-07 16:15:14.8337577',1,'2017-12-07 16:56:38.5072495',1)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(11,'Tiny Sleet','Amusement','Primary',43500.00,NULL,'Platinum',NULL,NULL,NULL,0,1,'danderson','2017-12-07 16:15:14.8580054','2017-12-07 16:15:14.8580019',1,'2017-12-07 16:15:14.8580051',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(12,'Outrageous Current','Lake','Primary',65000.00,NULL,'Silver',NULL,NULL,NULL,2,1,'danderson','2017-12-07 16:15:14.8820113','2017-12-07 16:15:14.8820085',1,'2017-12-07 16:15:14.8820109',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(13,'Responsible Change','Seat','Primary',2300.00,NULL,'Platinum',NULL,NULL,NULL,0,1,'danderson','2017-12-07 16:15:14.9060978','2017-12-07 16:15:14.9060939',1,'2017-12-07 16:15:14.9060975',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(14,'Wiry Death','Yoke','Primary',43600.00,NULL,'Bronze',NULL,NULL,NULL,0,1,'danderson','2017-12-07 16:15:14.9303890','2017-12-07 16:15:14.9303862',1,'2017-12-07 16:40:56.4888986',1)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(15,'Helpless Range','Talk','Tertiary',58000.00,NULL,'Silver',NULL,1,NULL,1,1,'danderson','2017-12-07 16:15:14.9543588','2017-12-07 16:15:14.9543560',1,'2017-12-07 16:56:54.3528648',1)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(16,'Labored Whip','Need','Secondary',8000.00,NULL,'Gold',NULL,NULL,NULL,2,1,'danderson','2017-12-07 16:15:14.9783587','2017-12-07 16:15:14.9783559',1,'2017-12-07 16:15:14.9783583',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(17,'Offbeat Noise','Trees','Tertiary',9800.00,NULL,'Silver',NULL,NULL,NULL,0,1,'danderson','2017-12-07 16:15:15.0024513','2017-12-07 16:15:15.0024319',1,'2017-12-07 16:15:15.0024509',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(18,'Dazzling Behavior','Eye','Primary',56000.00,'2018-02-22 00:00:00.0000000','Platinum',540,NULL,NULL,1,2,'rgraef','2017-12-07 16:15:15.0207298','2017-12-07 16:15:15.0207260',1,'2017-12-07 16:56:49.0757947',1)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(19,'Robust Salt','Anger','Tertiary',30000.00,NULL,'Silver',NULL,NULL,NULL,1,1,'danderson','2017-12-07 16:15:15.0282417','2017-12-07 16:15:15.0282378',1,'2017-12-07 16:15:15.0282410',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(20,'Careless Cause','Addition','Primary',31500.00,NULL,'Gold',NULL,1,NULL,1,1,'danderson','2017-12-07 16:15:15.0526224','2017-12-07 16:15:15.0526188',1,'2017-12-07 16:57:25.1444510',1)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(21,'Sophisticated Bulb','Jellyfish','Tertiary',76000.00,NULL,'Bronze',NULL,NULL,NULL,0,1,'danderson','2017-12-07 16:15:15.0594472','2017-12-07 16:15:15.0594441',1,'2017-12-07 16:15:15.0594469',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(22,'Likeable Sweater','Believe','Primary',76000.00,NULL,'Gold',NULL,NULL,NULL,1,1,'danderson','2017-12-07 16:15:15.0834203','2017-12-07 16:15:15.0834178',1,'2017-12-07 16:15:15.0834199',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(23,'Acoustic Cabbage','Bridge','Primary',43000.00,NULL,'Gold',NULL,NULL,NULL,2,2,'rgraef','2017-12-07 16:15:15.1077492','2017-12-07 16:15:15.1077467',1,'2017-12-07 16:15:15.1077488',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(24,'Wasteful Door','Train','Primary',66500.00,NULL,'Silver',NULL,NULL,NULL,2,1,'danderson','2017-12-07 16:15:15.1317677','2017-12-07 16:15:15.1317642',1,'2017-12-07 16:15:15.1317674',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(25,'Assorted Chickens','Flavor','Secondary',2800.00,NULL,'Gold',NULL,NULL,NULL,1,2,'rgraef','2017-12-07 16:15:15.1557463','2017-12-07 16:15:15.1557442',1,'2017-12-07 16:15:15.1557463',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(26,'Alert Sugar','Toes','Secondary',12500.00,NULL,'Platinum',NULL,NULL,NULL,1,2,'rgraef','2017-12-07 16:15:15.1611400','2017-12-07 16:15:15.1611376',1,'2017-12-07 16:15:15.1611400',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(27,'Successful Plant','Bells','Primary',29000.00,NULL,'Silver',NULL,NULL,NULL,1,1,'danderson','2017-12-07 16:15:15.1859403','2017-12-07 16:15:15.1859378',1,'2017-12-07 16:15:15.1859399',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(28,'Addicted Needle','Pest','Tertiary',6000.00,NULL,'Platinum',NULL,NULL,NULL,0,2,'rgraef','2017-12-07 16:15:15.2142513','2017-12-07 16:15:15.2142481',1,'2017-12-07 16:15:15.2142509',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(29,'Protective Reaction','Berry','Secondary',67000.00,NULL,'Bronze',NULL,NULL,NULL,1,1,'danderson','2017-12-07 16:15:15.2203364','2017-12-07 16:15:15.2203315',1,'2017-12-07 16:15:15.2203361',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(30,'Selective Dirt','Ducks','Primary',4500.00,NULL,'Silver',NULL,NULL,NULL,1,1,'danderson','2017-12-07 16:15:15.2461949','2017-12-07 16:15:15.2461900',1,'2017-12-07 16:15:15.2461942',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(31,'Uninterested Channel','Crime','Tertiary',94500.00,NULL,'Gold',NULL,NULL,NULL,1,1,'danderson','2017-12-07 16:15:15.2522993','2017-12-07 16:15:15.2522962',1,'2017-12-07 16:15:15.2522990',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(32,'Gorgeous Sock','Club','Primary',6500.00,NULL,'Silver',NULL,NULL,NULL,0,1,'danderson','2017-12-07 16:15:15.2581155','2017-12-07 16:15:15.2581126',1,'2017-12-07 16:15:15.2581155',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(33,'Tiresome Afterthought','Coast','Secondary',67000.00,NULL,'Silver',NULL,NULL,NULL,0,1,'danderson','2017-12-07 16:15:15.2829693','2017-12-07 16:15:15.2829665',1,'2017-12-07 16:15:15.2829690',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(34,'Illustrious Request','Ghost','Tertiary',92000.00,NULL,'Gold',NULL,NULL,NULL,0,1,'danderson','2017-12-07 16:15:15.3073268','2017-12-07 16:15:15.3073232',1,'2017-12-07 16:15:15.3073264',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(35,'Deafening Page','War','Secondary',24500.00,'2017-12-28 00:00:00.0000000','Platinum',350,1,NULL,0,1,'danderson','2017-12-07 16:15:15.3136890','2017-12-07 16:15:15.3136844',1,'2017-12-07 18:02:22.4435146',1)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(36,'Numerous End','Walk','Primary',9200.00,NULL,'Silver',NULL,NULL,NULL,0,1,'danderson','2017-12-07 16:15:15.3210509','2017-12-07 16:15:15.3210481',1,'2017-12-07 16:15:15.3210506',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(37,'Lopsided Money','Bucket','Primary',9900.00,NULL,'Gold',NULL,NULL,NULL,0,1,'danderson','2017-12-07 16:15:15.3453269','2017-12-07 16:15:15.3453219',1,'2017-12-07 16:15:15.3453265',NULL)
INSERT INTO [ThingB] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(38,'Sad Lake','Hook','Primary',61000.00,'2018-02-21 00:00:00.0000000','Silver',NULL,NULL,NULL,0,1,'danderson','2017-12-07 16:15:15.3513372','2017-12-07 16:15:15.3513337',1,'2017-12-07 18:02:11.9732859',1)
SET IDENTITY_INSERT [ThingB] OFF

SET IDENTITY_INSERT [ThingC] ON
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(1,'Hot Gingerman','Rooftop','Protected',5490.00,'2017-12-27 00:00:00.0000000','Complete',1,1,'Some long text here',2,'2017-12-06 20:40:54.2041881',1,'danderson','2017-12-06 20:40:54.2041881',1,'2017-12-07 20:13:12.5225136',1)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(2,'Temporal Kittens','Cow','Public',31500.00,'2017-12-28 00:00:00.0000000','In Review',3,0,'Some long text here',0,'2017-12-06 20:55:22.4517219',1,'danderson','2017-12-06 20:55:22.4517219',1,'2017-12-07 20:13:04.1283600',1)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(3,'Bustling Pot','Hill','Private',81000.00,'2017-12-28 00:00:00.0000000','In Review',2,0,'Some long text here',1,'2017-12-07 16:21:04.8405840',1,'danderson','2017-12-07 16:21:04.8402532',1,'2017-12-07 16:21:04.8404722',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(4,'Long-Term Yam','Control','Protected',45000.00,'2017-12-28 00:00:00.0000000','Complete',3,0,'Some long text here',0,'2017-12-07 16:21:04.9263466',1,'danderson','2017-12-07 16:21:04.9263431',1,'2017-12-07 16:21:04.9263462',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(5,'Groomed Cannon','Frame','Protected',54000.00,'2017-12-28 00:00:00.0000000','Complete',4,1,'Some long text here',2,'2017-12-07 16:21:04.9376991',1,'danderson','2017-12-07 16:21:04.9376952',1,'2017-12-07 16:21:04.9376987',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(6,'Blushing Car','Rock','Public',4600.00,'2017-12-28 00:00:00.0000000','Pending',3,0,'Some long text here',3,'2017-12-07 16:21:04.9477669',2,'rgraef','2017-12-07 16:21:04.9477634',1,'2017-12-07 16:21:04.9477666',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(7,'Supreme Wash','Punishment','Private',31000.00,'2017-12-28 00:00:00.0000000','In Review',3,1,'Some long text here',0,'2017-12-07 16:21:04.9667996',2,'rgraef','2017-12-07 16:21:04.9667960',1,'2017-12-07 16:21:04.9667992',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(8,'Tangible Spot','Parcel','Protected',56500.00,'2017-12-28 00:00:00.0000000','Pending',4,0,'Some long text here',0,'2017-12-07 16:21:05.0844457',1,'danderson','2017-12-07 16:21:05.0844422',1,'2017-12-07 16:21:05.0844453',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(9,'Other Wish','Chess','Protected',41000.00,'2017-12-28 00:00:00.0000000','In Review',3,0,'Some long text here',2,'2017-12-07 16:21:05.1066138',1,'danderson','2017-12-07 16:21:05.1066102',1,'2017-12-07 16:21:05.1066134',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(10,'Wandering Tree','Pail','Protected',77000.00,'2017-12-28 00:00:00.0000000','Complete',0,1,'Some long text here',1,'2017-12-07 16:21:05.1197536',1,'danderson','2017-12-07 16:21:05.1197501',1,'2017-12-07 16:21:05.1197533',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(11,'Unequaled Bulb','Run','Private',43500.00,'2017-12-28 00:00:00.0000000','Complete',6,1,'Some long text here',0,'2017-12-07 16:21:05.1490452',2,'rgraef','2017-12-07 16:21:05.1490417',1,'2017-12-07 16:21:05.1490449',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(12,'Cute Dust','Achiever','Public',12000.00,'2017-12-28 00:00:00.0000000','Pending',4,0,'Some long text here',1,'2017-12-07 16:21:05.1639218',1,'danderson','2017-12-07 16:21:05.1639186',1,'2017-12-07 16:21:05.1639214',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(13,'Earthy Magic','Volcano','Protected',6000.00,'2017-12-28 00:00:00.0000000','In Review',3,0,'Some long text here',1,'2017-12-07 16:21:05.1710412',2,'rgraef','2017-12-07 16:21:05.1710369',1,'2017-12-07 16:21:05.1710408',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(14,'Hot Debt','Apparatus','Private',54600.00,'2017-12-28 00:00:00.0000000','Pending',3,0,'Some long text here',0,'2017-12-07 16:21:05.1801221',2,'rgraef','2017-12-07 16:21:05.1801182',1,'2017-12-07 16:21:05.1801217',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(15,'Unbecoming Badge','Seat','Protected',70000.00,'2017-12-28 00:00:00.0000000','Complete',4,1,'Some long text here',2,'2017-12-07 16:21:05.2051269',1,'danderson','2017-12-07 16:21:05.2051237',1,'2017-12-07 16:21:05.2051265',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(16,'Harsh Pollution','Blood','Private',44050.00,'2017-12-28 00:00:00.0000000','In Review',1,1,'Some long text here',1,'2017-12-07 16:21:05.2120607',1,'danderson','2017-12-07 16:21:05.2120576',1,'2017-12-07 16:21:05.2120604',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(17,'Small Ear','Thumb','Protected',54700.00,'2017-12-28 00:00:00.0000000','Pending',1,0,'Some long text here',2,'2017-12-07 16:21:05.2195123',1,'danderson','2017-12-07 16:21:05.2195091',1,'2017-12-07 16:21:05.2195120',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(18,'Slow Rock','Power','Private',38800.00,'2017-12-28 00:00:00.0000000','Pending',2,0,'Some long text here',0,'2017-12-07 16:21:05.2288839',1,'danderson','2017-12-07 16:21:05.2288807',1,'2017-12-07 16:21:05.2288835',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(19,'Wiggly Arithmetic','Knife','Public',35600.00,'2017-12-28 00:00:00.0000000','Complete',1,1,'Some long text here',1,'2017-12-07 16:21:05.2503949',1,'danderson','2017-12-07 16:21:05.2503914',1,'2017-12-07 16:21:05.2503945',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(20,'Long Shirt','Mine','Protected',21600.00,'2017-12-28 00:00:00.0000000','In Review',0,1,'Some long text here',2,'2017-12-07 16:21:05.2716182',2,'rgraef','2017-12-07 16:21:05.2716143',1,'2017-12-07 16:21:05.2716179',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(21,'Sparkling Shop','Meeting','Private',1200.00,'2017-12-28 00:00:00.0000000','Pending',8,0,'Some long text here',1,'2017-12-07 16:21:05.3176045',1,'danderson','2017-12-07 16:21:05.3176013',1,'2017-12-07 16:21:05.3176042',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(22,'Left Cake','Smash','Public',37700.00,'2017-12-28 00:00:00.0000000','Complete',0,1,'Some long text here',1,'2017-12-07 16:21:05.3286625',1,'danderson','2017-12-07 16:21:05.3286579',1,'2017-12-07 16:21:05.3286622',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(23,'Breezy Waste','Girls','Public',6500.00,'2017-12-28 00:00:00.0000000','In Review',6,0,'Some long text here',4,'2017-12-07 16:21:05.3387230',2,'rgraef','2017-12-07 16:21:05.3387181',1,'2017-12-07 16:21:05.3387227',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(24,'Hilarious Lunchroom','Carriage','Private',45900.00,'2017-12-28 00:00:00.0000000','Pending',4,1,'Some long text here',1,'2017-12-07 16:21:05.3483407',1,'danderson','2017-12-07 16:21:05.3483365',1,'2017-12-07 16:21:05.3483403',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(25,'Polite Mice','Writing','Protected',54000.00,'2017-12-28 00:00:00.0000000','Complete',7,0,'Some long text here',2,'2017-12-07 16:21:05.3579012',3,'pkuster','2017-12-07 16:21:05.3578980',1,'2017-12-07 16:21:05.3579009',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(26,'Gaping Limit','Relation','Protected',2200.00,'2017-12-28 00:00:00.0000000','Pending',3,0,'Some long text here',0,'2017-12-07 16:21:05.3688690',1,'danderson','2017-12-07 16:21:05.3688655',1,'2017-12-07 16:21:05.3688687',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(27,'Awkward Finger','Measure','Protected',23800.00,'2017-12-28 00:00:00.0000000','Complete',2,0,'Some long text here',1,'2017-12-07 16:21:05.3852340',2,'rgraef','2017-12-07 16:21:05.3852308',1,'2017-12-07 16:21:05.3852336',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(28,'Domineering Rail','Book','Private',54000.00,'2017-12-28 00:00:00.0000000','Complete',1,1,'Some long text here',1,'2017-12-07 16:21:05.3976483',1,'danderson','2017-12-07 16:21:05.3976444',1,'2017-12-07 16:21:05.3976480',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(29,'Pastoral Impulse','Pancake','Protected',90800.00,'2017-12-28 00:00:00.0000000','In Review',2,0,'Some long text here',0,'2017-12-07 16:21:05.4248647',1,'danderson','2017-12-07 16:21:05.4248618',1,'2017-12-07 16:21:05.4248643',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(30,'Macho Cherries','Kick','Protected',5400.00,'2017-12-28 00:00:00.0000000','Pending',0,1,'Some long text here',1,'2017-12-07 16:21:05.4484767',2,'rgraef','2017-12-07 16:21:05.4484746',1,'2017-12-07 16:21:05.4484767',NULL)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(31,'Ossified Bone','Science','Private',60000.00,'2017-12-28 00:00:00.0000000','In Review',0,1,'Some long text here',1,'2017-12-07 16:21:05.4726475',1,'danderson','2017-12-07 16:21:05.4726447',1,'2017-12-07 18:02:35.9563712',1)
INSERT INTO [ThingC] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsA],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(32,'Unequal Mother','Marble','Private',45000.00,'2017-12-28 00:00:00.0000000','Pending',4,1,'Some long text here',1,'2017-12-07 16:21:05.4816815',1,'danderson','2017-12-07 16:21:05.4816773',1,'2017-12-07 17:28:25.7273296',1)
SET IDENTITY_INSERT [ThingC] OFF

SET IDENTITY_INSERT [ThingA] ON
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(2,'After Goodies',1,'Snowy Slippers',22,'Left Cake','Normal','High',3400.00,'2017-12-28 00:00:00.0000000','In Progress',300,1,'This is long text',0,'2017-12-07 00:00:00.0000000',1,'danderson','2017-12-06 17:14:13.1964068',1,'2017-12-06 21:06:39.4128314',1)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(3,'Second Outing',4,'Chilly Plough',13,'Earthy Magic','Burly','Medium',2500.00,'2017-12-29 00:00:00.0000000','Approved',1700,1,'This is long text',2,'2017-12-07 00:00:00.0000000',1,'danderson','2017-12-06 18:23:23.9997962',1,'2017-12-06 21:10:51.9044774',1)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(4,'Cuddly Tiger',5,'Debonair Jeans',23,'Breezy Waste','Receipt','High',3400.00,'2017-12-22 00:00:00.0000000','Submitted',400,0,'This is long text',2,'2017-12-07 14:11:54.0169505',2,'rgraef','2017-12-07 14:11:54.0164269',1,'2017-12-07 14:11:54.0167171',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(5,'Rebel Scissors',23,'Acoustic Cabbage',25,'Polite Mice','Snail','Low',2000.00,'2017-12-22 00:00:00.0000000','Rejected',500,0,'This is long text',0,'2017-12-07 14:11:54.0772798',1,'danderson','2017-12-07 14:11:54.0772770',1,'2017-12-07 14:11:54.0772798',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(6,'Ugliest Basket',31,'Uninterested Channel',17,'Small Ear','Afterhought','High',8000.00,'2018-04-22 00:00:00.0000000','In Progress',400,1,'This is long text',3,'2017-12-07 00:00:00.0000000',2,'rgraef','2017-12-07 14:11:54.0841569',1,'2017-12-07 14:26:17.5580825',1)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(7,'Friendly Daughter',24,'Wasteful Door',16,'Harsh Pollution','Downtown','High',4700.00,'2017-12-22 00:00:00.0000000','Submitted',340,NULL,'This is long text',4,'2017-12-07 14:11:54.0907012',1,'danderson','2017-12-07 14:11:54.0906980',1,'2017-12-07 14:11:54.0907008',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(8,'Ten Bite',7,'Daring Spade',6,'Blushing Car','Observation','Medium',8750.00,'2017-12-22 00:00:00.0000000','In Progress',650,0,'This is long text',2,'2017-12-07 14:11:54.1163238',1,'danderson','2017-12-07 14:11:54.1163203',1,'2017-12-07 14:11:54.1163231',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(9,'Depressed Desk',3,'Stupendous Stop',5,'Groomed Cannon','Beginner','High',9900.00,'2017-12-22 00:00:00.0000000','Submitted',55,0,'This is long text',1,'2017-12-07 14:11:54.1224977',1,'danderson','2017-12-07 14:11:54.1224945',1,'2017-12-07 14:11:54.1224974',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(10,'Same Clover',3,'Stupendous Stop',27,'Awkward Finger','Coal','Low',340.00,'2017-12-22 00:00:00.0000000','Declined',650,0,'This is long text',3,'2017-12-07 14:11:54.1288011',1,'danderson','2017-12-07 14:11:54.1287975',1,'2017-12-07 14:11:54.1288007',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(11,'Bad Sky',30,'Selective Dirt',23,'Breezy Waste','Car','High',1300.00,'2017-12-22 00:00:00.0000000','In Progress',990,0,'This is long text',0,'2017-12-07 14:11:54.1352519',1,'danderson','2017-12-07 14:11:54.1352491',1,'2017-12-07 14:11:54.1352515',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(12,'Glamorous Eyes',27,'Successful Plant',10,'Wandering Tree','Wind','High',2544.00,'2017-12-22 00:00:00.0000000','In Progress',900,0,'This is long text',2,'2017-12-07 14:11:54.1424104',2,'rgraef','2017-12-07 14:11:54.1424072',1,'2017-12-07 14:11:54.1424100',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(13,'Gullible Lunch',26,'Alert Sugar',20,'Long Shirt','Airport','Medium',4590.00,'2017-12-26 00:00:00.0000000','Not Started',760,1,'This is long text',0,'2017-12-07 00:00:00.0000000',1,'danderson','2017-12-07 14:11:54.1484137',1,'2017-12-07 14:26:35.9090658',1)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(14,'Rough Agreement',12,'Outrageous Current',9,'Other Wish','Insurance','Low',6500.00,'2017-12-22 00:00:00.0000000','Submitted',450,1,'This is long text',1,'2017-12-07 14:11:54.1547358',1,'danderson','2017-12-07 14:11:54.1547326',1,'2017-12-07 14:11:54.1547354',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(15,'Demonic Plantation',15,'Helpless Range',6,'Blushing Car','Morning','High',5400.00,'2017-12-22 00:00:00.0000000','Submitted',540,1,'This is long text',1,'2017-12-07 14:11:54.1613661',1,'danderson','2017-12-07 14:11:54.1613625',1,'2017-12-07 14:11:54.1613657',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(16,'Changeable Statement',3,'Stupendous Stop',6,'Blushing Car','Arithmetic','Medium',4390.00,'2017-12-22 00:00:00.0000000','Submitted',320,0,'This is long text',1,'2017-12-07 14:11:54.1698733',1,'danderson','2017-12-07 14:11:54.1698697',1,'2017-12-07 14:11:54.1698729',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(17,'Miscreant Grandmother',2,'Dapper Clogs',1,'Hot Gingerman','Jar','High',4680.00,'2017-12-22 00:00:00.0000000','In Progress',20,1,'This is long text',0,'2017-12-07 14:11:54.1781062',1,'danderson','2017-12-07 14:11:54.1781030',1,'2017-12-07 14:11:54.1781058',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(18,'Worried Mine',16,'Labored Whip',23,'Breezy Waste','Chance','High',5460.00,'2017-12-22 00:00:00.0000000','In Progress',80,1,'This is long text',0,'2017-12-07 00:00:00.0000000',1,'danderson','2017-12-07 14:11:54.1850235',1,'2017-12-07 18:06:26.0667803',1)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(19,'Mute Sound',25,'Assorted Chickens',30,'Macho Cherries','Horse','High',5550.00,'2017-12-22 00:00:00.0000000','Approved',560,1,'This is long text',0,'2017-12-07 14:11:54.2120110',1,'danderson','2017-12-07 14:11:54.2120082',1,'2017-12-07 14:11:54.2120107',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(20,'Caring Foot',20,'Careless Cause',32,'Unequal Mother','Unit','Medium',8100.00,'2017-12-22 00:00:00.0000000','Submitted',950,0,'This is long text',1,'2017-12-07 14:11:54.2230561',2,'rgraef','2017-12-07 14:11:54.2230529',1,'2017-12-07 14:11:54.2230557',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(21,'Two Discussions',16,'Labored Whip',23,'Breezy Waste','Store','High',9360.00,'2017-12-27 00:00:00.0000000','Not Started',730,NULL,'This is long text',2,'2017-12-07 00:00:00.0000000',1,'danderson','2017-12-07 14:11:54.2399455',1,'2017-12-07 17:53:35.1224491',1)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(22,'Dispensable Grade',12,'Outrageous Current',24,'Hilarious Lunchroom','Channel','Low',8830.00,'2017-12-22 00:00:00.0000000','Submitted',700,1,'This is long text',1,'2017-12-07 14:11:54.2464780',2,'rgraef','2017-12-07 14:11:54.2464737',1,'2017-12-07 14:11:54.2464776',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(23,'Truthful Thumb',10,'Redundant Fork',15,'Unbecoming Badge','Skin','Medium',120.00,'2017-12-22 00:00:00.0000000','Not Started',60,1,'This is long text',1,'2017-12-07 14:11:54.2717811',1,'danderson','2017-12-07 14:11:54.2717776',1,'2017-12-07 14:11:54.2717804',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(24,'Mean Eye',4,'Chilly Plough',12,'Cute Dust','Bone','High',3420.00,'2017-12-22 00:00:00.0000000','In Progress',65,1,'This is long text',0,'2017-12-07 14:11:54.2772901',1,'danderson','2017-12-07 14:11:54.2772851',1,'2017-12-07 14:11:54.2772897',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(25,'Unbecoming Middle',7,'Daring Spade',20,'Long Shirt','Liquid','Low',5548.00,'2017-12-22 00:00:00.0000000','Approved',648,0,'This is long text',1,'2017-12-07 14:11:54.3027381',1,'danderson','2017-12-07 14:11:54.3027332',1,'2017-12-07 14:11:54.3027378',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(26,'Watery Chance',8,'Eight Finger',19,'Wiggly Arithmetic','Pollution','High',4730.00,'2017-12-22 00:00:00.0000000','Approved',290,1,'This is long text',0,'2017-12-07 14:11:54.3271167',1,'danderson','2017-12-07 14:11:54.3271114',1,'2017-12-07 14:11:54.3271163',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(27,'Tested Regret',22,'Likeable Sweater',5,'Groomed Cannon','Coat','High',3500.00,'2017-12-22 00:00:00.0000000','In Progress',100,1,'This is long text',0,'2017-12-07 14:11:54.3320628',1,'danderson','2017-12-07 14:11:54.3320575',1,'2017-12-07 14:11:54.3320625',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(28,'Faint Argument',19,'Robust Salt',9,'Other Wish','Basketball','Low',4280.00,'2017-12-22 00:00:00.0000000','Submitted',540,1,'This is long text',1,'2017-12-07 14:11:54.3370108',1,'danderson','2017-12-07 14:11:54.3370069',1,'2017-12-07 14:11:54.3370104',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(29,'Utter Quartz',29,'Protective Reaction',17,'Small Ear','Minute','Medium',560.00,'2017-12-22 00:00:00.0000000','Not Started',65,1,'This is long text',0,'2017-12-07 14:11:54.3422633',1,'danderson','2017-12-07 14:11:54.3422605',1,'2017-12-07 14:11:54.3422630',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(30,'Grieving Title',23,'Acoustic Cabbage',25,'Polite Mice','Tree','High',870.00,'2017-12-22 00:00:00.0000000','Not Started',70,1,'This is long text',2,'2017-12-07 14:11:54.3473030',2,'rgraef','2017-12-07 14:11:54.3472998',1,'2017-12-07 14:11:54.3473026',NULL)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(31,'Squalid Join',24,'Wasteful Door',21,'Sparkling Shop','Language','Medium',5600.00,'2017-12-22 00:00:00.0000000','Approved',98,NULL,'This is long text',1,'2017-12-07 00:00:00.0000000',1,'danderson','2017-12-07 14:11:54.3530714',1,'2017-12-07 15:12:39.6751434',1)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(32,'Awful Drop',6,'Deep Vegetable',3,'Bustling Pot','Face','Low',1950.00,'2018-03-13 00:00:00.0000000','Approved',100,1,'This is long text',0,'2017-12-07 00:00:00.0000000',1,'danderson','2017-12-07 14:11:54.3589045',1,'2017-12-07 14:35:01.4798814',1)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(33,'Handsomely Minister',18,'Dazzling Behavior',28,'Domineering Rail','Head','High',990.00,'2018-04-19 00:00:00.0000000','Submitted',99,1,'This is long text',1,'2017-12-07 00:00:00.0000000',1,'danderson','2017-12-07 14:11:54.3639951',1,'2017-12-07 16:35:06.8013180',1)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(34,'Puffy Battle',6,'Deep Vegetable',1,'Hot Gingerman','Powder','High',1800.00,'2017-12-30 00:00:00.0000000','Not Started',120,NULL,'This is long text',1,'2017-12-07 00:00:00.0000000',1,'danderson','2017-12-07 14:11:54.3690266',1,'2017-12-07 16:34:52.7199871',1)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(35,'Deranged Cable',5,'Debonair Jeans',15,'Unbecoming Badge','Lunch','High',3400.00,'2018-02-21 00:00:00.0000000','Declined',450,1,'This is long text',0,'2017-12-07 00:00:00.0000000',1,'danderson','2017-12-07 14:11:54.3739305',1,'2017-12-07 16:34:40.2735078',1)
INSERT INTO [ThingA] ([Id],[Name],[ThingBId],[ThingBName],[ThingCId],[ThingCName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[CreatedDate],[OwnerId],[OwnerAlias],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(36,'Swanky Waves',8,'Eight Finger',31,'Ossified Bone','Ground','Medium',566.00,'2017-12-30 00:00:00.0000000','Not Started',400,NULL,'This is long text',0,'2017-12-07 00:00:00.0000000',1,'danderson','2017-12-07 14:11:54.3803506',1,'2017-12-07 16:34:13.6843336',1)
SET IDENTITY_INSERT [ThingA] OFF

SET IDENTITY_INSERT [ThingD] ON
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(1,'Sad Tremble','Telephone','Email',54000.00,'2017-12-19 00:00:00.0000000','Senior',912,1,'Some longer text here',1,1,'danderson','2017-12-06 21:53:15.8847889','2017-12-06 21:53:15.8847889',1,'2017-12-07 20:13:57.7469482',1)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(2,'Green Plate','Curry','Referral',4300.00,'2017-12-21 00:00:00.0000000','Senior',2,0,'Some longer text here',1,1,'danderson','2017-12-06 21:54:51.7857162','2017-12-06 21:54:51.7857162',1,'2017-12-07 20:13:40.4443986',1)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(3,'Possible Form','Jeans','Email',460.00,'2017-12-28 00:00:00.0000000','Junior',4,0,'Some longer text here',2,2,'rgraef','2017-12-07 16:25:05.7044113','2017-12-07 16:25:05.7041581',1,'2017-12-07 16:25:05.7043073',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(4,'Dreary Reason','Camera','Website',1200.00,'2017-12-28 00:00:00.0000000','Architect',34,1,'Some longer text here',0,1,'danderson','2017-12-07 16:25:05.8223265','2017-12-07 16:25:05.8223170',1,'2017-12-07 17:47:03.4908253',1)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(5,'Far Tooth','Jump','Referral',1000.00,'2017-12-28 00:00:00.0000000','Manager',5,1,'Some longer text here',5,1,'danderson','2017-12-07 16:25:05.8619526','2017-12-07 16:25:05.8619469',1,'2017-12-07 16:25:05.8619519',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(6,'Early Cattle','Growth','Referral',5450.00,'2017-12-28 00:00:00.0000000','Manager',73,1,'Some longer text here',1,1,'danderson','2017-12-07 16:25:05.8926462','2017-12-07 16:25:05.8926409',1,'2017-12-07 16:25:05.8926455',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(7,'Outrageous Geese','Spring','Email',31900.00,'2017-12-28 00:00:00.0000000','Junior',88,0,'Some longer text here',0,1,'danderson','2017-12-07 16:25:05.9052011','2017-12-07 16:25:05.9051972',1,'2017-12-07 16:25:05.9052004',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(8,'Makeshift Chalk','Reward','Meeting',320.00,'2017-12-28 00:00:00.0000000','Architect',90,1,'Some longer text here',0,2,'rgraef','2017-12-07 16:25:05.9300691','2017-12-07 16:25:05.9300663',1,'2017-12-07 16:25:05.9300688',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(9,'Wholesale View','Twig','Referral',2490.00,'2017-12-28 00:00:00.0000000','Manager',20,1,'Some longer text here',0,3,'pkuster','2017-12-07 16:25:05.9541611','2017-12-07 16:25:05.9541582',1,'2017-12-07 16:25:05.9541607',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(10,'White Legs','Crown','Website',12000.00,'2017-12-28 00:00:00.0000000','Architect',21,0,'Some longer text here',0,1,'danderson','2017-12-07 16:25:05.9851486','2017-12-07 16:25:05.9851384',1,'2017-12-07 16:25:05.9851472',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(11,'Strange Snails','Move','Meeting',10000.00,'2017-12-28 00:00:00.0000000','Senior',2,1,'Some longer text here',1,1,'danderson','2017-12-07 16:25:06.0225568','2017-12-07 16:25:06.0225515',1,'2017-12-07 16:25:06.0225561',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(12,'Minor Corn','Shake','Referral',430.00,'2017-12-28 00:00:00.0000000','Junior',0,0,'Some longer text here',2,2,'rgraef','2017-12-07 16:25:06.0495666','2017-12-07 16:25:06.0495638',1,'2017-12-07 16:25:06.0495663',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(13,'Picayune Governor','Creator','Email',4290.00,'2017-12-28 00:00:00.0000000','Architect',0,1,'Some longer text here',0,3,'pkuster','2017-12-07 16:25:06.0776367','2017-12-07 16:25:06.0776279',1,'2017-12-07 16:25:06.0776349',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(14,'Salty Milk','Fog','Meeting',430.00,'2017-12-28 00:00:00.0000000','Junior',56,0,'Some longer text here',3,1,'danderson','2017-12-07 16:25:06.0892713','2017-12-07 16:25:06.0892664',1,'2017-12-07 16:25:06.0892706',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(15,'Disgusted Alarm','Sticks','Referral',3490.00,'2017-12-28 00:00:00.0000000','Senior',4,1,'Some longer text here',3,1,'danderson','2017-12-07 16:25:06.0968100','2017-12-07 16:25:06.0968061',1,'2017-12-07 16:25:06.0968096',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(16,'Zany Roll','Mind','Referral',7100.00,'2017-12-28 00:00:00.0000000','Manager',38,1,'Some longer text here',1,1,'danderson','2017-12-07 16:25:06.1064822','2017-12-07 16:25:06.1064744',1,'2017-12-07 16:25:06.1064815',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(17,'Distinct Sail','Fire','Meeting',4370.00,'2017-12-28 00:00:00.0000000','Architect',87,0,'Some longer text here',0,3,'pkuster','2017-12-07 16:25:06.1385348','2017-12-07 16:25:06.1385133',1,'2017-12-07 16:25:06.1385334',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(18,'Resonant Team','Snake','Website',9090.00,'2017-12-28 00:00:00.0000000','Junior',6,1,'Some longer text here',2,1,'danderson','2017-12-07 16:25:06.1668259','2017-12-07 16:25:06.1668210',1,'2017-12-07 16:25:06.1668252',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(19,'Flaky Shade','Fog','Website',900.00,'2017-12-28 00:00:00.0000000','Architect',81,0,'Some longer text here',2,3,'pkuster','2017-12-07 16:25:06.1918113','2017-12-07 16:25:06.1918082',1,'2017-12-07 16:25:06.1918110',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(20,'Equal Bath','Reason','Referral',320.00,'2017-12-28 00:00:00.0000000','Manager',18,1,'Some longer text here',3,2,'rgraef','2017-12-07 16:25:06.2004208','2017-12-07 16:25:06.2004177',1,'2017-12-07 16:25:06.2004205',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(21,'Immense Error','Pest','Meeting',490.00,'2017-12-28 00:00:00.0000000','Architect',90,1,'Some longer text here',0,1,'danderson','2017-12-07 16:25:06.2248572','2017-12-07 16:25:06.2248537',1,'2017-12-07 16:25:06.2248569',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(22,'Thirsty Butter','Cherries','Email',9800.00,'2017-12-28 00:00:00.0000000','Senior',30,0,'Some longer text here',1,1,'danderson','2017-12-07 16:25:06.2538209','2017-12-07 16:25:06.2538124',1,'2017-12-07 16:25:06.2538198',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(23,'Disillusioned End','Pie','Website',21000.00,'2017-12-28 00:00:00.0000000','Senior',39,1,'Some longer text here',0,1,'danderson','2017-12-07 16:25:06.2879829','2017-12-07 16:25:06.2879762',1,'2017-12-07 16:25:06.2879818',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(24,'Hungry Caption','Scene','Referral',3260.00,'2017-12-28 00:00:00.0000000','Manager',31,0,'Some longer text here',2,2,'rgraef','2017-12-07 16:25:06.3264302','2017-12-07 16:25:06.3264235',1,'2017-12-07 16:25:06.3264291',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(25,'Violent Plant','Mask','Meeting',3700.00,'2017-12-28 00:00:00.0000000','Architect',6,1,'Some longer text here',0,1,'danderson','2017-12-07 16:25:06.3401054','2017-12-07 16:25:06.3401011',1,'2017-12-07 16:25:06.3401050',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(26,'Longing Fold','Aunt','Website',5450.00,'2017-12-28 00:00:00.0000000','Manager',65,0,'Some longer text here',1,2,'rgraef','2017-12-07 16:25:06.3661962','2017-12-07 16:25:06.3661934',1,'2017-12-07 16:25:06.3661958',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(27,'Blue-Eyed Grip','Branch','Email',4500.00,'2017-12-28 00:00:00.0000000','Senior',47,0,'Some longer text here',2,1,'danderson','2017-12-07 16:25:06.3939556','2017-12-07 16:25:06.3939454',1,'2017-12-07 16:25:06.3939535',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(28,'Spiteful Design','Air','Referral',100.00,'2017-12-28 00:00:00.0000000','Architect',9,1,'Some longer text here',0,1,'danderson','2017-12-07 16:25:06.4340948','2017-12-07 16:25:06.4340860',1,'2017-12-07 16:25:06.4340934',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(29,'Oceanic Arm','Vessel','Website',76000.00,'2017-12-28 00:00:00.0000000','Manager',34,1,'Some longer text here',1,1,'danderson','2017-12-07 16:25:06.4685786','2017-12-07 16:25:06.4685688',1,'2017-12-07 16:25:06.4685772',NULL)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(30,'Miniature Sleet','Wine','Referral',4360.00,'2017-12-28 00:00:00.0000000','Junior',61,1,'Some longer text here',0,1,'danderson','2017-12-07 16:25:06.5059222','2017-12-07 16:25:06.5059131',1,'2017-12-07 17:44:10.8809195',1)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(31,'Necessary Lettuce','Bushes','Website',4850.00,'2017-12-28 00:00:00.0000000','Manager',12,0,'Some longer text here',0,1,'danderson','2017-12-07 16:25:06.5398176','2017-12-07 16:25:06.5398099',1,'2017-12-07 17:44:00.1537449',1)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(32,'Bad Hour','Year','Meeting',1950.00,'2017-12-28 00:00:00.0000000','Architect',32,0,'Some longer text here',0,1,'danderson','2017-12-07 16:25:06.5600575','2017-12-07 16:25:06.5600511',1,'2017-12-07 17:43:47.9527537',1)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(33,'Dizzy Toothbrush','Canvas','Website',7350.00,'2017-12-28 00:00:00.0000000','Senior',46,1,'Some longer text here',0,1,'danderson','2017-12-07 16:25:06.6029323','2017-12-07 16:25:06.6029238',1,'2017-12-07 17:43:39.0264761',1)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(34,'Remarkable Low','Toad','Email',4800.00,'2017-12-28 00:00:00.0000000','Junior',98,0,'Some longer text here',0,1,'danderson','2017-12-07 16:25:06.6189813','2017-12-07 16:25:06.6189763',1,'2017-12-07 17:43:31.8879130',1)
INSERT INTO [ThingD] ([Id],[Name],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[TotalThingsE],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(35,'Wasteful Stretch','Sock','Website',3500.00,'2017-12-30 00:00:00.0000000','Senior',77,1,'Some longer text here',0,1,'danderson','2017-12-07 16:25:06.6525053','2017-12-07 16:25:06.6524958',1,'2017-12-07 17:43:22.6821386',1)
SET IDENTITY_INSERT [ThingD] OFF

SET IDENTITY_INSERT [ThingE] ON
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(1,'Cold Science',33,'Handsomely Minister',5,'Far Tooth','Truth','High',456.00,'2017-12-21 00:00:00.0000000','Declined',44,1,'Some longer text here',2,'rgraef','2017-12-07 00:00:00.0000000','2017-12-06 23:05:05.6676888',1,'2017-12-07 20:14:42.1042868',1)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(2,'Fatherly Door',34,'Puffy Battle',15,'Disgusted Alarm','Greystone','Medium',900.00,'2017-12-29 00:00:00.0000000','In Progress',100,1,'Some longer text here',2,'rgraef','2017-12-07 00:00:00.0000000','2017-12-06 23:07:04.9819703',1,'2017-12-07 20:14:30.9816811',1)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(3,'Classy Interest',21,'Two Discussions',18,'Resonant Team','Beginner','Low',460.00,'2018-03-13 00:00:00.0000000','Approved',18,0,'Some longer text here',1,'danderson','2017-12-07 16:28:16.2021216','2017-12-07 16:28:16.2018413',1,'2017-12-07 16:28:16.2020088',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(4,'Best Frogs',12,'Glamorous Eyes',19,'Flaky Shade','Tank','Medium',380.00,'2018-03-13 00:00:00.0000000','Declined',14,1,'Some longer text here',1,'danderson','2017-12-07 16:28:16.2793011','2017-12-07 16:28:16.2792990',1,'2017-12-07 16:28:16.2793007',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(5,'Rightful Join',6,'Ugliest Basket',20,'Equal Bath','Decision','Medium',270.00,'2018-03-13 00:00:00.0000000','Approved',12,0,'Some longer text here',1,'danderson','2017-12-07 16:28:16.3046539','2017-12-07 16:28:16.3046518',1,'2017-12-07 16:28:16.3046539',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(6,'Foamy Toy',3,'Second Outing',3,'Possible Form','Stamp','High',280.00,'2018-03-13 00:00:00.0000000','Declined',6,0,'Some longer text here',1,'danderson','2017-12-07 16:28:16.3301640','2017-12-07 16:28:16.3301612',1,'2017-12-07 16:28:16.3301636',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(7,'Violet Company',7,'Friendly Daughter',14,'Salty Milk','Pear','Medium',430.00,'2018-03-13 00:00:00.0000000','In Progress',30,1,'Some longer text here',2,'rgraef','2017-12-07 16:28:16.3340685','2017-12-07 16:28:16.3340660',1,'2017-12-07 16:28:16.3340681',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(8,'Well-Made Laugh',7,'Friendly Daughter',15,'Disgusted Alarm','Start','Low',540.00,'2018-03-13 00:00:00.0000000','Approved',39,0,'Some longer text here',1,'danderson','2017-12-07 16:28:16.3382538','2017-12-07 16:28:16.3382502',1,'2017-12-07 16:28:16.3382534',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(9,'Unwieldy Rock',7,'Friendly Daughter',14,'Salty Milk','Partner','Medium',544.00,'2018-03-13 00:00:00.0000000','In Progress',25,1,'Some longer text here',1,'danderson','2017-12-07 16:28:16.3451809','2017-12-07 16:28:16.3451781',1,'2017-12-07 16:28:16.3451806',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(10,'Ahead Wish',8,'Ten Bite',5,'Far Tooth','Cough','High',200.00,'2018-03-13 00:00:00.0000000','Submitted',21,1,'Some longer text here',3,'pkuster','2017-12-07 16:28:16.3503121','2017-12-07 16:28:16.3503051',1,'2017-12-07 16:28:16.3503118',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(11,'Dashing Rest',30,'Grieving Title',26,'Longing Fold','Liquid','Low',120.00,'2018-03-13 00:00:00.0000000','Declined',4,1,'Some longer text here',1,'danderson','2017-12-07 16:28:16.3544555','2017-12-07 16:28:16.3544523',1,'2017-12-07 16:28:16.3544551',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(12,'Spectacular Airplane',28,'Faint Argument',27,'Blue-Eyed Grip','Fireman','Medium',100.00,'2018-03-13 00:00:00.0000000','Approved',35,1,'Some longer text here',1,'danderson','2017-12-07 16:28:16.3588674','2017-12-07 16:28:16.3588638',1,'2017-12-07 16:28:16.3588670',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(13,'Languid Drop',22,'Dispensable Grade',24,'Hungry Caption','Trees','Medium',400.00,'2018-03-13 00:00:00.0000000','Submitted',44,0,'Some longer text here',2,'rgraef','2017-12-07 16:28:16.3636616','2017-12-07 16:28:16.3636595',1,'2017-12-07 16:28:16.3636616',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(14,'Simplistic Cakes',21,'Two Discussions',22,'Thirsty Butter','Humor','Medium',490.00,'2018-03-13 00:00:00.0000000','In Progress',38,0,'Some longer text here',3,'pkuster','2017-12-07 16:28:16.3676099','2017-12-07 16:28:16.3676074',1,'2017-12-07 16:28:16.3676095',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(15,'Unadvised Chess',12,'Glamorous Eyes',20,'Equal Bath','Chicken','High',705.00,'2018-03-13 00:00:00.0000000','Submitted',92,0,'Some longer text here',3,'pkuster','2017-12-07 16:28:16.3716047','2017-12-07 16:28:16.3716018',1,'2017-12-07 16:28:16.3716043',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(16,'Crabby Trucks',10,'Same Clover',18,'Resonant Team','Suggestion','Low',460.00,'2018-03-13 00:00:00.0000000','In Progress',93,1,'Some longer text here',1,'danderson','2017-12-07 16:28:16.3755737','2017-12-07 16:28:16.3755712',1,'2017-12-07 16:28:16.3755737',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(17,'Cloistered Tooth',8,'Ten Bite',5,'Far Tooth','Brother','Medium',465.00,'2018-03-13 00:00:00.0000000','Declined',8,1,'Some longer text here',1,'danderson','2017-12-07 16:28:16.3796116','2017-12-07 16:28:16.3796091',1,'2017-12-07 16:28:16.3796112',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(18,'Sick Parcel',4,'Cuddly Tiger',2,'Green Plate','Harmony','Low',885.00,'2018-03-13 00:00:00.0000000','In Progress',1,1,'Some longer text here',1,'danderson','2017-12-07 16:28:16.3835320','2017-12-07 16:28:16.3835288',1,'2017-12-07 16:28:16.3835316',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(19,'Yellow Observation',6,'Ugliest Basket',14,'Salty Milk','Thought','High',100.00,'2018-01-10 00:00:00.0000000','Submitted',3,0,'Some longer text here',1,'danderson','2017-12-07 16:28:16.3876043','2017-12-07 16:28:16.3876018',1,'2017-12-07 16:28:16.3876043',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(20,'Rhetorical River',15,'Demonic Plantation',24,'Hungry Caption','Camp','Medium',155.00,'2018-01-10 00:00:00.0000000','In Progress',1,1,'Some longer text here',1,'danderson','2017-12-07 16:28:16.3920893','2017-12-07 16:28:16.3920871',1,'2017-12-07 16:28:16.3920893',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(21,'Functional Friction',16,'Changeable Statement',20,'Equal Bath','Fly','Low',240.00,'2018-01-10 00:00:00.0000000','Approved',45,0,'Some longer text here',1,'danderson','2017-12-07 16:28:16.3961697','2017-12-07 16:28:16.3961673',1,'2017-12-07 16:28:16.3961694',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(22,'Accidental Approval',23,'Truthful Thumb',29,'Oceanic Arm','Chalk','Medium',350.00,'2018-01-10 00:00:00.0000000','In Progress',54,1,'Some longer text here',1,'danderson','2017-12-07 16:28:16.4000901','2017-12-07 16:28:16.4000873',1,'2017-12-07 16:28:16.4000897',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(23,'Mellow Plough',31,'Squalid Join',27,'Blue-Eyed Grip','Back','Medium',870.00,'2018-01-10 00:00:00.0000000','Approved',28,0,'Some longer text here',2,'rgraef','2017-12-07 16:28:16.4043459','2017-12-07 16:28:16.4043434',1,'2017-12-07 16:28:16.4043456',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(24,'Protective Wing',25,'Unbecoming Middle',15,'Disgusted Alarm','Trousers','High',540.00,'2018-01-10 00:00:00.0000000','Not Started',16,1,'Some longer text here',1,'danderson','2017-12-07 00:00:00.0000000','2017-12-07 16:28:16.4105357',1,'2017-12-07 17:52:56.8847663',1)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(25,'Smart Flame',9,'Depressed Desk',12,'Minor Corn','Motion','High',345.00,'2018-01-10 00:00:00.0000000','In Progress',22,0,'Some longer text here',1,'danderson','2017-12-07 16:28:16.4148736','2017-12-07 16:28:16.4148708',1,'2017-12-07 16:28:16.4148733',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(26,'Lucky Walk',6,'Ugliest Basket',3,'Possible Form','Rain','Medium',435.00,'2018-01-10 00:00:00.0000000','Approved',15,1,'Some longer text here',1,'danderson','2017-12-07 16:28:16.4190274','2017-12-07 16:28:16.4190250',1,'2017-12-07 16:28:16.4190271',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(27,'Dynamic Nest',3,'Second Outing',1,'Sad Tremble','Rat','Low',282.00,'2018-01-10 00:00:00.0000000','In Progress',5,0,'Some longer text here',2,'rgraef','2017-12-07 16:28:16.4230462','2017-12-07 16:28:16.4230430',1,'2017-12-07 16:28:16.4230458',NULL)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(28,'Ritzy Year',14,'Rough Agreement',5,'Far Tooth','Apparel','High',170.00,'2018-01-10 00:00:00.0000000','Approved',5,1,'Some longer text here',1,'danderson','2017-12-07 00:00:00.0000000','2017-12-07 16:28:16.4273164',1,'2017-12-07 17:49:18.8987355',1)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(29,'Various Rings',10,'Same Clover',6,'Early Cattle','Bed','High',190.00,'2018-01-10 00:00:00.0000000','Not Started',80,0,'Some longer text here',1,'danderson','2017-12-07 00:00:00.0000000','2017-12-07 16:28:16.4312544',1,'2017-12-07 17:49:06.2903362',1)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(30,'Puzzling Loaf',20,'Caring Foot',16,'Zany Roll','Taste','Medium',90.00,'2018-01-10 00:00:00.0000000','Declined',65,1,'Some longer text here',1,'danderson','2017-12-07 00:00:00.0000000','2017-12-07 16:28:16.4353018',1,'2017-12-07 17:48:48.9398528',1)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(31,'Bumpy Candle',30,'Grieving Title',12,'Minor Corn','Kettle','Medium',340.00,'2018-01-10 00:00:00.0000000','Submitted',60,0,'Some longer text here',1,'danderson','2017-12-07 00:00:00.0000000','2017-12-07 16:28:16.4396983',1,'2017-12-07 17:48:40.7483616',1)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(32,'Recondite Meal',7,'Friendly Daughter',19,'Flaky Shade','Chin','Low',540.00,'2018-01-10 00:00:00.0000000','In Progress',20,1,'Some longer text here',1,'danderson','2017-12-07 00:00:00.0000000','2017-12-07 16:28:16.4442068',1,'2017-12-07 16:30:13.8099490',1)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(33,'Mature Pies',10,'Same Clover',11,'Strange Snails','Stew','High',870.00,'2018-02-05 00:00:00.0000000','Not Started',20,1,'Some longer text here',1,'danderson','2017-12-07 00:00:00.0000000','2017-12-07 16:28:16.4482425',1,'2017-12-07 16:29:42.8463327',1)
INSERT INTO [ThingE] ([Id],[Name],[ThingAId],[ThingAName],[ThingDId],[ThingDName],[Text],[Lookup],[Money],[DateTime],[Status],[Integer],[Boolean],[LongText],[OwnerId],[OwnerAlias],[CreatedDate],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(34,'Zonked Health',4,'Cuddly Tiger',5,'Far Tooth','Monkey','High',765.00,'2017-12-28 00:00:00.0000000','In Progress',43,1,'Some longer text here',1,'danderson','2017-12-07 00:00:00.0000000','2017-12-07 16:28:16.4523304',1,'2017-12-07 18:01:51.9733448',1)
SET IDENTITY_INSERT [ThingE] OFF

SET IDENTITY_INSERT [Error] ON
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(1,1,'2017-12-08 11:51:45.4724279','Attempted to divide by zero.','System.DivideByZeroException: Attempted to divide by zero.     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<List>d__1.MoveNext() in C:\Users\John Smith\OneDrive\Dev\Dofactory.NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 28  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at lambda_method(Closure , Thing )     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Thing& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()','127.0.0.1','/thingsa','https://localhost:44313/home','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36','2017-12-08 11:51:45.4724279',1,'2017-12-08 11:51:45.4724279',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(2,1,'2017-12-08 11:53:56.9220524','Attempted to divide by zero.','System.DivideByZeroException: Attempted to divide by zero.     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<List>d__1.MoveNext() in C:\Users\John Smith\OneDrive\Dev\Dofactory.NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 28  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at lambda_method(Closure , Thing )     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Thing& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ExceptionContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Thing& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextResourceFilter>d__22.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResourceExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Thing& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeFilterPipelineAsync>d__17.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeAsync>d__15.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Builder.RouterMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.<Invoke>d__7.MoveNext()','127.0.0.1','/thingsa','https://localhost:44313/home','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36','2017-12-08 11:53:56.9220524',1,'2017-12-08 11:53:56.9220524',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(3,1,'2017-12-08 17:16:23.8461392','Source sequence doesn''t contain any elements.','System.InvalidOperationException: Source sequence doesn''t contain any elements.     at System.Linq.AsyncEnumerable.<Single_>d__380`1.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.TaskResultAsyncEnumerable`1.Enumerator.<MoveNext>d__3.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.SelectEnumerableAsyncIterator`2.<MoveNextCore>d__7.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.AsyncIterator`1.<MoveNext>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.ExceptionInterceptor`1.EnumeratorExceptionInterceptor.<MoveNext>d__5.MoveNext()','127.0.0.1','/thingsa/363',NULL,'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36','2017-12-08 17:16:23.8461392',1,'2017-12-08 17:16:23.8461392',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(4,1,'2017-12-08 19:16:56.1109242','Source sequence doesn''t contain any elements.','System.InvalidOperationException: Source sequence doesn''t contain any elements.     at System.Linq.AsyncEnumerable.<Single_>d__380`1.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.TaskResultAsyncEnumerable`1.Enumerator.<MoveNext>d__3.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.SelectEnumerableAsyncIterator`2.<MoveNextCore>d__7.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.AsyncIterator`1.<MoveNext>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.ExceptionInterceptor`1.EnumeratorExceptionInterceptor.<MoveNext>d__5.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.<ExecuteSingletonAsyncQuery>d__23`1.MoveNext()','127.0.0.1','/thingsa/363',NULL,'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36','2017-12-08 19:16:56.1109242',1,'2017-12-08 19:16:56.1109242',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(5,1,'2017-12-08 17:16:58.5030359','Source sequence doesn''t contain any elements.','System.InvalidOperationException: Source sequence doesn''t contain any elements.     at System.Linq.AsyncEnumerable.<Single_>d__380`1.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.TaskResultAsyncEnumerable`1.Enumerator.<MoveNext>d__3.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.SelectEnumerableAsyncIterator`2.<MoveNextCore>d__7.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.AsyncIterator`1.<MoveNext>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.ExceptionInterceptor`1.EnumeratorExceptionInterceptor.<MoveNext>d__5.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.<ExecuteSingletonAsyncQuery>d__23`1.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<SingleThingAAsync>d__19.MoveNext() in C:\Users\John Smith\OneDrive\Dev\Dofactory.NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 312  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<Prepare>d__11.MoveNext() in C:\Users\John Smith\OneDrive\Dev\Dofactory.NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 209  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<Detail>d__2.MoveNext() in C:\Users\John Smith\OneDrive\Dev\Dofactory.NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 34  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at lambda_method(Closure , Thing )     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Thing& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()','127.0.0.1','/thingsa/363',NULL,'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36','2017-12-08 17:16:58.5030359',1,'2017-12-08 17:16:58.5030359',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(6,1,'2017-12-08 22:16:59.8173449','Source sequence doesn''t contain any elements.','System.InvalidOperationException: Source sequence doesn''t contain any elements.     at System.Linq.AsyncEnumerable.<Single_>d__380`1.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.TaskResultAsyncEnumerable`1.Enumerator.<MoveNext>d__3.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.SelectEnumerableAsyncIterator`2.<MoveNextCore>d__7.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.AsyncIterator`1.<MoveNext>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.ExceptionInterceptor`1.EnumeratorExceptionInterceptor.<MoveNext>d__5.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.<ExecuteSingletonAsyncQuery>d__23`1.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<SingleThingAAsync>d__19.MoveNext() in C:\Users\John Smith\OneDrive\Dev\Dofactory.NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 312  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<Prepare>d__11.MoveNext() in C:\Users\John Smith\OneDrive\Dev\Dofactory.NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 209  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<Detail>d__2.MoveNext() in C:\Users\John Smith\OneDrive\Dev\Dofactory.NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 34  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at lambda_method(Closure , Thing )     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Thing& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ExceptionContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Thing& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextResourceFilter>d__22.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResourceExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Thing& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeFilterPipelineAsync>d__17.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeAsync>d__15.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Builder.RouterMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.<Invoke>d__7.MoveNext()','127.0.0.1','/thingsa/363',NULL,'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36','2017-12-08 22:16:59.8173449',1,'2017-12-08 22:16:59.8173449',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(7,1,'2017-12-08 23:22:22.9660566','Thing reference not set to an instance of an thing.','System.NullReferenceException: Thing reference not set to an instance of an thing.     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.Map(ThingA thingA, Detail model) in C:\Users\John Smith\OneDrive\Dev\Dofactory.NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 360     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<Prepare>d__11.MoveNext() in C:\Users\John Smith\OneDrive\Dev\Dofactory.NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 210  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<Detail>d__2.MoveNext() in C:\Users\John Smith\OneDrive\Dev\Dofactory.NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 34  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at lambda_method(Closure , Thing )     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Thing& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()','127.0.0.1','/thingsa/362',NULL,'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36','2017-12-08 23:22:22.9660566',1,'2017-12-08 23:22:22.9660566',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(8,1,'2017-12-08 23:28:23.2240665','Thing reference not set to an instance of an thing.','System.NullReferenceException: Thing reference not set to an instance of an thing.     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.Map(ThingA thingA, Detail model) in C:\Users\John Smith\OneDrive\Dev\Dofactory.NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 360     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<Prepare>d__11.MoveNext() in C:\Users\John Smith\OneDrive\Dev\Dofactory.NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 210  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<Detail>d__2.MoveNext() in C:\Users\John Smith\OneDrive\Dev\Dofactory.NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 34  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at lambda_method(Closure , Thing )     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Thing& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ExceptionContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Thing& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextResourceFilter>d__22.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResourceExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Thing& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeFilterPipelineAsync>d__17.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeAsync>d__15.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Builder.RouterMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.<Invoke>d__7.MoveNext()','127.0.0.1','/thingsa/362',NULL,'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36','2017-12-08 23:28:23.2240665',1,'2017-12-08 23:28:23.2240665',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(9,1,'2017-12-15 00:40:29.4363447','The partial view ''_ThingA'' was not found. The following locations were searched:  Areas\ThingsB\_ThingA.cshtml  Areas\_Main\_ThingA.cshtml  Areas\_Related\_ThingA.cshtml  Areas\_ThingA.cshtml','System.InvalidOperationException: The partial view ''_ThingA'' was not found. The following locations were searched:  Areas\ThingsB\_ThingA.cshtml  Areas\_Main\_ThingA.cshtml  Areas\_Related\_ThingA.cshtml  Areas\_ThingA.cshtml     at Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.<RenderPartialCoreAsync>d__60.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.<PartialAsync>d__57.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at AspNetCore._Areas_ThingsB_Detail_cshtml.<ExecuteAsync>d__13.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsB\Detail.cshtml:line 34  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Razor.RazorView.<RenderPageCoreAsync>d__16.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Razor.RazorView.<RenderPageAsync>d__15.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Razor.RazorView.<RenderAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.<ExecuteAsync>d__22.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.<ExecuteAsync>d__21.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.ViewResult.<ExecuteResultAsync>d__26.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeResultAsync>d__19.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextResultFilterAsync>d__24.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResultExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextResourceFilter>d__22.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResourceExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeFilterPipelineAsync>d__17.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeAsync>d__15.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Builder.RouterMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.<Invoke>d__7.MoveNext()','127.0.0.1','/thingsb/3','https://localhost:44313/home','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36','2017-12-15 00:40:29.4363447',1,'2017-12-15 00:40:29.4363447',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(10,1,'2017-12-15 00:40:33.6198191','The partial view ''_ThingA'' was not found. The following locations were searched:  Areas\ThingsC\_ThingA.cshtml  Areas\_Main\_ThingA.cshtml  Areas\_Related\_ThingA.cshtml  Areas\_ThingA.cshtml','System.InvalidOperationException: The partial view ''_ThingA'' was not found. The following locations were searched:  Areas\ThingsC\_ThingA.cshtml  Areas\_Main\_ThingA.cshtml  Areas\_Related\_ThingA.cshtml  Areas\_ThingA.cshtml     at Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.<RenderPartialCoreAsync>d__60.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.<PartialAsync>d__57.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at AspNetCore._Areas_ThingsC_Detail_cshtml.<ExecuteAsync>d__13.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsC\Detail.cshtml:line 35  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Razor.RazorView.<RenderPageCoreAsync>d__16.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Razor.RazorView.<RenderPageAsync>d__15.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Razor.RazorView.<RenderAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.<ExecuteAsync>d__22.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.<ExecuteAsync>d__21.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.ViewResult.<ExecuteResultAsync>d__26.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeResultAsync>d__19.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextResultFilterAsync>d__24.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResultExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextResourceFilter>d__22.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResourceExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeFilterPipelineAsync>d__17.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeAsync>d__15.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Builder.RouterMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.<Invoke>d__7.MoveNext()','127.0.0.1','/thingsc/9','https://localhost:44313/home','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36','2017-12-15 00:40:33.6198191',1,'2017-12-15 00:40:33.6198191',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(11,1,'2017-12-15 20:59:08.8075631','Source sequence doesn''t contain any elements.','System.InvalidOperationException: Source sequence doesn''t contain any elements.     at System.Linq.AsyncEnumerable.<Single_>d__380`1.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.TaskResultAsyncEnumerable`1.Enumerator.<MoveNext>d__3.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.SelectEnumerableAsyncIterator`2.<MoveNextCore>d__7.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.AsyncIterator`1.<MoveNext>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.ExceptionInterceptor`1.EnumeratorExceptionInterceptor.<MoveNext>d__5.MoveNext()','127.0.0.1','/people/export','https://localhost:44313/people?Page=1&Sort=Alias&AdvancedFilter=False&Filter=0&Name=&Department=&Email=&Role=','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36','2017-12-15 20:59:08.8075631',1,'2017-12-15 20:59:08.8075631',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(12,1,'2017-12-15 20:59:08.9892751','Source sequence doesn''t contain any elements.','System.InvalidOperationException: Source sequence doesn''t contain any elements.     at System.Linq.AsyncEnumerable.<Single_>d__380`1.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.TaskResultAsyncEnumerable`1.Enumerator.<MoveNext>d__3.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.SelectEnumerableAsyncIterator`2.<MoveNextCore>d__7.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.AsyncIterator`1.<MoveNext>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.ExceptionInterceptor`1.EnumeratorExceptionInterceptor.<MoveNext>d__5.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.<ExecuteSingletonAsyncQuery>d__23`1.MoveNext()','127.0.0.1','/people/export','https://localhost:44313/people?Page=1&Sort=Alias&AdvancedFilter=False&Filter=0&Name=&Department=&Email=&Role=','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36','2017-12-15 20:59:08.9892751',1,'2017-12-15 20:59:08.9892751',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(13,1,'2017-12-15 20:59:09.1877427','Source sequence doesn''t contain any elements.','System.InvalidOperationException: Source sequence doesn''t contain any elements.     at System.Linq.AsyncEnumerable.<Single_>d__380`1.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.TaskResultAsyncEnumerable`1.Enumerator.<MoveNext>d__3.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.SelectEnumerableAsyncIterator`2.<MoveNextCore>d__7.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.AsyncIterator`1.<MoveNext>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.ExceptionInterceptor`1.EnumeratorExceptionInterceptor.<MoveNext>d__5.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.<ExecuteSingletonAsyncQuery>d__23`1.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at Dofactory.Starter.Core.Areas.People.PeopleController.<SingleUserAsync>d__5.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\People\PeopleController.cs:line 122  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at Dofactory.Starter.Core.Areas.People.PeopleController.<Prepare>d__4.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\People\PeopleController.cs:line 112  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Dofactory.Starter.Core.Areas.People.PeopleController.<Detail>d__2.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\People\PeopleController.cs:line 31  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at lambda_method(Closure , Object )     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()','127.0.0.1','/people/export','https://localhost:44313/people?Page=1&Sort=Alias&AdvancedFilter=False&Filter=0&Name=&Department=&Email=&Role=','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36','2017-12-15 20:59:09.1877427',1,'2017-12-15 20:59:09.1877427',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(14,1,'2017-12-15 20:59:09.3357766','Source sequence doesn''t contain any elements.','System.InvalidOperationException: Source sequence doesn''t contain any elements.     at System.Linq.AsyncEnumerable.<Single_>d__380`1.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.TaskResultAsyncEnumerable`1.Enumerator.<MoveNext>d__3.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.SelectEnumerableAsyncIterator`2.<MoveNextCore>d__7.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()     at System.Linq.AsyncEnumerable.AsyncIterator`1.<MoveNext>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.AsyncLinqOperatorProvider.ExceptionInterceptor`1.EnumeratorExceptionInterceptor.<MoveNext>d__5.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.<ExecuteSingletonAsyncQuery>d__23`1.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at Dofactory.Starter.Core.Areas.People.PeopleController.<SingleUserAsync>d__5.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\People\PeopleController.cs:line 122  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at Dofactory.Starter.Core.Areas.People.PeopleController.<Prepare>d__4.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\People\PeopleController.cs:line 112  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Dofactory.Starter.Core.Areas.People.PeopleController.<Detail>d__2.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Application\D .NET\_P\15. 33-Day Starter\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\People\PeopleController.cs:line 31  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at lambda_method(Closure , Object )     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ExceptionContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextResourceFilter>d__22.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResourceExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeFilterPipelineAsync>d__17.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeAsync>d__15.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Builder.RouterMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.<Invoke>d__7.MoveNext()','127.0.0.1','/people/export','https://localhost:44313/people?Page=1&Sort=Alias&AdvancedFilter=False&Filter=0&Name=&Department=&Email=&Role=','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36','2017-12-15 20:59:09.3357766',1,'2017-12-15 20:59:09.3357766',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(15,NULL,'2017-12-17 19:42:00.9608366','The layout view ''_xLayout'' could not be located. The following locations were searched:  Areas\Auth\_xLayout.cshtml  Areas\_Main\_xLayout.cshtml  Areas\_Related\_xLayout.cshtml  Areas\_xLayout.cshtml','System.InvalidOperationException: The layout view ''_xLayout'' could not be located. The following locations were searched:  Areas\Auth\_xLayout.cshtml  Areas\_Main\_xLayout.cshtml  Areas\_Related\_xLayout.cshtml  Areas\_xLayout.cshtml     at Microsoft.AspNetCore.Mvc.Razor.RazorView.GetLayoutPage(ViewContext context, String executingFilePath, String layoutPath)     at Microsoft.AspNetCore.Mvc.Razor.RazorView.<RenderLayoutAsync>d__18.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Razor.RazorView.<RenderAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.<ExecuteAsync>d__22.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.<ExecuteAsync>d__21.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.ViewResult.<ExecuteResultAsync>d__26.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeResultAsync>d__19.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextResultFilterAsync>d__24.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResultExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextResourceFilter>d__22.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResourceExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeFilterPipelineAsync>d__17.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeAsync>d__15.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Builder.RouterMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.<Invoke>d__7.MoveNext()','127.0.0.1','/login','https://localhost:44313/forgot','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36','2017-12-17 19:42:00.9608366',NULL,'2017-12-17 19:42:00.9608366',NULL)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(16,1,'2017-12-29 11:36:01.0668754','Sequence contains more than one element','System.InvalidOperationException: Sequence contains more than one element     at System.Linq.Enumerable.SingleOrDefault[TSource](IEnumerable`1 source)     at lambda_method(Closure , QueryContext )     at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.<>c__DisplayClass17_1`1.<CompileQueryCore>b__0(QueryContext qc)','127.0.0.1','/thingsd/35','https://localhost:44313/thingsd','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36','2017-12-29 11:36:01.0668754',1,'2017-12-29 11:36:01.0668754',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(17,1,'2017-12-29 11:36:01.5355300','Sequence contains more than one element','System.InvalidOperationException: Sequence contains more than one element     at System.Linq.Enumerable.SingleOrDefault[TSource](IEnumerable`1 source)     at lambda_method(Closure , QueryContext )     at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.<>c__DisplayClass17_1`1.<CompileQueryCore>b__0(QueryContext qc)     at System.Linq.Queryable.SingleOrDefault[TSource](IQueryable`1 source, Expression`1 predicate)     at Dofactory.Starter.Core.BaseController.<LogViewed>d__25.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\A\D\A\15. 33-Day Starter Kit\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Code\BaseController.cs:line 65  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Dofactory.Starter.Core.Areas.ThingsD.ThingsDController.<Prepare>d__11.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\A\D\A\15. 33-Day Starter Kit\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsD\ThingsDController.cs:line 218  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Dofactory.Starter.Core.Areas.ThingsD.ThingsDController.<Detail>d__2.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\A\D\A\15. 33-Day Starter Kit\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsD\ThingsDController.cs:line 34  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at lambda_method(Closure , Object )     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()','127.0.0.1','/thingsd/35','https://localhost:44313/thingsd','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36','2017-12-29 11:36:01.5355300',1,'2017-12-29 11:36:01.5355300',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(18,1,'2017-12-29 11:36:01.7861818','Sequence contains more than one element','System.InvalidOperationException: Sequence contains more than one element     at System.Linq.Enumerable.SingleOrDefault[TSource](IEnumerable`1 source)     at lambda_method(Closure , QueryContext )     at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.<>c__DisplayClass17_1`1.<CompileQueryCore>b__0(QueryContext qc)     at System.Linq.Queryable.SingleOrDefault[TSource](IQueryable`1 source, Expression`1 predicate)     at Dofactory.Starter.Core.BaseController.<LogViewed>d__25.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\A\D\A\15. 33-Day Starter Kit\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Code\BaseController.cs:line 65  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Dofactory.Starter.Core.Areas.ThingsD.ThingsDController.<Prepare>d__11.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\A\D\A\15. 33-Day Starter Kit\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsD\ThingsDController.cs:line 218  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Dofactory.Starter.Core.Areas.ThingsD.ThingsDController.<Detail>d__2.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\A\D\A\15. 33-Day Starter Kit\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsD\ThingsDController.cs:line 34  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at lambda_method(Closure , Object )     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ExceptionContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextResourceFilter>d__22.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResourceExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeFilterPipelineAsync>d__17.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeAsync>d__15.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Builder.RouterMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.<Invoke>d__7.MoveNext()','127.0.0.1','/thingsd/35','https://localhost:44313/thingsd','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36','2017-12-29 11:36:01.7861818',1,'2017-12-29 11:36:01.7861818',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(19,1,'2017-12-30 16:04:25.2130190','The DELETE statement conflicted with the REFERENCE constraint "FK_THINGE_REFERENCE_THINGA". The conflict occurred in database "StarterCore1", table "dbo.ThingE", column ''ThingAId''.  The statement has been terminated.','System.Data.SqlClient.SqlException (0x80131904): The DELETE statement conflicted with the REFERENCE constraint "FK_THINGE_REFERENCE_THINGA". The conflict occurred in database "StarterCore1", table "dbo.ThingE", column ''ThingAId''.  The statement has been terminated.     at System.Data.SqlClient.SqlCommand.<>c.<ExecuteDbDataReaderAsync>b__108_0(Task`1 result)     at System.Threading.Tasks.ContinuationResultTaskFromResultTask`2.InnerInvoke()     at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)     at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot)  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Storage.Internal.RelationalCommand.<ExecuteAsync>d__17.MoveNext()  ClientConnectionId:6d907be5-ce69-455e-954e-d4b28b2b2447  Error Number:547,State:0,Class:16','127.0.0.1','/thingsa/delete','https://localhost:44313/thingsa?Page=1&Sort=-TotalThingsE&AdvancedFilter=False&Filter=0&Name=&ThingCIdInput=&ThingCId=&ThingCIdType=&ThingBIdInput=&ThingBId=&ThingBIdType=&OwnerIdInput=&OwnerId=&OwnerIdType=','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36','2017-12-30 16:04:25.2130190',1,'2017-12-30 16:04:25.2130190',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(20,1,'2017-12-30 16:04:25.3954759','An error occurred while updating the entries. See the inner exception for details.','Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while updating the entries. See the inner exception for details. ---> System.Data.SqlClient.SqlException: The DELETE statement conflicted with the REFERENCE constraint "FK_THINGE_REFERENCE_THINGA". The conflict occurred in database "StarterCore1", table "dbo.ThingE", column ''ThingAId''.  The statement has been terminated.     at System.Data.SqlClient.SqlCommand.<>c.<ExecuteDbDataReaderAsync>b__108_0(Task`1 result)     at System.Threading.Tasks.ContinuationResultTaskFromResultTask`2.InnerInvoke()     at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)     at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot)  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Storage.Internal.RelationalCommand.<ExecuteAsync>d__17.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.<ExecuteAsync>d__32.MoveNext()     --- End of inner exception stack trace ---     at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.<ExecuteAsync>d__32.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.<ExecuteAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Storage.Internal.SqlServerExecutionStrategy.<ExecuteAsync>d__7`2.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.<SaveChangesAsync>d__61.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.<SaveChangesAsync>d__59.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.DbContext.<SaveChangesAsync>d__48.MoveNext()','127.0.0.1','/thingsa/delete','https://localhost:44313/thingsa?Page=1&Sort=-TotalThingsE&AdvancedFilter=False&Filter=0&Name=&ThingCIdInput=&ThingCId=&ThingCIdType=&ThingBIdInput=&ThingBId=&ThingBIdType=&OwnerIdInput=&OwnerId=&OwnerIdType=','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36','2017-12-30 16:04:25.3954759',1,'2017-12-30 16:04:25.3954759',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(21,1,'2017-12-30 16:04:25.5940287','An error occurred while updating the entries. See the inner exception for details.','Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while updating the entries. See the inner exception for details. ---> System.Data.SqlClient.SqlException: The DELETE statement conflicted with the REFERENCE constraint "FK_THINGE_REFERENCE_THINGA". The conflict occurred in database "StarterCore1", table "dbo.ThingE", column ''ThingAId''.  The statement has been terminated.     at System.Data.SqlClient.SqlCommand.<>c.<ExecuteDbDataReaderAsync>b__108_0(Task`1 result)     at System.Threading.Tasks.ContinuationResultTaskFromResultTask`2.InnerInvoke()     at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)     at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot)  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Storage.Internal.RelationalCommand.<ExecuteAsync>d__17.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.<ExecuteAsync>d__32.MoveNext()     --- End of inner exception stack trace ---     at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.<ExecuteAsync>d__32.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.<ExecuteAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Storage.Internal.SqlServerExecutionStrategy.<ExecuteAsync>d__7`2.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.<SaveChangesAsync>d__61.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.<SaveChangesAsync>d__59.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.DbContext.<SaveChangesAsync>d__48.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<Process>d__14.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\A\D\A\15. 33-Day Starter Kit\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 255  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<Delete>d__5.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\A\D\A\15. 33-Day Starter Kit\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 64  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()','127.0.0.1','/thingsa/delete','https://localhost:44313/thingsa?Page=1&Sort=-TotalThingsE&AdvancedFilter=False&Filter=0&Name=&ThingCIdInput=&ThingCId=&ThingCIdType=&ThingBIdInput=&ThingBId=&ThingBIdType=&OwnerIdInput=&OwnerId=&OwnerIdType=','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36','2017-12-30 16:04:25.5940287',1,'2017-12-30 16:04:25.5940287',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(22,1,'2017-12-30 16:04:25.7684141','An error occurred while updating the entries. See the inner exception for details.','Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while updating the entries. See the inner exception for details. ---> System.Data.SqlClient.SqlException: The DELETE statement conflicted with the REFERENCE constraint "FK_THINGE_REFERENCE_THINGA". The conflict occurred in database "StarterCore1", table "dbo.ThingE", column ''ThingAId''.  The statement has been terminated.     at System.Data.SqlClient.SqlCommand.<>c.<ExecuteDbDataReaderAsync>b__108_0(Task`1 result)     at System.Threading.Tasks.ContinuationResultTaskFromResultTask`2.InnerInvoke()     at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)     at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot)  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Storage.Internal.RelationalCommand.<ExecuteAsync>d__17.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.<ExecuteAsync>d__32.MoveNext()     --- End of inner exception stack trace ---     at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.<ExecuteAsync>d__32.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.<ExecuteAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.Storage.Internal.SqlServerExecutionStrategy.<ExecuteAsync>d__7`2.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.<SaveChangesAsync>d__61.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.<SaveChangesAsync>d__59.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.EntityFrameworkCore.DbContext.<SaveChangesAsync>d__48.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<Process>d__14.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\A\D\A\15. 33-Day Starter Kit\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 255  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Dofactory.Starter.Core.Areas.ThingsA.ThingsAController.<Delete>d__5.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\A\D\A\15. 33-Day Starter Kit\.NET Core\Dofactory.Starter.Core\Dofactory.Starter.Core\Areas\ThingsA\ThingsAController.cs:line 64  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ExceptionContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextResourceFilter>d__22.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResourceExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeFilterPipelineAsync>d__17.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeAsync>d__15.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Builder.RouterMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.<Invoke>d__7.MoveNext()','127.0.0.1','/thingsa/delete','https://localhost:44313/thingsa?Page=1&Sort=-TotalThingsE&AdvancedFilter=False&Filter=0&Name=&ThingCIdInput=&ThingCId=&ThingCIdType=&ThingBIdInput=&ThingBId=&ThingBIdType=&OwnerIdInput=&OwnerId=&OwnerIdType=','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36','2017-12-30 16:04:25.7684141',1,'2017-12-30 16:04:25.7684141',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(24,1,'2018-04-16 15:10:41.3232522','Could not find document','System.IO.FileNotFoundException: Could not find document  File name: ''C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Final\.NET Core 2.1\14. 33-Day Success Kit\Dofactory.Success.Core\Dofactory.Success.Core\Data\Imports\Excel-b61cdwu68l.xlsx''     at DocumentFormat.OpenXml.Packaging.OpenXmlPackage.OpenCore(String path, Boolean readWriteMode)     at DocumentFormat.OpenXml.Packaging.SpreadsheetDocument.Open(String path, Boolean isEditable, OpenSettings openSettings)     at Dofactory.Success.Core.Excel.ReadToGrid(String fileName) in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Final\.NET Core 2.1\14. 33-Day Success Kit\Dofactory.Success.Core\Dofactory.Success.Core\Code\Excel\Excel.cs:line 736     at Dofactory.Success.Core.Excel.<ImportThingsAAsync>d__14.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Final\.NET Core 2.1\14. 33-Day Success Kit\Dofactory.Success.Core\Dofactory.Success.Core\Code\Excel\Excel.cs:line 530  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at Dofactory.Success.Core.Areas.ThingsA.ThingsAController.<ImportGo>d__8.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Final\.NET Core 2.1\14. 33-Day Success Kit\Dofactory.Success.Core\Dofactory.Success.Core\Areas\ThingsA\ThingsAController.cs:line 102','127.0.0.1','/thingsa/import/go','https://localhost:44371/thingsa/import','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36','2018-04-16 15:10:41.3232522',1,'2018-04-16 15:10:41.3232522',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(25,1,'2018-04-16 15:10:46.4815716','Value cannot be null.  Parameter name: path3','System.ArgumentNullException: Value cannot be null.  Parameter name: path3     at System.IO.Path.Combine(String path1, String path2, String path3)     at Dofactory.Success.Core.Excel.Qualify(String fileName) in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Final\.NET Core 2.1\14. 33-Day Success Kit\Dofactory.Success.Core\Dofactory.Success.Core\Code\Excel\Excel.cs:line 26     at Dofactory.Success.Core.Excel.ReadToGrid(String fileName) in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Final\.NET Core 2.1\14. 33-Day Success Kit\Dofactory.Success.Core\Dofactory.Success.Core\Code\Excel\Excel.cs:line 734     at Dofactory.Success.Core.Excel.<ImportThingsAAsync>d__14.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Final\.NET Core 2.1\14. 33-Day Success Kit\Dofactory.Success.Core\Dofactory.Success.Core\Code\Excel\Excel.cs:line 530  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at Dofactory.Success.Core.Areas.ThingsA.ThingsAController.<ImportGo>d__8.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Final\.NET Core 2.1\14. 33-Day Success Kit\Dofactory.Success.Core\Dofactory.Success.Core\Areas\ThingsA\ThingsAController.cs:line 102','127.0.0.1','/thingsa/import/go','https://localhost:44371/thingsa/import/go','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36','2018-04-16 15:10:46.4815716',1,'2018-04-16 15:10:46.4815716',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(26,1,'2018-04-16 15:10:52.4326915','Value cannot be null.  Parameter name: path3','System.ArgumentNullException: Value cannot be null.  Parameter name: path3     at System.IO.Path.Combine(String path1, String path2, String path3)     at Dofactory.Success.Core.Excel.Qualify(String fileName) in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Final\.NET Core 2.1\14. 33-Day Success Kit\Dofactory.Success.Core\Dofactory.Success.Core\Code\Excel\Excel.cs:line 26     at Dofactory.Success.Core.Excel.ReadToGrid(String fileName) in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Final\.NET Core 2.1\14. 33-Day Success Kit\Dofactory.Success.Core\Dofactory.Success.Core\Code\Excel\Excel.cs:line 734     at Dofactory.Success.Core.Excel.<ImportThingsAAsync>d__14.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Final\.NET Core 2.1\14. 33-Day Success Kit\Dofactory.Success.Core\Dofactory.Success.Core\Code\Excel\Excel.cs:line 530  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()     at Dofactory.Success.Core.Areas.ThingsA.ThingsAController.<ImportGo>d__8.MoveNext() in C:\Users\Jacob Poorte\OneDrive\Dev\Dofactory .NET\Final\.NET Core 2.1\14. 33-Day Success Kit\Dofactory.Success.Core\Dofactory.Success.Core\Areas\ThingsA\ThingsAController.cs:line 102','127.0.0.1','/thingsa/import/go','https://localhost:44371/thingsa/import/go','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36','2018-04-16 15:10:52.4326915',1,'2018-04-16 15:10:52.4326915',1)
INSERT INTO [Error] ([Id],[UserId],[ErrorDate],[Message],[Exception],[IpAddress],[Url],[HttpReferer],[UserAgent],[CreatedOn],[CreatedBy],[ChangedOn],[ChangedBy])VALUES(27,1,'2018-04-21 21:46:28.0784577','One or more compilation failures occurred:  C:\Users\Jacob Poorte\OneDrive\Dev\Do .NET\F\.NET Core 2.1\14. 33-Day Success\Dofactory.Success.Core\Dofactory.Success.Core\Areas\ThingsD\List.cshtml(99,14): Error RZ9999: The "tr" element was not closed.  All elements must be either self-closing or have a matching end tag.  C:\Users\Jacob Poorte\OneDrive\Dev\Do .NET\F\.NET Core 2.1\14. 33-Day Success\Dofactory.Success.Core\Dofactory.Success.Core\Areas\ThingsD\List.cshtml(115,15): Error RZ9999: Encountered end tag "tr" with no matching start tag.  Are your start/end tags properly balanced?','Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationFailedException: One or more compilation failures occurred:  C:\Users\Jacob Poorte\OneDrive\Dev\Do .NET\F\.NET Core 2.1\14. 33-Day Success\Dofactory.Success.Core\Dofactory.Success.Core\Areas\ThingsD\List.cshtml(99,14): Error RZ9999: The "tr" element was not closed.  All elements must be either self-closing or have a matching end tag.  C:\Users\Jacob Poorte\OneDrive\Dev\Do .NET\F\.NET Core 2.1\14. 33-Day Success\Dofactory.Success.Core\Dofactory.Success.Core\Areas\ThingsD\List.cshtml(115,15): Error RZ9999: Encountered end tag "tr" with no matching start tag.  Are your start/end tags properly balanced?     at Microsoft.AspNetCore.Mvc.Razor.Internal.RazorViewCompiler.CompileAndEmit(String relativePath)     at Microsoft.AspNetCore.Mvc.Razor.Internal.RazorViewCompiler.CreateCacheEntry(String normalizedPath)  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorPageFactoryProvider.CreateFactory(String relativePath)     at Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.CreateCacheResult(HashSet`1 expirationTokens, String relativePath, Boolean isMainPage)     at Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.OnCacheMiss(ViewLocationExpanderContext expanderContext, ViewLocationCacheKey cacheKey)     at Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.LocatePageFromViewLocations(ActionContext actionContext, String pageName, Boolean isMainPage)     at Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.FindView(ActionContext context, String viewName, Boolean isMainPage)     at Microsoft.AspNetCore.Mvc.ViewEngines.CompositeViewEngine.FindView(ActionContext context, String viewName, Boolean isMainPage)     at Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewResultExecutor.FindView(ActionContext actionContext, ViewResult viewResult)     at Microsoft.AspNetCore.Mvc.ViewResult.<ExecuteResultAsync>d__26.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeResultAsync>d__19.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextResultFilterAsync>d__24.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResultExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextResourceFilter>d__22.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Rethrow(ResourceExecutedContext context)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeFilterPipelineAsync>d__17.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeAsync>d__15.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Builder.RouterMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware.<Invoke>d__4.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware.<Invoke>d__6.MoveNext()  --- End of stack trace from previous location where exception was thrown ---     at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()     at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)     at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.<Invoke>d__7.MoveNext()','127.0.0.1','/thingsd','https://localhost:44371/thingsa?AdvancedFilter=True&thingCid=30','Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36','2018-04-21 21:46:28.0784577',1,'2018-04-21 21:46:28.0784577',1)
SET IDENTITY_INSERT [Error] OFF


-- ASP.NET Identity 3.0 model

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AspNetUserRoles') and o.name = 'FK_AspNetUserRoles_AspNetUsers_UserId')
alter table AspNetUserRoles
   drop constraint FK_AspNetUserRoles_AspNetUsers_UserId
go


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AspNetUserLogins') and o.name = 'FK_AspNetUserLogins_AspNetUsers_UserId')
alter table AspNetUserLogins
   drop constraint FK_AspNetUserLogins_AspNetUsers_UserId
go


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AspNetUserRoles') and o.name = 'FK_AspNetUserRoles_AspNetRoles_RoleId')
alter table AspNetUserRoles
   drop constraint FK_AspNetUserRoles_AspNetRoles_RoleId
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AspNetUserClaims') and o.name = 'FK_AspNetUserClaims_AspNetUsers_UserId')
alter table AspNetUserClaims
   drop constraint FK_AspNetUserClaims_AspNetUsers_UserId
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AspNetUserClaims') and o.name = 'FK_AspNetRoleClaims_AspNetRoles_RoleId')
alter table AspNetUserClaims
   drop constraint FK_AspNetRoleClaims_AspNetRoles_RoleId
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AspNetRoleClaims') and o.name = 'FK_AspNetRoleClaims_AspNetRoles_RoleId')
alter table AspNetRoleClaims
   drop constraint FK_AspNetRoleClaims_AspNetRoles_RoleId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AspNetUserTokens')
            and   type = 'U')
   drop table AspNetUserTokens
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AspNetUsers')
            and   type = 'U')
   drop table AspNetUsers
go


if exists (select 1
            from  sysobjects
           where  id = object_id('AspNetUserRoles')
            and   type = 'U')
   drop table AspNetUserRoles
go


if exists (select 1
            from  sysobjects
           where  id = object_id('AspNetUserLogins')
            and   type = 'U')
   drop table AspNetUserLogins
go


if exists (select 1
            from  sysobjects
           where  id = object_id('AspNetUserClaims')
            and   type = 'U')
   drop table AspNetUserClaims
go


if exists (select 1
            from  sysobjects
           where  id = object_id('AspNetRoles')
            and   type = 'U')
   drop table AspNetRoles
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AspNetRoleClaims')
            and   type = 'U')
   drop table AspNetRoleClaims


   if exists (select 1
            from  sysobjects
           where  id = object_id('__EFMigrationsHistory')
            and   type = 'U')
   drop table __EFMigrationsHistory
go

--


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO


-- ASP.NET Identity 3.0 data

INSERT INTO [AspNetRoles] ([Id],[ConcurrencyStamp],[Name],[NormalizedName])VALUES('2f89f817-6320-4e0c-9364-9a04033bf256','450a1084-d9d2-4162-aae2-482cb7f3b874','Admin','ADMIN')
INSERT INTO [AspNetRoles] ([Id],[ConcurrencyStamp],[Name],[NormalizedName])VALUES('70c0e727-429d-4f2e-8c30-0000bfdde1e9','b34c04de-ce8e-43a9-9eb1-c3f3302fc86c','User','USER')

INSERT INTO [AspNetUsers] ([Id],[AccessFailedCount],[ConcurrencyStamp],[Email],[EmailConfirmed],[LockoutEnabled],[LockoutEnd],[NormalizedEmail],[NormalizedUserName],[PasswordHash],[PhoneNumber],[PhoneNumberConfirmed],[SecurityStamp],[TwoFactorEnabled],[UserName])VALUES('18404d8b-8ab3-4f16-914f-d7db45721174',0,'06bc6de1-b4a9-4ea2-ad10-88520673115c','ronald@company.com',0,1,NULL,'RONALD@COMPANY.COM','1F845492-C45D-4F9F-B008-65B62750A7FE','AQAAAAEAACcQAAAAELQL4kmDsbWet6ToTDb59v33nCsNp+x2JRPXIyv1wN1Pw/UcI8n/DGOOWZA8uUN9Kw==',NULL,0,'0cdd3a9b-0400-415a-b547-2acea0a8dd09',0,'1f845492-c45d-4f9f-b008-65b62750a7fe')
INSERT INTO [AspNetUsers] ([Id],[AccessFailedCount],[ConcurrencyStamp],[Email],[EmailConfirmed],[LockoutEnabled],[LockoutEnd],[NormalizedEmail],[NormalizedUserName],[PasswordHash],[PhoneNumber],[PhoneNumberConfirmed],[SecurityStamp],[TwoFactorEnabled],[UserName])VALUES('4a4a3f55-b667-4202-905b-3442db50bfd4',0,'1dfbaa09-ff60-4e56-8dfd-c4e1a964f875','christine@company.com',0,1,NULL,'CHRISTINE@COMPANY.COM','B7DEAACC-1169-4E45-9B0B-48CC05F2F914','AQAAAAEAACcQAAAAEA/OuqqurcOhsL62y1+gd+F9qI7FUoQ5TGaCaZNmm901unz4A4DoWmijumpPuEvyuA==',NULL,0,'603c0b3b-6fd2-4bac-9cb2-4b54f63b0f59',0,'b7deaacc-1169-4e45-9b0b-48cc05f2f914')
INSERT INTO [AspNetUsers] ([Id],[AccessFailedCount],[ConcurrencyStamp],[Email],[EmailConfirmed],[LockoutEnabled],[LockoutEnd],[NormalizedEmail],[NormalizedUserName],[PasswordHash],[PhoneNumber],[PhoneNumberConfirmed],[SecurityStamp],[TwoFactorEnabled],[UserName])VALUES('565f1c4b-21db-4ab9-a9ff-f1383ad8c57e',0,'07d37546-8b85-410a-8b7c-df63392faa0f','henriette@company.com',0,1,NULL,'HENRIETTE@COMPANY.COM','8EA9AC23-9543-4861-9ED4-FDDF2BDB0FDE','AQAAAAEAACcQAAAAEPL63wo/UQRpMLouo7YCn01/09VIIkKZwcsnuQ4nxGpbSzZPycUSLzrpFHO32XIfyg==',NULL,0,'d8016406-8a17-40e9-b77d-964b3abd7340',0,'8ea9ac23-9543-4861-9ed4-fddf2bdb0fde')
INSERT INTO [AspNetUsers] ([Id],[AccessFailedCount],[ConcurrencyStamp],[Email],[EmailConfirmed],[LockoutEnabled],[LockoutEnd],[NormalizedEmail],[NormalizedUserName],[PasswordHash],[PhoneNumber],[PhoneNumberConfirmed],[SecurityStamp],[TwoFactorEnabled],[UserName])VALUES('87279326-ef9a-4e2a-817d-720cec4c8f4e',0,'00964f47-1398-4da3-bdc0-dc535d016bfa','fene@company.com',0,1,NULL,'FENE@COMPANY.COM','85ACCC8B-066C-4FFF-B690-96E3F4287D3A','AQAAAAEAACcQAAAAENULlI1fAgNqnXhRG97XkGXBe+Ijm3djUAIXU7nXMCchkUdQAyjNTPVOg79dAiF9oA==',NULL,0,'12acfa1c-4afd-45e2-87d8-581a88147b93',0,'85accc8b-066c-4fff-b690-96e3f4287d3a')
INSERT INTO [AspNetUsers] ([Id],[AccessFailedCount],[ConcurrencyStamp],[Email],[EmailConfirmed],[LockoutEnabled],[LockoutEnd],[NormalizedEmail],[NormalizedUserName],[PasswordHash],[PhoneNumber],[PhoneNumberConfirmed],[SecurityStamp],[TwoFactorEnabled],[UserName])VALUES('95e02adc-4a30-47f6-b63f-1f4bb3502a5d',0,'03e7935b-168b-4b6b-9f51-30c5df79e3cb','troy@company.com',0,1,NULL,'TROY@COMPANY.COM','5F311161-B3EB-47F2-881A-7F0D73DDA4D7','AQAAAAEAACcQAAAAEISZKmnubLVUKpeRDTqu74VcfK69W4Mg2izeXmADe3KN1BKRETyNUTrPaVZkypzkWg==',NULL,0,'bc79b770-74d1-4d65-bf3a-3e4449161f27',0,'5f311161-b3eb-47f2-881a-7f0d73dda4d7')
INSERT INTO [AspNetUsers] ([Id],[AccessFailedCount],[ConcurrencyStamp],[Email],[EmailConfirmed],[LockoutEnabled],[LockoutEnd],[NormalizedEmail],[NormalizedUserName],[PasswordHash],[PhoneNumber],[PhoneNumberConfirmed],[SecurityStamp],[TwoFactorEnabled],[UserName])VALUES('9aaf5823-6e45-45ce-b6f8-a78f43faae7b',0,'191d0d18-f03b-4d68-8f08-cdf28ced33bb','debbie@company.com',0,1,NULL,'DEBBIE@COMPANY.COM','F9E00F46-859D-4163-AD31-D560A559E919','AQAAAAEAACcQAAAAECeaqC2EB4AHWTFcY9lXolTFlIjuqj3ZBe4agDRWNy3Z/GGy1oQ2QLEovSf5aJMhcg==',NULL,0,'e74fbcb5-d9c6-4b5f-b969-d47df17e4557',0,'f9e00f46-859d-4163-ad31-d560a559e919')
INSERT INTO [AspNetUsers] ([Id],[AccessFailedCount],[ConcurrencyStamp],[Email],[EmailConfirmed],[LockoutEnabled],[LockoutEnd],[NormalizedEmail],[NormalizedUserName],[PasswordHash],[PhoneNumber],[PhoneNumberConfirmed],[SecurityStamp],[TwoFactorEnabled],[UserName])VALUES('d9aae1ff-fe0d-4bfa-8e96-b8ed5178bb7c',0,'12117619-f937-4be3-b29e-dca18c57348e','peter@company.com',0,1,NULL,'PETER@COMPANY.COM','64AEDFDC-8BAB-463F-B590-D80D5BC64820','AQAAAAEAACcQAAAAEBMqA5Nr79UAX3OYc0o5UfxAozHfARiOKNY+Y+hWEmioUK3ioaSfS5bHemKPAGESiQ==',NULL,0,'baf85e54-aee9-40ee-84e6-6c25322c5b59',0,'64aedfdc-8bab-463f-b590-d80d5bc64820')

INSERT INTO [AspNetUserRoles] ([UserId],[RoleId])VALUES('18404d8b-8ab3-4f16-914f-d7db45721174','2f89f817-6320-4e0c-9364-9a04033bf256')
INSERT INTO [AspNetUserRoles] ([UserId],[RoleId])VALUES('4a4a3f55-b667-4202-905b-3442db50bfd4','70c0e727-429d-4f2e-8c30-0000bfdde1e9')
INSERT INTO [AspNetUserRoles] ([UserId],[RoleId])VALUES('565f1c4b-21db-4ab9-a9ff-f1383ad8c57e','70c0e727-429d-4f2e-8c30-0000bfdde1e9')
INSERT INTO [AspNetUserRoles] ([UserId],[RoleId])VALUES('87279326-ef9a-4e2a-817d-720cec4c8f4e','70c0e727-429d-4f2e-8c30-0000bfdde1e9')
INSERT INTO [AspNetUserRoles] ([UserId],[RoleId])VALUES('95e02adc-4a30-47f6-b63f-1f4bb3502a5d','70c0e727-429d-4f2e-8c30-0000bfdde1e9')
INSERT INTO [AspNetUserRoles] ([UserId],[RoleId])VALUES('9aaf5823-6e45-45ce-b6f8-a78f43faae7b','2f89f817-6320-4e0c-9364-9a04033bf256')
INSERT INTO [AspNetUserRoles] ([UserId],[RoleId])VALUES('d9aae1ff-fe0d-4bfa-8e96-b8ed5178bb7c','70c0e727-429d-4f2e-8c30-0000bfdde1e9')

