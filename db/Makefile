MIGRATE = docker run --rm -it --network=host -v "$(pwd):/db" migrate/migrate -path ./db/migrations -database "postgresql://postgres:root@localhost:5432/twocount?sslmode=disable" -verbose

create_db:
	docker exec -it postgres createdb --username=postgres --owner=root twocount

drop_db:
	docker exec -it postgres dropdb twocount

create_migration:
	${MIGRATE} create -ext sql -dir ./db/migrations -seq $(seq)

migrate_up:
	${MIGRATE} up $(version)

migrate_down:
	${MIGRATE} down $(version)

.PHONY: createdb dropdb create_migration migrate_up migrate_down



