alter table ALPHA..SUMMON add CONTRACTTYPE nvarchar(500)
update ALPHA..SUMMON set CONTRACTTYPE = '�����������'
alter table ALPHA..SUMMON alter column CONTRACTTYPE nvarchar(500) not null



