Feature: Main view - How to manage the different lists
	In order to manage the diferrent lists
	As a user
	I want to make the basic operations

@ID:83491912-EE62-4204-B7B3-9F2CD15B8D90
@Owner: Juan Serna
Scenario: Main View - With an empty view the user can see a motivational phrase
	Given The application is running with the 'Default' configuration
	When The application does not have any tasks
	Then The user sees a proverb
