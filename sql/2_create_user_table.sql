CREATE TABLE IF NOT EXISTS users (
    id UUID DEFAULT uuid_generate_v4 (),
    username VARCHAR NOT NULL,
    password_hash VARCHAR NOT NULL,
    password_salt VARCHAR NOT NULL
);