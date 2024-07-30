# km-pinewoodtask

This readme file describes some basic details about the implementation. I have used SQL Lite for the first time so it took a little while to setup and configure as I did not want to use SQL Server which I have used quite a lot in the past and it might not have been straighforward to run the application from the repository as it would have reuqired a backup file to be added to repository and restored.

I have used the built in scaffolded templates for the create, edit and delete operations keeping things simple. I could have implemented the API within the web application as well and or used javaascript to call the APIs but I have kept it simple from a .NET developer's perspective. 

The functionality could be extended by introducing server side model validation to ensure no invalid data gets added to the database along with enhancing the validation rules for the customer fields. Only a handful of fields were added due to time constraints. 
