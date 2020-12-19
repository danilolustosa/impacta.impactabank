Feature: Account
	Requesting end-points of Account

Scenario: Insert
Given the endpoint is 'Account/insert'
	#And the host is 'https://localhost:5001/'
	And the http method is 'POST'
	#And the token is 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFkbUBlbWFpbC5jb20iLCJuYW1laWQiOiIxIiwicm9sZSI6IkEiLCJuYmYiOjE2MDgzOTg4OTAsImV4cCI6MTYwODQwNjA5MCwiaWF0IjoxNjA4Mzk4ODkwfQ.dHPOVQHhu44CGSa5pxbTRuxpZcer3sI-0vPZdoDeTcA'
	And the CustomerId is <CustomerId>
	And the Situation is '<Situation>'
	When execute the request
	Then the response should be <StatusCode>

	Examples: 
		| CustomerId | Situation | StatusCode |
		| 1          | A         | 201        |
		| 0          | A         | 400        |
		| 1          |           | 400        |
		| 0          |           | 400        |



Scenario: Update
Given the endpoint is 'Account/update'
	#And the host is 'https://localhost:5001/'
	And the http method is 'PUT'
	#And the token is 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFkbUBlbWFpbC5jb20iLCJuYW1laWQiOiIxIiwicm9sZSI6IkEiLCJuYmYiOjE2MDgzOTg4OTAsImV4cCI6MTYwODQwNjA5MCwiaWF0IjoxNjA4Mzk4ODkwfQ.dHPOVQHhu44CGSa5pxbTRuxpZcer3sI-0vPZdoDeTcA'
	And the AccountId is 5
	And the CustomerId is 2
	And the Situation is 'I'
	When execute the request
	Then the response should be 200