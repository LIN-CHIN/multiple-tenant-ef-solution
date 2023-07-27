# multiple-tenant-ef-solution
This project mainly focuses on implementing a multi-tenancy solution using PostgreSQL RLS and Entity Framework, rather than concentrating on error handling, API responses, or other details.

## Notice:
1. Ensure that there are no services occupying ports `5432`, `5435`, `8000`, and `8888` on the local machine.
2. Ensure that you have installed `docker` and `docker-compose`.

## Deploy:
1. Open terminal `cmd`
2. Switch to the directory where the project with docker-compose is located."
```bash
$cd .../multiple-tenant-ef-solution
```
3. Deployed `docker-compose`  

```bash
$docker-compose --env-file docker-compose.env up -d  
```

## Demo:
You can use the Postman documentation provided in this project to help you demonstrate examples of RLS (Row-Level Security).

### Step 1: Query materials
You can first try to execute the 'Query-Material' for 'CompanyA,' 'CompanyB,' and 'admin.' You will find that currently there are no materials present in the database table.

### Step 2: Insert material for `CompanyA`
Now you can execute the `Insert-Material` in the `CompanyA` folder.

### Step 3: Observation data
You can execute the `Step 1` again and observe the returned data.

#### When you execute the query in the `CompanyA` or `Admin` folder:
You will find that a new record with the material number `A001` and material name `A-Company-A001` has been successfully added.

#### When you execute the query in the `CompanyB` folder:
You will not find any data.

### Step 4: Try using `CompanyB` to delete data from `CompanyA`
You can execute the `Delete-Material` in the `CompanyB` folder and specify the ID returned from `Step 2` in the URL.
You will receive a system error message.
> If you have been following the demo steps consistently, there is no need to change anything."

### Step 5: Insert material for `CompanyB`
Now you can execute the `Insert-Material` in the `CompanyB` folder.

### Step 6: Observation data
You can execute the `Step 1` again and observe the returned data.

#### When you execute the query in the `CompanyA` folder:
You will only see data with the material name `A-Company-A001`, and not the one added in `Step 5`, `B-Company-A001`.

#### When you execute the query in the `CompanyB` folder:
You will find that a new record with the material number `A001` and material name `B-Company-A001` has been successfully added.

#### When you execute the query in the `Admin` folder:
You will see two records, `A-Company-A001` and `B-Company-A001`."

### Step 7: Update material for `CompanyA`
Now you can execute the `Update-Material` in the `CompanyA` folder, followed by running the query in the same folder. You will notice that the material names have been modified.
> If you update with the ID obtained in step 5, you will receive an error message.

### Step 8: Create user for `CompanyA`
Next, we will attempt to add a new user for `CompanyA` by executing the `Create-User`.

### Step 9: Query material by `A-user-2`
If you execute `Query-Material-User2`, you will only retrieve data related to `CompanyA`, not `CompanyB` or any other companies.


### Step 10: Give it a try yourself
The presentation concludes at this point. For the rest, feel free to try it out on your own!