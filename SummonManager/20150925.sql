alter table ALPHA..SUMMON add SHILDREQ bit default(1)
alter table ALPHA..SUMMON add PLANKAREQ bit default(1)
alter table ALPHA..SUMMON add SBORKA3DREQ bit default(1)
alter table ALPHA..SUMMON add SERIALREQ bit default(1)
alter table ALPHA..SUMMON add COMPOSITIONREQ bit default(1)
alter table ALPHA..SUMMON add METALREQ bit default(1)

alter table ALPHA..NOTIFICATIONS add CREATED datetime 

update ALPHA..SUMMON set SHILDREQ = 1,PLANKAREQ=1, SBORKA3DREQ = 1, SERIALREQ =1,COMPOSITIONREQ =1,METALREQ=1

