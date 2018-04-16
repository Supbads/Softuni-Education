package com.company.Problem_1;


public class Sphere extends SpaceShape{
    private double radius;

    public Sphere(double a, double b, double c, double radius) {
        super(a,b,c);
        this.radius = radius;
    }

    public double getRadius() {
        return radius;
    }

    public void setRadius(double radius) {
        this.radius = radius;
    }

    @Override
    public double getArea() {
        return 4.0 * Math.PI * Math.pow(this.getRadius(), 2);
    }

    @Override
    public double getVolume() {
        return (4.0 / 3.0) * Math.PI * Math.pow(this.getRadius(), 3);
    }
}
