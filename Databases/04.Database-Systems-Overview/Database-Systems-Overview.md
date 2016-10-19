## Database Systems - Overview
### _Homework_

#### Answer following questions in Markdown format (`.md` file)

1.  What database models do you know?
    - Early data models
        - Hierarchical model
        - Network model
        - Inverted file model
    - Relational model
        - Dimensional model
    - Post-relational database models
        - Graph model
        - Multivalue model
        - Object-oriented model

1.  Which are the main functions performed by a Relational Database Management System (RDBMS)?
    - backup and recovery management
    - transaction management
    - multiuser access control
    - data storage management
    - database access languages and application programming interfaces

1.  Define what is "table" in database terms.
    - A table is a collection of related data held in a structured format within a database. It consists of columns, and rows.

1.  Explain the difference between a primary and a foreign key.
    - Primary Key
        - Primary key cannot have a NULL value.
        - Identifies each record in a database table.
        - Must contain UNIQUE values.
    - Foreign Key
        - A FOREIGN KEY in one table points to a PRIMARY KEY in another table.
        - Foreign key can accept multiple null value.
        - We can have more than one foreign key in a table.
1.  Explain the different kinds of relationships between tables in relational databases.
    - One-to-Many Relationship
        - In this type of relationship, a row in table A can have many matching rows in table B, but a row in table B can have only one matching row in table A.
    - Many-to-Many Relationships
        -  In a many-to-many relationship, a row in table A can have many matching rows in table B, and vice versa.
    - One-to-One Relationships
        - In a one-to-one relationship, a row in table A can have no more than one matching row in table B, and vice versa.
        - A one-to-one relationship is created if both of the related columns are primary keys or have unique constraints.

1.  When is a certain database schema normalized?
    - The objective is to isolate data so that additions, deletions, and modifications of an attribute can be made in just one table and then propagated through the rest of the database using the defined foreign keys.

    - What are the advantages of normalized database
        - Smaller database: By eliminating duplicate data, you will be able to reduce the overall size of the database.
        - Better performance: Fewer indexes per table mean faster maintenance tasks such as index rebuilds. Only join tables that you need.
        - Narrow tables: Having more fine-tuned tables allows your tables to have less columns and allows you to fit more records per data page.
        
1.  What are database integrity constraints and when are they used?
    - Primary Key Constraints
    - Unique Constraints
    - Foreign Key Constraints
    - NOT NULL Constraints
    - Check Constraints
    - Dropping Constraints
    
1.  Point out the pros and cons of using indexes in a database.
    - Advantages:
        - Faster lookup for results. This is all about reducing the number of Disk IO's. Instead of scanning the entire table for the results, you can reduce the number of disk IO's(page fetches) by using index structures such as B-Trees or Hash Indexes to get to your data faster.
    - Disadvantages:
        - Slower writes(potentially). Not only do you have to write your data to your tables, but you also have to write to your indexes. This may cause the system to restructure the index structure(Hash Index, B-Tree etc), which can be very computationally expensive.
        - Takes up more disk space, naturally. You are storing more data.

1.  What's the main purpose of the SQL language?
    - SQL allows users to access data stored in a relational database management system.
    - Execute comands for manipulating the data in the DB
        - SELECT - get information from the DB
        - INSERT - insert data in the DB
        - UPDATE - update data in the DB
        - DELETE - delete data from the DB
    
1.  What are transactions used for?
    - A transaction is a set of changes that must all be made together.
    - Transaction is executed as a single unit.
    - If transaction fails it will end up in ROLLBACK statement and the transaction will end, undoing any work performed since the beginning of the transaction and the data will be untouched.
    - Example:
        - transfer of money from one bank account to another requires two changes to the database both must succeed or fail together.

1.  What is a NoSQL database?
    -  A NoSQL database provides a mechanism for storage and retrieval of data that is modeled in means other than the tabular relations used in relational databases.
    - The data structures used by NoSQL databases differ from those used in relational databases, making some operations faster.

1.  Explain the classical non-relational data models.
    - The non-relational data model would look like a sheet of paper.
    - The concept of one entity and all the data that pertains to that one entity is known in Mongo as a “document”.

1.  Give few examples of NoSQL databases and their pros and cons
    - MongoDB - Open-source document database.
    - CouchD - Database that uses JSON for documents, JavaScript for MapReduce queries, and regular HTTP for an API.
    - Redis - Data structure server wherein keys can contain strings, hashes, lists, sets, and sorted sets.
    - Cassandra - Database that provides scalability and high availability without compromising performance. memcached. Open source high-performance, distributed-memory, and object-caching system.