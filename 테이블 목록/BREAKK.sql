CREATE TABLE "SYSTEM"."BREAKK" 
   (	"처리일자" VARCHAR2(50 BYTE), 
	"신청자" VARCHAR2(20 BYTE), 
	"신청유형" VARCHAR2(20 BYTE), 
	"신청내용" VARCHAR2(50 BYTE), 
	"처리내용" VARCHAR2(20 BYTE), 
	"반려사유" VARCHAR2(50 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;