package com.company.Problem_1;
import java.util.ArrayList;

public abstract class SpaceShape extends Shape implements AreaMeasurable, VolumeMeasurable{

    public SpaceShape(double x, double y,double z) {
        this.vertices = new Vertex3D[1];
        this.vertices[0] = new Vertex3D(x, y, z);
    }

    @Override
    public abstract double getArea();

    @Override
    public abstract double getVolume();

    @Override
    public String toString() {
        return  "Shape type: " + this.getClassName() +
                "\nArea: " + this.getArea() + "\n" +
                "Volume: " + this.getVolume() + "\n" +
                super.toString();
    }
}
