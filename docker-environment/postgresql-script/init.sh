#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname="$POSTGRES_DB"<<-EOSQL
   BEGIN;
   CREATE DATABASE twocount;
   CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
   COMMIT;
EOSQL
