.. |parameters| raw:: html

   <h4>Parameters</h4>
   
-----------------
Changing Password
-----------------
Allows the logged in user to change their password.

.. tabs::

   .. group-tab:: REST
   
      .. code-block:: http
      
         POST https://api.meshydb.com/{clientKey}/users/me/password HTTP/1.1
         Authentication: Bearer {access_token}
         Content-Type: application/json

           {
             "newPassword": "newPassword",
             "previousPassword": "previousPassword"
           }

      |parameters|
      
      clientKey : string
         Indicates which tenant you are connecting for authentication.
      access_token: string
         Token identifying authorization with MeshyDB requested during `Generate Access Token <auth.html#generate-access-token>`_.
      previousPassword : string
        Previous password of user.
      newPassword : string
        New password of user.

   .. group-tab:: C#
   
      .. code-block:: c#
      
         var database = new MeshyDB(clientKey, publicKey);
         var client = await database.LoginWithAnonymouslyAsync();

         await client.UpdatePasswordAsync(previousPassword, newPassword);

      |parameters|
      
      clientKey : string
         Indicates which tenant you are connecting for authentication.
      publicKey : string
         Public accessor for application.
      previousPassword : string
        Previous password of user.
      newPassword : string
        New password of user.
