Wilson Score for C#
===================

You shouldn't use average for your scores.

Here's why:

Item A has 900 upvotes and 100 downvotes, resulting in an average of 90% likes. <br />
Item B just came up in your database, it has 1 upvote and 0 downvotes, resulting in 100% likes! Woot!

That's not what you want, is it?

That's exactly the problem that [Wilson Score](http://en.wikipedia.org/wiki/Binomial_proportion_confidence_interval#Wilson_score_interval) solves.

I found out about this on '[How Not To Sort By Average Rating](http://www.evanmiller.org/how-not-to-sort-by-average-rating.html)'. Give it a read.

**Tl;dr**: Wilson Score takes into account that a higher number of votes has more chance to be a correct representation of the general opinion. It basically answers the question **Given the ratings I have, there is a 95% chance that the "real" fraction of positive ratings is at least what?**

If you still think you should sort by average, know that Reddit [uses](http://amix.dk/blog/post/19588) this on "best" sorting. [Yelp](http://officialblog.yelp.com/2011/02/the-most-romantic-city-on-yelp-is.html) too.

### Using WilsonScore in your C# projects
Using it is as simple as you would expect:
```C#
Wilson.Score(upvotes, total);
```

By default it uses 95% confidence `(z = 1.644853)`. If you want to change the confidence, you can pass a third parameter, like so:
```C#
Wilson.Score(upvotes, total, 2.326348); // 99% confidence
```

Right now that's all it does, and that's probably all you need anyway.

Notes
==========
Based on the [javascript version](https://github.com/math-utils/wilson-score). <br />
License Apache V2
