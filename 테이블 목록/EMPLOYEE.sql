CREATE TABLE "SYSTEM"."EMPLOYEE" 
   (	"ENUM" NUMBER, 
	"ENAME" VARCHAR2(20 BYTE), 
	"ERRN" VARCHAR2(20 BYTE), 
	"ESEX" VARCHAR2(20 BYTE), 
	"EPNUM" VARCHAR2(20 BYTE), 
	"EMAIL" VARCHAR2(100 BYTE), 
	"EADD" VARCHAR2(100 BYTE), 
	"ETEAM" VARCHAR2(20 BYTE), 
	"ERANK" VARCHAR2(20 BYTE), 
	"EJOIND" VARCHAR2(20 BYTE), 
	"ELEAVD" VARCHAR2(20 BYTE), 
	"EWORK" VARCHAR2(20 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;