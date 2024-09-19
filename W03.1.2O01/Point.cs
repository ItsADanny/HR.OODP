using System.Security.Cryptography.X509Certificates;

public class Point {
    public static double X, Y;

    public Point(double x, double y) {
        X = x;
        Y = y;
    }

    public static double EuclideanDistance(double double_point_1, double double_point_2) {
        return Math.Floor(Math.Pow((double_point_1 + X) - (double_point_2 + X),2) + Math.Pow((double_point_1 + Y) - (double_point_2 + Y) ,2));
    }
}