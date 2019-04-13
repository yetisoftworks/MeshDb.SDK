.. |parameters| raw:: html

   <h4>Parameters</h4>
   
----------------------
Generate Refresh Token
----------------------

Using the token request made to generate an access token, a refresh token will also be generated. Once the token expires the refresh token can be used to generate a new set of credentials for authorized calls.

.. tabs::

   .. group-tab:: REST
   
      .. code-block:: http
      
         POST https://auth.meshydb.com/{clientKey}/connect/token HTTP/1.1
         Content-Type: application/x-www-form-urlencoded

            client_id={publicKey}&
            grant_type=refresh_token&
            refresh_token={refresh_token}

        
      (Form-encoding removed and line breaks added for readability)

      |parameters|

      clientKey : string
         Indicates which tenant you are connecting for authentication.
      publicKey : string
         Public accessor for application.
      refresh_token : string
         Refresh token generated from  previous access token generation.

   .. group-tab:: C#
   
      .. code-block:: c#

        var database = new MeshyDB(clientKey, publicKey);
        var client = database.LoginWithPassword(username, password);
        var refreshToken = client.RetrievePersistanceToken();
        
        client = await database.LoginWithPersistanceAsync(refreshToken);

      |parameters|

      clientKey : string
         Indicates which tenant you are connecting for authentication.
      publicKey : string
         Public accessor for application.
      username : string
         User name.
      password : string
         User password.
      refresh_token : string
         Refresh token generated from  previous access token generation.
   
Example Response:

.. code-block:: json

  {
    "access_token": "ey...",
    "expires_in": 3600,
    "token_type": "Bearer",
    "refresh_token": "ab23cd3343e9328g"
  }
