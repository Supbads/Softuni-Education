package shapes;

import java.util.Arrays;
import java.util.Comparator;

public class SortingShapes {

	public static void main(String[] args) {
		Shape[] shapes = new Shape[] {
			new Circle(5, 8, 12),
			new Rectangle(3, 7, 10, 5),
			new Rectangle(-1.5, 0, 2, 6),
			new Circle(0, 0, 2.5)
		};
		
		// Sort the shapes increasingly by their area
		Arrays.sort(shapes, new Comparator<Shape>() {
			public int compare(Shape s1, Shape s2) {
				return Double.compare(s1.calculateArea(), s2.calculateArea());
			}
		});
		
		// Print the shapes with their area
		Arrays.stream(shapes).forEach(s -> {
			System.out.printf("Area = %.2f, Shape = %s\n", 
					s.calculateArea(), s);
		});
		
		System.out.println();
		
		// Sort the shapes decreasingly by their area
		Arrays.sort(shapes, (s1,s2) -> 
			-Double.compare(s1.calculateArea(), s2.calculateArea()));		

		// Print the shapes with their area
		Arrays.stream(shapes).forEach(s -> {
			System.out.printf("Area = %.2f, Shape = %s\n", 
					s.calculateArea(), s);
		});
	}
}
