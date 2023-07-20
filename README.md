# multiple-tenant-ef-solution

The project emphasizes implementing multi-tenancy functionality using PostgreSQL RLS and Entity Framework.

## Notice:
1. Ensure that there are no services occupying ports `5432`, `5435`, `8000`, and `8888` on the local machine.
2. Ensure that you have installed `docker` and `docker-compose`.

## Deploy:
1. Open terminal `cmd`
2. Change directory to project  
```bash
$cd ../multiple-tenant-ef-solutionmultiple-tenant-solution
```
3. Deployed `docker-compose`  

```bash
$docker-compose --env-file docker-compose.env up -d  
```
