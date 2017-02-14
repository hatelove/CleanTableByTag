Feature: BookService

@CleanBooks
Scenario: Add the first book 
	Given a book for registering
	| ISBN          | Name  |
	| 9789869094481 | specification by example |	
	When Create
	Then Book table should exist a record
	| ISBN          | Name                     |
	| 9789869094481 | specification by example |	
