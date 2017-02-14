Feature: BookService


Scenario: Add the first book 
	Given a book for registering
	| ISBN          | Name  |
	| 9789869094481 | 玩出好創意 |	
	When Create
	Then Book table should exist a record
	| ISBN          | Name  |
	| 9789869094481 | 玩出好創意 |	
