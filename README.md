AND Digital Tech Test API Documentation

Get request with the endpoint - (http://localhost:51003/api/getallcustomers) 
This will return a list of all customers and all phonenumbers associated with them.

Get request with the endpoint - (http://localhost:51003/api/getcustomerbyid/) followed by the Id of the customer you would like to return.
This will return the details of the customer you requested.

Post request with the endpoint - (http://localhost:51003/api/updatecustomer) 
In the body as raw application/json you should insert the updated details of the customer you would like to update in the following format --


{
    
"Id": 1,
    
"Name": "Tim Adams",
    
"PhoneNumbers": [
    
{
            
"TelephoneNumber": "07123456789",
            
"Active": false
        
}
    
],
    

}

Id = int
Name = string
TelephoneNumber = string
Active = bool
