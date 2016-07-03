Wilson Score for C# ![](https://img.shields.io/nuget/v/WilsonScore.svg?style=flat)
===================
![](https://raw.githubusercontent.com/akamud/wilson-score-csharp/master/logo-256.png)

You shouldn't use average for your scores.

Here's why:

Item A has 900 upvotes and 100 downvotes, resulting in an average of 90% likes. <br />
Item B just came up in your database, it has 1 upvote and 0 downvotes, resulting in 100% likes! Woot!

Now Item B will come first than Item A. That's not what you want, is it?

That's exactly the problem that [Wilson Score](http://en.wikipedia.org/wiki/Binomial_proportion_confidence_interval#Wilson_score_interval) solves.

I found out about this on '[How Not To Sort By Average Rating](http://www.evanmiller.org/how-not-to-sort-by-average-rating.html)'. Give it a read.

**Tl;dr**: Wilson Score takes into account that a higher number of votes has more chance to be a correct representation of the general opinion. It basically answers the question: **Given the ratings I have, there is a 95% chance that the "real" fraction of positive ratings is at least what?**

If you still think you should sort by average, know that Reddit [uses](http://amix.dk/blog/post/19588) this on "best" sorting. [Yelp](http://officialblog.yelp.com/2011/02/the-most-romantic-city-on-yelp-is.html) too.

Using WilsonScore in your C# projects
=========
Nuget package available [here](https://www.nuget.org/packages/WilsonScore/), install it with
```
PM> Install-Package WilsonScore
```

Using it is as simple as you would expect:
```C#
Wilson.Score(upvotes, total);
```

By default it uses 90% confidence `(z = 1.644853)`. If you want to change the confidence, you can pass a third parameter, like so:
```C#
Wilson.Score(upvotes, total, 1.96); // 95% confidence
// or
Wilson.Score(upvotes, total, 2.326348); // 99% confidence
```

Using Wilson Score on the case mentioned at the start would give these values:

Item | Average Score | Wilson Score
:----: | :-------: | :------------:
Item A | 90%  | 88.32%
Item B | 100% | 26.98%

Wilson Score puts Item A in a better position, now everyone is happy.

Right now that's all it does, and that's probably all you need anyway.

Supported Platforms
==========
.NET Framework 4+ <br />
Silverlight 5+  <br />
Windows 8+  <br />
Windows Phone 8.1+  <br />
Windows Phone Silverlight 8  <br />
Xamarin.Android  <br />
Xamarin.iOS  <br />

Notes
==========
Based on the [javascript version](https://github.com/math-utils/wilson-score) by [Jonathan Ong](https://github.com/jonathanong). <br />
[MIT License](https://github.com/akamud/wilson-score-csharp/blob/master/LICENSE)
