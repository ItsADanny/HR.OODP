namespace RollTheDice.Tests;

[TestClass]
public class RollTheDiceTest
{
    /*
        Test the creation of a die. Check if the value of a die does not exceed the specified sides. For example a six sided dice should have a rolled a value BETWEEN 1 and 6 (inclusive). Also check if both fields have been set correctly.

        Use the following Assert methods:
        - Assert.AreEqual
        - Assert.IsNotNull
        - Assert.IsTrue
    */
    [TestMethod]
    public void Create_Die()
    {
        //Check if the side has 6 sides
        Assert.AreEqual(new Die(6, "White").Sides, 6);
        //Check if the sides are registerd and does not return a null for the value of this field
        Assert.IsNotNull(new Die(6, "White").Sides);
        //Check if the die has between 1 and 6 sides
        Assert.IsTrue(new Die(6, "White").Sides >= 1 & new Die(6, "White").Sides <= 6);
    }

    /*
        Test the Roll method of multiple dice (4,6,8,10 and 20 sided). Like in the Create_Die test, check if the value of a die does not exceed the specified sides. For each die, call the Roll method 10 times (in a for loop) and assert the result after each method call.

        Use the following Assert methods:
        - Assert.IsTrue
    */
    [DataTestMethod]
    [DataRow(4)]
    [DataRow(6)]
    [DataRow(8)]
    [DataRow(10)]
    [DataRow(20)]
    public void Roll_Die(int sides)
    {
        //Create a new die with the sides that we are currently testing
        Die die = new Die(sides, "White");
        //Perform the die.Roll() method 10 times to check if the result is between 1 and our currently testing amount of sides
        for (int i = 0; i != 10; i++) {
            die.Roll();
            int die_value = die.Value;
            Assert.IsTrue(die_value >= 1 & die_value <= sides);
        }
    }

    /*
        Test the creation of an empty DiceBag object. Check that the Dice field is not NULL and contains zero dice objects.
        
        Use the following Assert methods:
        - Assert.IsNotNull
        - Assert.AreEqual
    */
    [TestMethod]
    public void Create_DiceBag()
    {
        Assert.IsNotNull(new DiceBag().Dice);
        Assert.AreEqual(new DiceBag().Dice.Count(), 0);
    }

    /*
        Test the Add method by adding multiple sided dice to a dice bag. Check that the Dice field contains the correct number of dice, that all dice contained in the Dice field are not NULL and that the values of all dice do not exceed the specified sides.
        
        Use the following Assert methods:
        - Assert.AreEqual
        - Assert.IsTrue
        - CollectionAssert.AllItemsAreNotNull
    */
    [TestMethod]
    public void Add_DiceToDiceBag()
    {
        List<int> lSides = new() { 4, 6, 8, 10, 20, 100 };

        // create new dice bag
        DiceBag diceBag = new DiceBag();

        foreach (int side in lSides)
        {
            // create a die for each side in the lSides list
            diceBag.Add(new Die(side, "White"));
        }

        // asserts
        Assert.AreEqual(diceBag.Dice.Count(), 6);
        foreach (Die die in diceBag.Dice) {
            Assert.IsTrue(die.Value >= 1 & die.Value <= die.Sides);
        }
        CollectionAssert.AllItemsAreNotNull(diceBag.Dice);
    }

    /*
        Test the Reroll method of a dice bag after adding multiple sided dice to a dice bag. Check if the current value of all die in the dice bag does not exceed the specified sides.
        
        Use the following Assert methods:
        - Assert.IsTrue
    */
    [TestMethod]
    public void Reroll_AllDiceInDiceBag()
    {
        List<int> lSides = new() { 4, 6, 8, 10, 20, 100 };

        // create new dice bag
        DiceBag diceBag = new DiceBag();

        foreach (int side in lSides)
        {
            // create a die for each side in the lSides list
            diceBag.Add(new Die(side, "White"));
        }

        // reroll all the dice in the bag
        // asserts
        diceBag.Reroll();
        foreach (Die die in diceBag.Dice) {
            Assert.IsTrue(die.Value >= 1 & die.Value <= die.Sides);
        }
    }
}