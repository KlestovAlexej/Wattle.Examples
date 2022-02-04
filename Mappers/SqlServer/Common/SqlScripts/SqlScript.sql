
CREATE TABLE Object_A
( 
	Id                   bigint  NOT NULL ,
	Revision             bigint  NOT NULL ,
	Value_DateTime       datetime  NOT NULL ,
	Value_Long           bigint  NOT NULL ,
	Value_Int            integer  NULL ,
	Value_String         ntext  NULL ,
	Value_DateTime_NotUpdate datetime  NOT NULL 
)
go



ALTER TABLE Object_A
	ADD CONSTRAINT XPKObject_A PRIMARY KEY  CLUSTERED (Id ASC)
go



CREATE TABLE Object_B
( 
	Id                   bigint  NOT NULL ,
	Revision             bigint  NOT NULL ,
	CreateDate           datetime  NOT NULL ,
	Available            bit  NOT NULL 
)
go



ALTER TABLE Object_B
	ADD CONSTRAINT XPKObject_B PRIMARY KEY  CLUSTERED (Id ASC)
go



CREATE SEQUENCE Sequence_Object_A START WITH 1 INCREMENT BY 1;



