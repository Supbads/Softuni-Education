package com.company.Problem_1;
import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

public class Problem_1_Geometry {
    public static void main(String[] args) {
//        Triangle triangle = new Triangle(1,1,4,8,4,3);
//        System.out.println("The perimeter of the triangle:"+ triangle.getPerimeter());
//        System.out.println();
//        System.out.println("The area of the triangle: "+ triangle.getArea());
//        System.out.println();
//
//        PlaneShape rectangle = new Rectangle(2,7,5.5,9);
//        System.out.println("Perimeter of the rectangle: " + rectangle.getPerimeter());
//        System.out.println();
//        System.out.println("The area of the rectangle: " + rectangle.getArea());
//        System.out.println();
//
//        PlaneShape circle = new Circle(5,5,2);
//        System.out.println("The area of the circle: "+ circle.getArea());
//        System.out.println();
//        System.out.println("The perimeter of the circle: "+circle.getPerimeter());
//        System.out.println();
//
//        SpaceShape cuboid = new Cuboid(2,3,4,5,6,7);
//        System.out.println("The area of the cuboid:");
//        System.out.println(cuboid.getArea());
//        System.out.println("The volume of the cuboid");
//        System.out.println(cuboid.getVolume());
//
//        SpaceShape sphere = new Sphere(4,5,6,3);
//        System.out.println("The area of the sphere: " + sphere.getArea());
//        System.out.println("The volume of the sphere: "+ sphere.getVolume());

        Shape[] shapes = new Shape[6];
        shapes[0] = new Triangle(1, -7, 3, 11, 20, 30);
        shapes[1] = new Rectangle(10, -70, 3, 22);
        shapes[2] = new Circle(122, -17, 13);
        shapes[3] = new Cuboid(1, -7, 3, 11, 20, 30);
        shapes[4] = new SquarePyramid(1, -5, 3, 10, 1, 2);
        shapes[5] = new Sphere(97, -12, 3, 50);

//        for (Shape shape : shapes) {
//            System.out.println(shape);
//        }

        List<Shape> largeVolumeShapes = Arrays.asList(shapes)
                .stream()
                .filter(s -> s instanceof VolumeMeasurable)
                .filter(v -> ((VolumeMeasurable) v)
                        .getVolume() > 40)
                .collect(Collectors.toList());

//        for (Shape shape : largeVolumeShapes) {
//            System.out.println(shape);
//        }

        Comparator<Shape> byPerimeter = (s1, s2) -> {
            PerimeterMeasurable Shape1 = (PerimeterMeasurable) s1;
            PerimeterMeasurable Shape2 = (PerimeterMeasurable) s2;
            double perimeterShape1 = Shape1.getPerimeter();
            double perimeterShape2 = Shape2.getPerimeter();

            return perimeterShape1 < perimeterShape2 ? -1 :
                    perimeterShape1 > perimeterShape2 ? 1 : 0;
        };

        List<Shape> planeShapesByPerimeter = Arrays.asList(shapes)
                .stream()
                .filter(p -> p instanceof PlaneShape)
                .sorted(byPerimeter)
                .collect(Collectors.toList());

        for (Shape shape : planeShapesByPerimeter) {
            System.out.println(shape);
        }

    }
}
