package com.company.Problem_1;


public class Circle extends PlaneShape{
    private double radius;
    public Circle(double x, double y, double radius) {
        super(x, y);
        this.radius = radius;
    }

    public double getRadius(){
        return this.radius;
    }
    public void setRadius(double radius){
        this.radius = radius;
    }

    @Override
    public double getArea() {
        return 3.14159265358979*Math.pow(getRadius(),2);
    }

    @Override
    public double getPerimeter() {
        return 3.1415926535*2*getRadius();
    }
}
