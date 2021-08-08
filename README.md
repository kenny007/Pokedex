# Pokedex API

This is a fun API for returning Pokemon Information

* Given a Pokemon name, returns standard Pokemon description and additional information
```sh
GET /pokemon/pokemonname   
```
* Given a pokemon name, return translated pokemon description and other basic information
```sh
GET /pokemon/translated/pokemonname   
```

## Running
* Clone or download the repository
* Open the project in either Visual Studio or IntelliJ Rider 
* Ensure nuget packages are restored this can be done from the project directory using
   ```sh
	 nuget restore Pokedex.sln
	 ```
* Run the project from your chosen IDE this will open a swagger browser from where you can
enter pokemonname for endpoints

### Improvements
- The result returned by endpoints can be stored in a cache for faster retrievals of subsequent calls with same parameters
- Error handling can be improved to return more useful errors in a production environment
- More tests can be added 
- Requests should also be logged

