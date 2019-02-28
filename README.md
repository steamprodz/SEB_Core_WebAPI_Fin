# SEB_Core_WebAPI_Fin

SEB.bak - SQLSERVER database dump file

Main controller: CustomBundlesController

Other controllers are for testing purpose

API:
/api/values - default

/api/custombundles - working


GET: api/custombundles - get all bundles
GET: api/custombundles/5 - get bundle by Id
POST: api/custombundles - create and retrieve recommended bundle
POST: api/custombundles/addproduct - add product to bundle
POST: api/custombundles/validate - validate bundle using the given question
PUT: api/custombundles/updateproduct - update product in a bundle
DELETE: api/custombundles/deleteproduct - delete product in a bundle
