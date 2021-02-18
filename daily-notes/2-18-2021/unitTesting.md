# stuff happening today
- Xunit unit testing
- short tdd activity creating calculator class that takes in inputs, use TDD to take in those inputs
- debugging in VSCode
- using breakpoints, logging, app monitoring, etc.
- solid principles?

# unit testing
- all about testing
- many different types of testing, integration testing, etc.
- unit testing is testing the smallest units of our code - our methods.
- then go a step further to make sure application as a whole works as it should
- it's recommended to test your logic, not so much your UI - the UI will be tested by simply navigating the program, and is part of integration testing.
- good code is readable and also self documenting
- name your test class after whatever the class you're testing against is
- name test methods based on what you're testing for
- 3 parts of a unit test
    - arrange - all about setting up the things you need for the unit test
    - act - doing the thing you want to test
    - assert - comparing the actual results to your expected outcome

# test driven development
- write unit tests first without writing the methods
- we will have a calc thats just empty
- create unit tests without methods first
- then create methods that pass those tests
- does tdd help? questions will be asked after activity


- factory design pattern for menus might be helpful
- P0 requires 10 unit tests
- dotnet new xunit -o ToHTest
- xml comments are required for p0