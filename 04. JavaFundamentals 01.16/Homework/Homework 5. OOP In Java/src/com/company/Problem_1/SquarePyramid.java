package com.company.Problem_1;


public class SquarePyramid extends SpaceShape {
    private double baseWidth;
    private double height;
    private double slantHeight;

    public SquarePyramid(double x, double y, double z, double baseWidth, double height, double slantHeight) {
        super(x, y, z);
        this.baseWidth = baseWidth;
        this.height=height;
        this.slantHeight=slantHeight;
    }

    public double getBaseWidth() {
        return baseWidth;
    }

    public void setBaseWidth(double baseWidth) {
        this.baseWidth = baseWidth;
    }

    public double getSlantHeight() {
        return slantHeight;
    }

    public void setSlantHeight(double slantHeight) {
        this.slantHeight = slantHeight;
    }

    public double getHeight() {
        return height;
    }

    public void setHeight(double height) {
        this.height = height;
    }

    @Override
    public double getArea() {
        double faceArea = (1.0 / 2.0) * (4 * this.getBaseWidth() * this.getHeight());
        double baseArea = this.getBaseArea();

        return faceArea + baseArea;
    }

    private double getBaseArea() {
        return this.baseWidth * this.baseWidth;
    }

    @Override
    public double getVolume() {
        return (1.0 / 3.0) * this.getBaseArea() * this.height;
    }
}
