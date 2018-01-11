/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     17-12-2017 8:19:19 PM                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CTHD') and o.name = 'FK_CTHD_CTHD_SACH')
alter table CTHD
   drop constraint FK_CTHD_CTHD_SACH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CTHD') and o.name = 'FK_CTHD_CTHD2_HOADON')
alter table CTHD
   drop constraint FK_CTHD_CTHD2_HOADON
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HOADON') and o.name = 'FK_HOADON_TK_TAIKHOAN')
alter table HOADON
   drop constraint FK_HOADON_TK_TAIKHOAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHUONG_XA') and o.name = 'FK_PHUONG_X_QUANHUYEN_QUAN_HUY')
alter table PHUONG_XA
   drop constraint FK_PHUONG_X_QUANHUYEN_QUAN_HUY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QUAN_HUYEN') and o.name = 'FK_QUAN_HUY_TINHTHANH_TINH_THA')
alter table QUAN_HUYEN
   drop constraint FK_QUAN_HUY_TINHTHANH_TINH_THA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SACH') and o.name = 'FK_SACH_NSX_NHAXUATB')
alter table SACH
   drop constraint FK_SACH_NSX_NHAXUATB
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SACH') and o.name = 'FK_SACH_TG_TACGIA')
alter table SACH
   drop constraint FK_SACH_TG_TACGIA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SACH') and o.name = 'FK_SACH_THELOAI_THELOAI')
alter table SACH
   drop constraint FK_SACH_THELOAI_THELOAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TAIKHOAN') and o.name = 'FK_TAIKHOAN_PX_PHUONG_X')
alter table TAIKHOAN
   drop constraint FK_TAIKHOAN_PX_PHUONG_X
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TAIKHOAN') and o.name = 'FK_TAIKHOAN_QH_QUAN_HUY')
alter table TAIKHOAN
   drop constraint FK_TAIKHOAN_QH_QUAN_HUY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TAIKHOAN') and o.name = 'FK_TAIKHOAN_QUYEN_QUYEN')
alter table TAIKHOAN
   drop constraint FK_TAIKHOAN_QUYEN_QUYEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TAIKHOAN') and o.name = 'FK_TAIKHOAN_TP_TINH_THA')
alter table TAIKHOAN
   drop constraint FK_TAIKHOAN_TP_TINH_THA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CTHD')
            and   name  = 'CTHD2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CTHD.CTHD2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CTHD')
            and   name  = 'CTHD_FK'
            and   indid > 0
            and   indid < 255)
   drop index CTHD.CTHD_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CTHD')
            and   type = 'U')
   drop table CTHD
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HOADON')
            and   name  = 'TK_FK'
            and   indid > 0
            and   indid < 255)
   drop index HOADON.TK_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HOADON')
            and   type = 'U')
   drop table HOADON
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NHAXUATBAN')
            and   type = 'U')
   drop table NHAXUATBAN
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PHUONG_XA')
            and   name  = 'QUANHUYEN_FK'
            and   indid > 0
            and   indid < 255)
   drop index PHUONG_XA.QUANHUYEN_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHUONG_XA')
            and   type = 'U')
   drop table PHUONG_XA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QUAN_HUYEN')
            and   name  = 'TINHTHANHPHO_FK'
            and   indid > 0
            and   indid < 255)
   drop index QUAN_HUYEN.TINHTHANHPHO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QUAN_HUYEN')
            and   type = 'U')
   drop table QUAN_HUYEN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QUYEN')
            and   type = 'U')
   drop table QUYEN
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SACH')
            and   name  = 'TG_FK'
            and   indid > 0
            and   indid < 255)
   drop index SACH.TG_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SACH')
            and   name  = 'THELOAI_FK'
            and   indid > 0
            and   indid < 255)
   drop index SACH.THELOAI_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SACH')
            and   name  = 'NSX_FK'
            and   indid > 0
            and   indid < 255)
   drop index SACH.NSX_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SACH')
            and   type = 'U')
   drop table SACH
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TACGIA')
            and   type = 'U')
   drop table TACGIA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TAIKHOAN')
            and   name  = 'PX_FK'
            and   indid > 0
            and   indid < 255)
   drop index TAIKHOAN.PX_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TAIKHOAN')
            and   name  = 'QH_FK'
            and   indid > 0
            and   indid < 255)
   drop index TAIKHOAN.QH_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TAIKHOAN')
            and   name  = 'TP_FK'
            and   indid > 0
            and   indid < 255)
   drop index TAIKHOAN.TP_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TAIKHOAN')
            and   name  = 'QUYEN_FK'
            and   indid > 0
            and   indid < 255)
   drop index TAIKHOAN.QUYEN_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TAIKHOAN')
            and   type = 'U')
   drop table TAIKHOAN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('THELOAI')
            and   type = 'U')
   drop table THELOAI
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TINH_THANHPHO')
            and   type = 'U')
   drop table TINH_THANHPHO
