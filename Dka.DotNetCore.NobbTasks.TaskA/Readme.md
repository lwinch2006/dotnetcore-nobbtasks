# Task A

Here I got an idea to implement array of function delegates that will executed asynchronously. Create a class that will hold that array as a property and a function that will execute these asynchronous functions in a loop. Await keyword in a loop makes sure that there is just one function executed at a time.
  
On the other side in main Program class this await function should be left in order execution of the main thread proceeds. Or as I learned by googling could be used construction Task.Run(...) with t.wait() in order to make sure that main thread will wait until background thread finishes before exit.
