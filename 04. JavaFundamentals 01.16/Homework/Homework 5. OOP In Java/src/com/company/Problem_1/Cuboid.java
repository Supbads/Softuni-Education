package com.company.Problem_1;


public class Cuboid extends SpaceShape {
    private double width;
    private double height;
    private double depth;

    public Cuboid(double x, double y, double z, double width, double height, double depth) {
        super(x, y, z);
        this.width=width;
        this.depth=depth;
        this.height=height;
    }

    public double getWidth() {
        return width;
    }

    public void setWidth(double width) {
        this.width = width;
    }

    public double getDepth() {
        return depth;
    }

    public void setDepth(double depth) {
        this.depth = depth;
    }

    public double getHeigth() {
        return height;
    }

    public void setHeigth(double heigth) {
        this.height = heigth;
    }

    @Override
    public double getArea() {
        return (this.getWidth() * this.getDepth() +
                this.getWidth() * this.getHeigth() +
                this.getHeigth() * this.getDepth());
    }

    @Override
    public double getVolume() {
        return this.getDepth()*this.getWidth()*this.getHeigth();
    }
}
