# Getting started
The first thing we need is some MeshyDB credentials. If you have not you can get started with a free account at [MeshyDB.com](https://meshydb.com).

Once we have done that we can go to Account and get our Client Key and Public Key.

Now that we have the required information let's jump in and see how easy it is to start with MeshyDB.

## Login
Let's log in using our MeshyDB credentials.

``` REST
POST https://auth.meshydb.com/{clientKey}/connect/token
Body(x-www-form-urlencoded):  
  client_id={publicKey}&grant_type=password&username={username}&password={password}&scope=meshy.api%20offline_access

Example Response:
  {
    "access_token": "ey...",
    "expires_in": 3600,
    "token_type": "Bearer",
    "refresh_token": "ab23cd3343e9328g"
  }
```

```c#
  var database = new MeshyDB({clientKey}, {publicKey});
  var client = database.LoginWithPassword({username}, {password});
```

_clientKey_: 
  Indicates which tenant you are connecting for authentication.
  
_publicKey_: 
  Public accessor for application.
  
_username_:
  User name.

_password_:
  User password.
 
## Create data
Now that we are logged in we can use our Bearer token to authenticate requests with MeshyDB and create some data.

The data object can whatever information you would like to capture. The following example will have some data fields with example data.

``` REST
POST https://api.meshydb.com/{clientKey}/meshes/{mesh}
Headers:
  Authentication: Bearer {access_token}
Body(json):
  {
    "firstName": "Bob",
    "lastName": "Bobberson"
  }
  
Example Response:
  {
    "_id":"5c78cc81dd870827a8e7b6c4",
    "firstName": "Bob",
    "lastName": "Bobberson"
    "_rid":"https://api.meshydb.com/{clientKey}/meshes/{mesh}/5c78cc81dd870827a8e7b6c4"
  }
```

```c#
// Mesh is derived from class name
public class Person: MeshData
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
}

var person = await client.Meshes.CreateAsync(new Person(){
  FirstName="Bob",
  LastName="Bobberson"
});
```

_clientKey_: 
  Indicates which tenant you are connecting for authentication.
 
_access_token_:
  Token identifying authorization with MeshyDB requested during [Login](#login)
  
_mesh_:
  Identifies name of mesh collection. e.g. person.

## Update data
If we need to make a modificaiton let's update our Mesh!

``` REST
PUT https://api.meshydb.com/{clientKey}/meshes/{mesh}/{id}
Headers:
  Authentication: Bearer {access_token}
Body(json):
  {
    "firstName": "Bobbo",
    "lastName": "Bobberson"
  }
  
Example Response:
  {
    "_id":"5c78cc81dd870827a8e7b6c4",
    "firstName": "Bobbo",
    "lastName": "Bobberson"
    "_rid":"https://api.meshydb.com/{clientKey}/meshes/{mesh}/5c78cc81dd870827a8e7b6c4"
  }
```

```c#
person.FirstName = "Bobbo";

person = await client.Meshes.UpdateAsync(person);
```

_clientKey_: 
  Indicates which tenant you are connecting for authentication.
 
_access_token_:
  Token identifying authorization with MeshyDB requested during [Login](#login)
  
_mesh_:
  Identifies name of mesh collection. e.g. person.

_id_:
  Idenfities location of what Mesh data to replace.

## Search data
Let's see if we can find Bobbo.


``` REST
GET https://api.meshydb.com/{clientKey}/meshes/{mesh}?filter={filter}&orderby={orderby}&page={page}&pageSize={pageSize}
Headers:
  Authentication: Bearer {access_token}
  
Example Response:
  {
    "page": 1,
    "pageSize": 25,
    "results": [{
                 "_id":"5c78cc81dd870827a8e7b6c4",
                 "firstName": "Bobbo",
                 "lastName": "Bobberson"
                 "_rid":"https://api.meshydb.com/{clientKey}/meshes/{mesh}/5c78cc81dd870827a8e7b6c4"
               }],
    "totalRecords": 1
  }
```

```c#
var pagedPersonResult = await client.Meshes.SearchAsync<Person>({filter},{page},{pageSize});
```

_clientKey_: 
  Indicates which tenant you are connecting for authentication.
 
_access_token_:
  Token identifying authorization with MeshyDB requested during [Login](#login)
  
_mesh_:
  Identifies name of mesh collection. e.g. person.

_filter_:
  Filter criteria for search. Uses MongoDB format.
  
_orderby_:
  How to order results.
  
_page_:
  Which page to return

_pageSize_:
  Number of results to bring  back. Maximum is 200.
  
## Delete data
We are now done with our data, so let us clean up after ourselves.

``` REST
DELETE https://api.meshydb.com/{clientKey}/meshes/{mesh}/{id}
Headers:
  Authentication: Bearer {access_token}
```

```c#
await client.Meshes.DeleteAsync(person);
```

_clientKey_: 
  Indicates which tenant you are connecting for authentication.
 
_access_token_:
  Token identifying authorization with MeshyDB requested during [Login](#login)
  
_mesh_:
  Identifies name of mesh collection. e.g. person.

_id_:
  Idenfities location of what Mesh data to delete.
  
## Sign out
Now the user is complete. Let us sign out so someone else can have a try.

``` REST
POST https://auth.meshydb.com/{clientKey}/connect/token
Body(x-www-form-urlencoded):  
  client_id={clientKey}&grant_type=refresh_token&token={refresh_token}
```

```c#
await client.SignoutAsync();
```
_clientKey_: 
  Indicates which tenant you are connecting for authentication.
 
_refresh_token_:
  Token to allow reauthorization with MeshyDB after the access token expires requested during [Login](#login)
