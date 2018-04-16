package com.company.Problem_1;
import java.util.ArrayList;

public abstract class PlaneShape extends Shape implements AreaMeasurable, PerimeterMeasurable{

    public PlaneShape(double x, double y) {
        this.vertices = new Vertex2D[3];
        this.vertices[0] = new Vertex2D(x, y);
    }

    @Override
    public abstract double getArea();

    @Override
    public abstract double getPerimeter();

    @Override
    public String toString() {
        return "Shape Type: " + this.getClassName() +
                "\nArea: " + this.getArea() +
                "\nPerimeter: " + this.getPerimeter() + "\n" +
                super.toString();
    }

}
