mongosh

show dbs
use mydb
show collections

db.createCollection("products")
db.products.insertOne({name: "Bob"});
db.products.find()