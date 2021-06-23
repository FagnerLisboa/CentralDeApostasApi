-- Table: public.user

-- DROP TABLE public."user";

CREATE TABLE public."user"
(
    "idUser" integer NOT NULL DEFAULT nextval('"user_idUser_seq"'::regclass),
    guid text COLLATE pg_catalog."default" NOT NULL,
    active integer NOT NULL,
    username text COLLATE pg_catalog."default" NOT NULL,
    login text COLLATE pg_catalog."default" NOT NULL,
    password text COLLATE pg_catalog."default" NOT NULL,
    email text COLLATE pg_catalog."default",
    cell numeric NOT NULL,
    "registrationDate" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT user_pkey PRIMARY KEY ("idUser")
)

TABLESPACE pg_default;

ALTER TABLE public."user"
    OWNER to postgres;