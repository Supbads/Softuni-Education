package com.company.Problem_1;


public class Rectangle extends PlaneShape{
    private double width;
    private double height;

    public Rectangle(double a,double b,double width,double height) {
        super(a,b);
        this.width=width;
        this.height=height;
    }

    public double getHeight() {
        return height;
    }

    public void setHeight(double height) {
        this.height = height;
    }

    public double getWidth() {
        return width;
    }

    public void setWidth(double width) {
        this.width = width;
    }

    @Override
    public double getArea() {
        double area = this.getHeight()*this.getWidth();

        return area;
    }

    @Override
    public double getPerimeter() {
        double perimeter = this.getWidth()*2 + this.getHeight()*2;

        return perimeter;
    }
}
