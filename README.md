# Keystone.net

## Development notes using non-Windows environment
Make sure you have Docker running. This is required to host SQL Express Local DB.

##### Steps below have been tested on a Mac 10.12.5 with Docker 2.0.0.0-mac81 (2911) and Jetbrain's Rider 2018.2.3

Full guide - [Quickstart on MS Docs](https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-2017)

- Use a similar command to create a container for this image,
    - `sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Passw0rd' -p 1433:1433 --name sqlsrvdev -d mcr.microsoft.com/mssql/server:2017-latest`

