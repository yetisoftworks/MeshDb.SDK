
.. |parameters| raw:: html

   <h4>Parameters</h4>
   
--------------------
Retrieving User Info
--------------------
Retrieve user information.

.. tabs::

   .. group-tab:: REST
   
      .. code-block:: http
      
        GET https://auth.meshydb.com/{clientKey}/connect/userinfo HTTP/1.1
        Authentication: Bearer {access_token}

      |parameters|
      
      clientKey : string
         Indicates which tenant you are connecting for authentication.
      access_token  : string
         Token identifying authorization with MeshyDB requested during `Generating Token <../authorization/generating_token.html#generating-token>`_.

   .. group-tab:: C#
   
      .. code-block:: c#
      
        var database = new MeshyDB(clientKey, publicKey);
        var client = await database.LoginWithAnonymouslyAsync();

        var userInfo = await client.GetMyUserInfoAsync();

      |parameters|
      
      clientKey : string
         Indicates which tenant you are connecting for authentication.
      publicKey : string
         Public accessor for application.

Example Response:

.. code-block:: json

   {
       "sub": "5c990a772a8fc94ec4b3dc20",
       "name": "",
       "given_name": "",
       "family_name": "",
       "id": "login@email.com",
       "rate_limit": "10",
       "role": "admin"
   }
