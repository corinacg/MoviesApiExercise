# MoviesApiExercise
Apis:
- Api A example usage: 
    GET http://localhost:5000/api/Movies?title=Dog
    GET http://localhost:5000/api/Movies?releaseYear=2004&genres=drama&genres=thriller
- Api B example usage:
    GET http://localhost:5000/api/TopMovies
- Api C example usage:
    GET http://localhost:5000/api/TopMovies/1
- Api D example usage:
    POST http://localhost:5000/api/UserRatings 
    Body: {"userId":1,
	    "movieId":5,
	    "rating":3}

### Todos
 - Write MORE Tests
 - Maybe add some integration tests
 - Improve query performance - maybe use denormalization and add pre-computed average rating on Movie
 - Add more validation and error handling