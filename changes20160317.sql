alter table [WPNAMELIST] add WIRINGDIAGRAM	nvarchar(MAX)	
alter table [WPNAMELIST] add TECHREQ	nvarchar(MAX)	
alter table [WPNAMELIST] add SBORKA3D	nvarchar(MAX)	
alter table [WPNAMELIST] add MECHPARTS	nvarchar(MAX)	
alter table [WPNAMELIST] add SHILDS	nvarchar(MAX)	
alter table [WPNAMELIST] add PLANKA	nvarchar(MAX)	
alter table [WPNAMELIST] add SERIAL	nvarchar(MAX)	
alter table [WPNAMELIST] add PACKAGE	nvarchar(MAX)	
alter table [WPNAMELIST] add PASSPORT	nvarchar(MAX)	
alter table [WPNAMELIST] add [MANUAL]	nvarchar(MAX)	
alter table [WPNAMELIST] add PACKAGELIST	nvarchar(MAX)	
alter table [WPNAMELIST] add SOFTWARE	nvarchar(MAX)	
alter table [WPNAMELIST] alter column CONFIGURATION	nvarchar(MAX)	
--��������� ���� (require-field) ��� ����������� ���� ���� ��� ���� ��� ��� � ������ �������,
--� ����� ��� ���� ����� ��������� �� �� ���� ������������ ��� ���.
--���� 4 ������� �������:
--RUNCARDLIST, CIRCUITBOARDLIST,CABLELIST,ZHGUTLIST
--��� ������, ��� ��� ������� �������
--� ��� ������� �� WPNAMELIST. ��� ��� ���� ���� ������� require-field
alter table WPNAMELIST add COMPOSITIONREQ	bit default(0)
alter table WPNAMELIST add DIMENSIONALDRAWINGREQ	bit default(0)
alter table WPNAMELIST add POWERSUPPLYREQ		bit default(0)
alter table WPNAMELIST add CONFIGURATIONREQ		bit default(0)
alter table WPNAMELIST add WIRINGDIAGRAMREQ		bit default(0)
alter table WPNAMELIST add TECHREQREQ		bit default(0)
alter table WPNAMELIST add SBORKA3DREQ		bit default(0)
alter table WPNAMELIST add MECHPARTSREQ		bit default(0)
alter table WPNAMELIST add SHILDSREQ		bit default(0)
alter table WPNAMELIST add PLANKAREQ		bit default(0)
alter table WPNAMELIST add SERIALREQ		bit default(0)
alter table WPNAMELIST add PACKAGEREQ		bit default(0)
alter table WPNAMELIST add PASSPORTREQ		bit default(0)
alter table WPNAMELIST add [MANUALREQ]		bit default(0)
alter table WPNAMELIST add PACKAGELISTREQ		bit default(0)
alter table WPNAMELIST add SOFTWAREREQ		bit default(0)
alter table WPNAMELIST add CABLELISTREQ bit default(0)
alter table WPNAMELIST add ZHGUTLISTREQ		bit default(0)
alter table WPNAMELIST add RUNCARDLISTREQ		bit default(0)
alter table WPNAMELIST add CIRCUITBOARDLISTREQ		bit default(0)

alter table CATEGORYLIST add ENTITY nvarchar(100)
--����� �������� �������� � ENTITY ����� ������� ��� �� ����
alter table CATEGORYLIST alter column ENTITY nvarchar(100) not null

update STATUSLIST set SNAME = '���������� (���)' where ID = 8

--��� ��������� ���������?
--����� �������:
--RUNCARD,CIRCUITBOARDS,ZHGUTS,CABLES
--CABLELIST,ZHGUTLIST
--RUNCARDLIST � CIRCUITBOARDLIST ������� ���� ���
update WPNAMELIST set
      [COMPOSITIONREQ] = 0
      ,[DIMENSIONALDRAWINGREQ] = 0
      ,[POWERSUPPLYREQ] = 0
      ,[CONFIGURATIONREQ] = 0
      ,[WIRINGDIAGRAMREQ] = 0
      ,[TECHREQREQ] = 0
      ,[SBORKA3DREQ] = 0
      ,[MECHPARTSREQ] = 0
      ,[SHILDSREQ] = 0
      ,[PLANKAREQ] = 0
      ,[SERIALREQ] = 0
      ,[PACKAGEREQ] = 0
      ,[PASSPORTREQ] = 0
      ,[MANUALREQ] = 0
      ,[PACKAGELISTREQ] = 0
      ,[SOFTWAREREQ] = 0
      ,[CABLELISTREQ] = 0
      ,[ZHGUTLISTREQ] = 0
      ,[RUNCARDLISTREQ] = 0
      ,[CIRCUITBOARDLISTREQ] = 0
      