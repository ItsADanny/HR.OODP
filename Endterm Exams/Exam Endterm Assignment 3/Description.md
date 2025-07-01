# Assignment 3

In this assignment you will create a recursive method for determining whether two sentences are each other's reverse. For example, the following two sentences are each other's reverse:

* the quick brown fox
* fox brown quick the

## class SentenceAnalyzer - private method AreReversed

Implement this private recursive method, which takes two Sentence objects and determines whether their Words are the reverse of each other.

Hint: compare Words starting from the beginning of the first Sentence and the end of the second Sentence.

Requirements:
* The method must use recursion.
* If the WordCount of the Sentences are not the same, they are not considered to be each other's reverse.

## class SentenceUtils method FilterSentences

Implement this method so that it:

* Accepts a List<Sentence> and a lambda that:
    * takes a Sentence and returns a bool.
* Returns a new List<Sentence> containing only the Sentences that satisfy the lambda condition.

In other words, call the lambda on each Sentence, and include only those where it returns true.