# Task C

As I quickly thought this task can be implemented by following methods in my opinion.
* It could be created ServiceBus service in Azure and stores can send messages to it to some queue after purchases happen and some microservice gets new messages from queue and stores to database.
* Stores can save purchases to some database (per store) and some time during the day (for example at midnight) some microservice uses API to fetch data from the stores and map it to Elasticsearch index so that data from all stores globally.
* It could be used Azure Queue storage and so that stores send messages about new purchases there. And it could be created Azure Function that will fetch new messages from the queue and save them to database, Elasticsearch index, etc.

In my opinion I would prefer to implement first those 3rd alternative, with Azure Queue Storage and Azure Function.

 