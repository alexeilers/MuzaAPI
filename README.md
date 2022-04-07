# MUZA

Welcome to Muza, the music collector's database for storing, cataloging, and rating your favorite artists and albums.

Muza was created by Tony Albacete, Alex Eilers, Bryon Pearson, and Matthew Russell. Using the Agile methodology, we organized our user stories, tasks, and goals using a Kanban style framework. We set goals for when tasks needed to be completed, and moved them through the framework as needed.

https://miro.com/app/board/uXjVOB1uEgw=/

Through rigorous testing of our code and endpoints, we completed a comprehensive database utilizing full CRUD for Artists, Albums, and Ratings.

# Endpoint Details

## CREATE
#### Created POST requests creating the following entities and properties:

Artists: Name, Genre, Description, Year Created, List of Albums.
Albums: Artist, Title, Description, Song List.
Artist Rating: Artist, Rating.
Album Rating: Album, Rating.


## READ
#### Created GET requests that pulled the following:

Artists: Get by Artist Id, Get All Artists, Get Artist by Name.
Albums: Get All Albums, Get Albums by Artist Id, Get Album by Id, Get Albums by Artist.
Artist Rating: Get All Artist Ratings.
Album Rating: Get All Album Ratings, Get Album Ratings by Id.


## UPDATE
#### Created PUT requests that updated the following:

Artists: Name, Genre, Description, Year Created.
Album: Description, Song List.
Artist Rating: Rating.
Album Rating: Rating.


## DELETE
#### Created DELETE requests that deleted each entity.