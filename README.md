# ExampleApacheIgniteQueryCompositeObjectNET
Example of Apache Ignite where there is an object which have composite primary key in C#, and want to make the following query
```C#
new SqlFieldsQuery("select _val,_key from TestObject where NAME=? and VALUE=?", "h1","value1"); 
```

There is a table "TESTOBJECT" with 2 PK NAME and ID and a 1 column VALUE

TESTOBJECT

NAME | ID | VALUE

I created two objects, one for the PK TestObjectPK  (NAME, ID), and other TestObject (VALUE).


