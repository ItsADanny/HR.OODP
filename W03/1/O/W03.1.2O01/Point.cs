public class Point {
    public double X, Y;

    public Point(double x, double y) {
        X = x;
        Y = y;
    }

    //NOTE TO SELF
    //REDO THIS CALCULATION, BECAUSE WE DON'T GET THE DESIRED OUTPUT
    //THIS IS ALSO THE MAIN PART OF THE ASSIGNMENT
    public static double GetEuclideanDistance(Point double_point_1, Point double_point_2) {
        return Math.Floor(Math.Pow((double_point_1.X + double_point_1.X) - (double_point_2.X + double_point_2.X),2) + Math.Pow((double_point_1.Y + double_point_1.Y) - (double_point_2.Y + double_point_2.Y) ,2));
     }
}