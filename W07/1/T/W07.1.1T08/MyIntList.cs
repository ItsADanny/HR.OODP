public class MyIntList : MyGenericList<int> {
    public MyIntList(List<int> elems) : base(elems)=> Elems = elems;
    public override int Combine()
    {
        int returnValue = 0;
        foreach (int item in Elems) {
            returnValue += item;
        }
        return returnValue;
    }
}