go

/*==============================================================*/
/* Table: CTHD                                                  */
/*==============================================================*/
create table CTHD (
   MASACH               int                  not null,
   MAHD                 char(10)             not null,
   MACTHD               int                  not null,
   SOLUONG              int                  null,
   constraint PK_CTHD primary key (MASACH, MAHD)
)
go

/*==============================================================*/
/* Index: CTHD_FK                                               */
/*==============================================================*/
create index CTHD_FK on CTHD (
MASACH ASC
)
go

/*==============================================================*/
/* Index: CTHD2_FK                                              */
/*==============================================================*/
create index CTHD2_FK on CTHD (
MAHD ASC
)
go

/*==============================================================*/
/* Table: HOADON                                                */
/*==============================================================*/
create table HOADON (
   MAHD                 char(10)             not null,
   MAUSER               int                  not null,
   TENNGUOIDAT          nvarchar(100)         null,
   DIACHINGUOIDAT       nvarchar(200)         null,
   SDTNGUOIDAT          char(15)             null,
   EMAILNGUOIDAT        char(50)             null,
   TENNGUOINHAN         nvarchar(100)         null,
   DIACHINGUOINHAN      nvarchar(200)         null,
   SDTNGUOINHAN         char(15)             null,
   EMAILNGUOINHAN       char(50)             null,
   NGAYDATHANG          datetime             null,
   TRANGTHAI            nvarchar(50)          null,
   constraint PK_HOADON primary key nonclustered (MAHD)
)
go

/*==============================================================*/
/* Index: TK_FK                                                 */
/*==============================================================*/
create index TK_FK on HOADON (
MAUSER ASC
)
go

/*==============================================================*/
/* Table: NHAXUATBAN                                            */
/*==============================================================*/
create table NHAXUATBAN (
   MANSX                int                  not null,
   TENNSX               nvarchar(100)         null,
   EMAIL                char(50)             null,
   SDT                  char(15)             null,
   DIACHI               nvarchar(100)         null,
   constraint PK_NHAXUATBAN primary key nonclustered (MANSX)
)
go

/*==============================================================*/
/* Table: PHUONG_XA                                             */
/*==============================================================*/
create table PHUONG_XA (
   PXID                 char(10)             not null,
   QHID                 char(10)             not null,
   TENPX                nvarchar(100)         null,
   constraint PK_PHUONG_XA primary key nonclustered (PXID)
)
go

/*==============================================================*/
/* Index: QUANHUYEN_FK                                          */
/*==============================================================*/
create index QUANHUYEN_FK on PHUONG_XA (
QHID ASC
)
go

/*==============================================================*/
/* Table: QUAN_HUYEN                                            */
/*==============================================================*/
create table QUAN_HUYEN (
   QHID                 char(10)             not null,
   TTPID                char(10)             not null,
   TENQH                nvarchar(100)         null,
   constraint PK_QUAN_HUYEN primary key nonclustered (QHID)
)
go

/*==============================================================*/
/* Index: TINHTHANHPHO_FK                                       */
/*==============================================================*/
create index TINHTHANHPHO_FK on QUAN_HUYEN (
TTPID ASC
)
go

/*==============================================================*/
/* Table: QUYEN                                                 */
/*==============================================================*/
create table QUYEN (
   MAQUYEN              int                  not null,
   TENQUYEN             nvarchar(50)          null,
   constraint PK_QUYEN primary key nonclustered (MAQUYEN)
)
go

/*==============================================================*/
/* Table: SACH                                                  */
/*==============================================================*/
create table SACH (
   MASACH               int                  not null,
   MANSX                int                  not null,
   MATL                 int                  not null,
   MATG                 int                  not null,
   TENSACH              nvarchar(100)         null,
   SOLUONG              int                  null,
   DONGIA               numeric              null,
   HINHANH              nvarchar(100)         null,
   MOTA                 nvarchar(500)         null,
   NGAYNHAP             datetime             null,
   constraint PK_SACH primary key nonclustered (MASACH)
)
go

/*==============================================================*/
/* Index: NSX_FK                                                */
/*==============================================================*/
create index NSX_FK on SACH (
MANSX ASC
)
go

