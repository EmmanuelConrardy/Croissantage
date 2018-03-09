Feature: Employe
	In order to teach employe to close session
	As an employe
	I want to Croissante all employes not in the place of his computer with an open session.

Background:
    Given Small red team
    | Employe  | Place       |
    | Cecile   | OpenSpace   |
    | Emmanuel | OpenSpace   |
    | Baptiste | SecondFloor |
    | Bruno    | Portugal    |



Scenario: Croissanted an employe
	Given An Employe Cecile at the OpenSpace
	And An Employe Emmanuel at the Coffee
	And Session of Emmanuel is Open
	When Employes try to croissant each others
	Then Emmanuel should be croissanted

#is it always true ?
#What can be happening for the croissantage not working ?
#And if ... (other context)

Scenario: Employed protect his session
	Given An Employe Cecile at the OpenSpace
	And An Employe Emmanuel at the OpenSpace
	And Session of Emmanuel is Open
	When Employes try to croissant each others
	Then Emmanuel should not be croissanted

Scenario: All Employes are gone
	Given An Employe Cecile at the Printer
	And An Employe Emmanuel at the Coffee
	And Session of Emmanuel is Open
	When Employes try to croissant each others
	Then Emmanuel should not be croissanted

#Any kind of exception ?
#What about Baptiste case? his computer is on the second floor

Scenario: Croissanted Baptiste
	Given An Employe Emmanuel at the SecondFloor
	And An Employe Baptiste at the Coffee
	And Session of Baptiste is Open
	When Employes try to croissant each others
	Then Baptiste should be croissanted

Scenario: Croissanted Brono télétravail
	Given An Employe Bruno at the Portugal
	And Session of Bruno is Open
	When Employes try to croissant each others
	Then Bruno should not be croissanted
