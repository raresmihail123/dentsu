i want you to create this frontend for me. I want a webpage that contains the following:
a field for Total Budget that accepts only numbers, and connects to the api endpoint api/solution/getbudget.
a field for Agency Fee that accepts only numbers between 0 and 1, and connects to the api endpoint api/solution/agencyfee.
a field for Third Party Fee that accepts only numbers between 0 and 1, and connects to the api endpoint api/solution/getthirdpartyfee.
a field for Working Hours Fee that accepts only numbers, and connects to the api endpoint api/solution/getworkinghoursfee.
3 fields for adding advertisements to a list seen on the screen, with the fields name, fee and enhanced (this should be a boolean), and connects to the api endpoint api/solution/getnewad/{name}
in the list of advertisements, a delete button for each, that connects to the api endpoint api/solution/deletead{name}
a button for running the algorithm, that connects to the api endpoint api/solution/runalgorithm
