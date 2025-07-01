# Assignment 4

Note: use of LINQ in this assignment is recommended but not mandatory.

In this assignment you are developing part of an application for a moving company.

## class Furniture

You don't need to modify this class, but do note that it has properties Name, Volume, Value, and IsInsured.

## enum VanCapacity

Create the enum VanCapacity in VanCapacity.cs. It should have the following members and values:

* Small: 15,
* Medium: 20,
* Large: 30

## class Van

This class will contain the functionality for the moving van.

#### Properties

Add the following read/write properties

* Capacity: an enum of type VanCapacity.
* Contents: a Stack of type Furniture. Don't forget to initialize this.
* UsedVolume: an int.

#### Constructor

* Takes the capacity (of type VanCapacity) and sets the respective property.
* Contents should be initialized and empty.
* UsedVolume should be 0.

#### Method ToString

This method should return a string representation of the Van including the integer representation of the Capacity, the UsedVolume, and the names of the furniture items in the van. For example:

> Capacity: 30
> Used: 20
> Contents: Lamp Computer Fridge Sofa TV

An example for an empty van:

> Capacity: 30
> Used: 0
> Contents:

#### Method Load

Check if the Furniture can be loaded without exceeding the van's Capacity. If it can, add the furniture to the Contents stack and update the UsedVolume. Return true if the furniture was loaded successfully, otherwise return false.

#### Method Unload

This method should remove each Furniture item from the Contents stack and update the UsedVolume accordingly. Return a list of all furniture items removed from the van.

## class House

This class will contain the functionality for reporting on the furniture in the house.

#### Method TotalInsuredValue

This method calculates the total value of all insured furniture items and returns it. (You may assume the FurnitureList is never null or empty). For example, the method would return 1400 with the following FurnitureList:

> TV       - Volume: 5 m3, Value: 700 Euro, Insured: False
> Sofa     - Volume: 4 m3, Value: 900 Euro, Insured: True
> Fridge   - Volume: 2 m3, Value: 500 Euro, Insured: True

#### Method GetFurnitureAboveValue

This method returns a list of Furniture items that have a value greater than the specified amount. The List is sorted first by insurance status (uninsured items first) and then by value. (You may assume the FurnitureList is never null or empty.) For example, when sent 100 and the following FurnitureList

> Lamp     - Volume: 6 m3, Value: 500 Euro, Insured: True
> Sofa     - Volume: 4 m3, Value: 900 Euro, Insured: False
> TV       - Volume: 5 m3, Value: 700 Euro, Insured: False
> Fridge   - Volume: 2 m3, Value: 100 Euro, Insured: True

the method would return the following List of Furniture:

> TV       - Volume: 5 m3, Value: 700 Euro, Insured: False
> Sofa     - Volume: 4 m3, Value: 900 Euro, Insured: False
> Lamp     - Volume: 6 m3, Value: 500 Euro, Insured: True