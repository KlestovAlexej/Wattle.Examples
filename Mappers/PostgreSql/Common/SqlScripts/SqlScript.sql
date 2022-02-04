SET check_function_bodies = false;

/* Sequence 'Sequence_Object_A' */
CREATE SEQUENCE Sequence_Object_A START WITH 1 INCREMENT BY 1;

/* Table 'object_a' */
CREATE TABLE object_a(
  id bigint NOT NULL,
  revision bigint NOT NULL,
  value_datetime timestamp NOT NULL,
  value_long bigint NOT NULL,
  value_int integer,
  value_string text,
  value_datetime_notupdate timestamp NOT NULL,
  PRIMARY KEY(id)
) PARTITION BY RANGE (id);

/* Table 'object_b' */
CREATE TABLE object_b(
  id bigint NOT NULL,
  revision bigint NOT NULL,
  createdate timestamp NOT NULL,
  available boolean NOT NULL,
  PRIMARY KEY(id)
);
