SET check_function_bodies = false;

/* Sequence 'Sequence_Document' */
CREATE SEQUENCE Sequence_Document START WITH 1 INCREMENT BY 1;

/* Sequence 'Sequence_ChangeTracker' */
CREATE SEQUENCE Sequence_ChangeTracker START WITH 1 INCREMENT BY 1;

/* Table 'document' */
CREATE TABLE "document"(
  id bigint NOT NULL,
  revision bigint NOT NULL,
  createdate timestamp NOT NULL,
  modificationdate timestamp NOT NULL,
  value_datetime timestamp NOT NULL,
  value_long bigint NOT NULL,
  value_int integer,
  PRIMARY KEY(id)
) PARTITION BY RANGE (id);

/* Table 'changetracker' */
CREATE TABLE changetracker(id bigint NOT NULL, PRIMARY KEY(id)) PARTITION
  BY RANGE (id);
