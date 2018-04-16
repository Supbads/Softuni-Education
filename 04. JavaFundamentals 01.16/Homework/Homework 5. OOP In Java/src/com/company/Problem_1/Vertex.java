package com.company.Problem_1;

public class Vertex {
    protected double x;
    protected double y;

    public Vertex(double x,double y) {
        this.x = x;
        this.y = y;
    }

    public static double getDistanceBetweenPoints(Vertex a, Vertex b) {
        double accumulatePointSum = 0;

        for (int i = 0; i < 1; i++) {
            double differenceBetweenTwoPoints =
                    Math.pow(a.getX() - b.getX() , 2) +
                            Math.pow(a.getY() - b.getY() , 2);

            accumulatePointSum += differenceBetweenTwoPoints;
        }

        double distance = Math.sqrt(accumulatePointSum);

        return distance;
    }

    @Override
    public String toString() {
        return "[x = " + this.x + ", y = " + this.y + "]\n";
    }

    public double getX() {

        return x;
    }

    public void setX(double x) {
        this.x = x;
    }

    public double getY() {
        return y;
    }

    public void setY(double y) {
        this.y = y;
    }
}
