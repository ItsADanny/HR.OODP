# Assignment 1

In this assignment you will make a display for art collections and compare valuable items.

## class ArtCollection

An ArtCollection class represents a collection of valuable art (stored in a list named Collection).

Give this class a generic parameter of type T that is constraint to types that are Valuable and implement ICreator (using a where clause). Change type object to type T throughout the class.

Then finish method PrintCollection so that it prints the Name, CreatorName and Value of each item in the Collection (for example):

> Sprookje by R. Roodkapje (value: 1200)
> 
> Winter by P. Summer (value: 900)

## class PaperCard

One of the things we want to be able to do with collectable cards is determine whether two are equal.

* Make this class implement IEquatable<PaperCard>.
    * The PaperCards are considered equal to each other if their Name, Condition, Series and Rarity have the same values.
    * Do not forget to check for null.
* The Equals method from the Object class should also compare for equality based on the above criteria if the given object has the type PaperCard.
* Additionally, overload the == and != operators.
    * The == operator should use the same logic as the Equals function.
    * The != operator should do the inverse of the == operator.
    * Do not forget to check for null.

## class Valuable

We want to be able to sort collections of valuables. To this end, implement IComparable<Valuable> in this class, then:

* Implement the CompareTo method according to the interface IComparable<Valuable>.
    * Comparison should be based on the following properties:
        * First by Name (alphabetically)
        * Then by Value (from lowest to highest)