Prerequisites:

 * .NET Core 3 SDK, 3.0.100-preview3-010364 or later
   Download nightly builds from https://github.com/dotnet/core-sdk/blob/master/README.md#installers-and-binaries
 * VS2019 Preview 3 or later (I'm using Preview 3, haven't checked this on Preview 4 yet)

Steps:

 1. Open RazorComponentsSentimentAnalysis.sln in VS
 2. Wait for VS to finish restoring packages, if this is the first time you opened this solution
 3. Run (e.g., Ctrl+F5)
 4. Navigate to "Review" using link on left of page
 5. Start typing in the box. No need to click "Submit" (it isn't wired up to do anything)

The ML model is very simplistic and only produces good results with certain phrases. Example of a useful thing to type, so that the score gets progressively worse/better as you're typing:

 - This is terrible - it sucks! I never want to see this again!

Then trying editing that to:

 - This is great - it rocks! I DEFINITELY want to see this again!

Notes on the code:

 * It's using a fairly old version of ML.NET, and is using the "Legacy" APIs. It could use an update.
 * As mentioned above, the included SentimentModel.zip is very simplistic and was not trained on a large corpus of data. Its effectiveness isn't really any better than a naive keyword search. If you wanted to get more advanced, RNNs (e.g., LSTM or GRU) can produce vastly better results with much richer language modelling. The ML.NET-specific code is all in Services\Sentiment.cs and should be easy to replace.
