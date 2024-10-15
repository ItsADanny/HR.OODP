//This is a way to make our own generic which can accept your variables.
//This however does take alot of managing
// class GradeForm<T> {
//     public T Grade;

//     public GradeForm(T grade) => Grade = grade;

//     public bool IsPass() {
//         if (Grade is double d) {
//             return d >= 5.5;
//         }
//         if (Grade is bool b) {
//             return b;
//         }
//         throw new NotImplementedException();
//     }
// }


abstract class GradeForm<T> {
    public T Grade;

    public GradeForm(T grade) => Grade = grade;

    public abstract bool IsPass();
}