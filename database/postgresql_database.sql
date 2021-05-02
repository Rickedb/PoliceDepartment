CREATE DATABASE cidade_alta

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
CREATE TABLE users(
    id uuid PRIMARY KEY DEFAULT UUID_GENERATE_V4(),
    username varchar(80) not null,
    password varchar(100) not null
)

CREATE TABLE status(
    id serial primary key,
    name varchar(120) not null
)

CREATE TABLE criminal_codes(
    id serial primary key,
    name varchar(120) not null,
    description varchar(800) not null,
    penalty float not null,
    prison_time int not null,
    status_id int not null,
    create_date timestamp not null default NOW(),
    update_date timestamp not null default NOW(),
    create_user_id uuid not null,
    update_user_id uuid not null,
    FOREIGN KEY(status_id) REFERENCES status(id),
    FOREIGN KEY(create_user_id) REFERENCES users(id),
    FOREIGN KEY(update_user_id) REFERENCES users(id)
)