/*==============================================================*/
/* Index: THELOAI_FK                                            */
/*==============================================================*/
create index THELOAI_FK on SACH (
MATL ASC
)
go

/*==============================================================*/
/* Index: TG_FK                                                 */
/*==============================================================*/
create index TG_FK on SACH (
MATG ASC
)
go

/*==============================================================*/
/* Table: TACGIA                                                */
/*==============================================================*/
create table TACGIA (
   MATG                 int                  not null,
   TENTG                nvarchar(100)         null,
   constraint PK_TACGIA primary key nonclustered (MATG)
)
go

/*==============================================================*/
/* Table: TAIKHOAN                                              */
/*==============================================================*/
create table TAIKHOAN (
   MAUSER               int                  not null,
   MAQUYEN              int                  not null,
   TTPID                char(10)             not null,
   PXID                 char(10)             not null,
   QHID                 char(10)             not null,
   USERNAME             char(50)             null,
   PASS                 char(50)             null,
   HOTEN                nvarchar(100)         null,
   EMAIL                char(50)             null,
   SDT                  char(15)             null,
   DIACHI               nvarchar(100)         null,
   constraint PK_TAIKHOAN primary key nonclustered (MAUSER)
)
go

/*==============================================================*/
/* Index: QUYEN_FK                                              */
/*==============================================================*/
create index QUYEN_FK on TAIKHOAN (
MAQUYEN ASC
)
go

/*==============================================================*/
/* Index: TP_FK                                                 */
/*==============================================================*/
create index TP_FK on TAIKHOAN (
TTPID ASC
)
go

/*==============================================================*/
/* Index: QH_FK                                                 */
/*==============================================================*/
create index QH_FK on TAIKHOAN (
QHID ASC
)
go

/*==============================================================*/
/* Index: PX_FK                                                 */
/*==============================================================*/
create index PX_FK on TAIKHOAN (
PXID ASC
)
go

/*==============================================================*/
/* Table: THELOAI                                               */
/*==============================================================*/
create table THELOAI (
   MATL                 int                  not null,
   TENTL                nvarchar(100)         null,
   constraint PK_THELOAI primary key nonclustered (MATL)
)
go

/*==============================================================*/
/* Table: TINH_THANHPHO                                         */
/*==============================================================*/
create table TINH_THANHPHO (
   TTPID                char(10)             not null,
   TENTTP               nvarchar(100)         null,
   constraint PK_TINH_THANHPHO primary key nonclustered (TTPID)
)
go

alter table CTHD
   add constraint FK_CTHD_CTHD_SACH foreign key (MASACH)
      references SACH (MASACH)
go

alter table CTHD
   add constraint FK_CTHD_CTHD2_HOADON foreign key (MAHD)
      references HOADON (MAHD)
go

alter table HOADON
   add constraint FK_HOADON_TK_TAIKHOAN foreign key (MAUSER)
      references TAIKHOAN (MAUSER)
go

alter table PHUONG_XA
   add constraint FK_PHUONG_X_QUANHUYEN_QUAN_HUY foreign key (QHID)
      references QUAN_HUYEN (QHID)
go

alter table QUAN_HUYEN
   add constraint FK_QUAN_HUY_TINHTHANH_TINH_THA foreign key (TTPID)
      references TINH_THANHPHO (TTPID)
go

alter table SACH
   add constraint FK_SACH_NSX_NHAXUATB foreign key (MANSX)
      references NHAXUATBAN (MANSX)
go

alter table SACH
   add constraint FK_SACH_TG_TACGIA foreign key (MATG)
      references TACGIA (MATG)
go

alter table SACH
   add constraint FK_SACH_THELOAI_THELOAI foreign key (MATL)
      references THELOAI (MATL)
go

alter table TAIKHOAN
   add constraint FK_TAIKHOAN_PX_PHUONG_X foreign key (PXID)
      references PHUONG_XA (PXID)
go

alter table TAIKHOAN
   add constraint FK_TAIKHOAN_QH_QUAN_HUY foreign key (QHID)
      references QUAN_HUYEN (QHID)
go

alter table TAIKHOAN
   add constraint FK_TAIKHOAN_QUYEN_QUYEN foreign key (MAQUYEN)
      references QUYEN (MAQUYEN)
go

alter table TAIKHOAN
   add constraint FK_TAIKHOAN_TP_TINH_THA foreign key (TTPID)
      references TINH_THANHPHO (TTPID)
go

