SET check_function_bodies = false;

/* Sequence 'Sequence_Object_A' */
CREATE SEQUENCE Sequence_Object_A START WITH 1 INCREMENT BY 1;

/* Table 'object_b' */
CREATE TABLE object_b(
  id bigint NOT NULL,
  revision bigint NOT NULL,
  createdate timestamp NOT NULL,
  modificationdate timestamp NOT NULL,
  state smallint NOT NULL,
  PRIMARY KEY(id)
);

/* Table 'object_a' */
CREATE TABLE object_a(
  id bigint NOT NULL,
  revision bigint NOT NULL,
  createdate timestamp NOT NULL,
  modificationdate timestamp NOT NULL,
  state smallint NOT NULL,
  PRIMARY KEY(id)
) PARTITION BY RANGE (id);

/* Table 'object_c' */
CREATE TABLE object_c(
  id bigint NOT NULL,
  revision bigint NOT NULL,
  createdate timestamp NOT NULL,
  modificationdate timestamp NOT NULL,
  state smallint NOT NULL,
  available bit NOT NULL,
  PRIMARY KEY(id)
);
