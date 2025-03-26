public class MyBoolList : MyGenericList<bool> {
    public MyBoolList(List<bool> elems) : base(elems)=> Elems = elems;
    public override bool Combine()
    {
        int trues = 0;
        foreach (bool item in Elems) {
            if (item) {
                trues++;
            }
        }
        return (trues > Elems.Count()) ? true : false;
    }
}