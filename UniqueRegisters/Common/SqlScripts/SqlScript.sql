SET check_function_bodies = false;

/* Sequence 'Sequence_TransactionKey' */
CREATE SEQUENCE Sequence_TransactionKey START WITH 1 INCREMENT BY 1;

/* Table 'transactionkey' */
CREATE TABLE transactionkey(
  id bigint NOT NULL,
  "key" uuid NOT NULL,
  tag bigint NOT NULL,
  PRIMARY KEY(id)
) PARTITION BY RANGE (id);
