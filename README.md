# WDT_Assignment1

Daniel Milner - s3542977
Tyler Watkins - s3542686

Design pattern justifications:

MVC: 
	The MVC design pattern was used as it allowed for the database/model code to be separated
	from the display/view. Therefore, any changes made to the structure of the database would be 
	isolated to the model and the other parts of the code would remain unchanged. In addition, if
	the school committee outlined in the introduction wished to continue with the project and create
	a web application, the model that has already be developed could be reused with little if any 
	changes. MVC also allowed for tasks to be delegated between the group members easier and therefore
	allowed for a smoother development process. A developer can work on the model while another works
	on the controller with little to no conflicts.

Singleton: 
	This project applied the use of a singleton for two main reasons. Firstly, the model
	class is an expensive class to instantiate due to the fact it must connect and load the entire
	database into memory. This is not an operation that should be done more than one time. This 
	singleton design pattern avoids this by only ever having one instance of the object in memory.
	Secondly, this also avoids the possibility of having multiple concurrent connections to the 
	database which would occur if multiple model objects where created. If multiple model objects 
	where to be created, then each object would soon have different stored data representing the 
	database as changes are made to one instance of the model but not the others.	


