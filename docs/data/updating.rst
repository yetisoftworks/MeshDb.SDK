.. |parameters| raw:: html

   <h4>Parameters</h4>
   
   -----------
Update data
-----------
Update Mesh data in collection by id.

.. tabs::

   .. group-tab:: REST
   
      .. code-block:: http

         PUT https://api.meshydb.com/{clientKey}/meshes/{mesh}/{id}  HTTP/1.1
         Authentication: Bearer {access_token}
         Content-Type: application/json

         {
          "firstName": "Bobbo",
          "lastName": "Bobberson"
         }

      |parameters|

      clientKey : string
         Indicates which tenant you are connecting for authentication.
      access_token : string
         Token identifying authorization with MeshyDB requested during `Generating Token <authorization/generating_token.html#generating-token>`_.
      mesh : string
         Identifies name of mesh collection. e.g. person.
      id : string
         Idenfities location of what Mesh data to replace.

   .. group-tab:: C#
   
      .. code-block:: c#

         var database = new MeshyDB(clientKey, publicKey);
         var client = await database.LoginWithAnonymouslyAsync();
         
         person.FirstName = "Bobbo";

         person = await client.Meshes.UpdateAsync(person);
         
      |parameters|

      clientKey : string
         Indicates which tenant you are connecting for authentication.
      publicKey : string
         Public accessor for application.
      mesh : string
         Identifies name of mesh collection. e.g. person.
      id : string
         Idenfities location of what Mesh data to replace.

Example Response:

.. code-block:: json

  {
    "_id":"5c78cc81dd870827a8e7b6c4",
    "firstName": "Bobbo",
    "lastName": "Bobberson",
    "_rid":"https://api.meshydb.com/{clientKey}/meshes/{mesh}/5c78cc81dd870827a8e7b6c4"
  }
