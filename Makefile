.PHONY: build
build:
	cd ui && npm run build && cd ..


.PHONY: run
run: build
	dotnet run	

.PHONY: start
start: 
	dotnet run	