Feature: User
	Requesting the User end-points

Scenario: Login
	Given the host is 'https://localhost:5001/'
	And the endpoint is 'User'
	And the http method is 'GET'
	And the e-mail is '<Email>'
	And the password is '<Password>'
	When execute the request
	Then the response should be <StatusCode>

	Examples: 
		| Email          | Password | StatusCode |
		| adm@email.com	 | 123      | 200        |
		| user@email.com | 987      | 200        |
		|				 | 123      | 400        |
		| adm@email.com  |          | 400        |
		|				 |          | 400        |