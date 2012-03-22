DROP TABLE "WEB_PROGRAMM";
DROP TABLE "WEB_TYP";
DROP TABLE "WEB_AA";
DROP TABLE "WEB_DATEN";
DROP SEQUENCE daten_seq;

CREATE TABLE "WEB_PROGRAMM"
(
  pname varchar2(50),
  path varchar2(255),
  i_typ_name varchar(50),
  o_typ_name varchar(50)
);

CREATE TABLE "WEB_TYP"
(
  tname varchar(50)
);

CREATE TABLE "WEB_AA"
(
  programm_pname varchar(50),
  daten_did integer
);

CREATE TABLE "WEB_DATEN"
(
  did integer,
  typ_tname varchar2(50),
  data varchar2(1024) 
);

CREATE SEQUENCE daten_seq;

INSERT INTO "WEB_PROGRAMM" (PNAME, PATH, O_TYP_NAME) VALUES ('P1 - Start', 'Program1.aspx', 'String');
INSERT INTO "WEB_PROGRAMM" (PNAME, PATH, I_TYP_NAME) VALUES ('P2 - Ende', 'Program2.aspx', 'String');
INSERT INTO "WEB_PROGRAMM" (PNAME, PATH, I_TYP_NAME, O_TYP_NAME) VALUES ('P3 - StringRev', 'Program3.aspx', 'String', 'String');

INSERT INTO "WEB_TYP" (TNAME) VALUES ('String');
INSERT INTO "WEB_TYP" (TNAME) VALUES ('Float');
INSERT INTO "WEB_TYP" (TNAME) VALUES ('Integer');
commit;