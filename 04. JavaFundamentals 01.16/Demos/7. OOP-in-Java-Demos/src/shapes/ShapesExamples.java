package shapes;

public class ShapesExamples {
	public static void main(String[] args) {
		Movable[] movableObjects = new Movable[] {
			new Ball(7, 4),
			new Circle(5, 8, 12),
			new Ball(-2, 10),
			new Rectangle(3, 7, 10, 5),
			new Circle(120, 75, 17.5),
		};
		for (Movable obj : movableObjects) {
			System.out.print(obj);
			obj.move(10, -5);
			System.out.println(" --> " + obj);
		}
		
		System.out.println();
		
		AreaCalculatable[] shapes = new AreaCalculatable[] {
			new Circle(5, 8, 12),
			new Rectangle(3, 7, 10, 5),
			new Rectangle(-1.5, 0, 2, 6),
			new Circle(0, 0, 2.5),
			new Bathroom(2.5, 3.2, 1.85),
		};
		
		for (AreaCalculatable shape : shapes) {
			System.out.println(shape + " --> area = " + shape.calculateArea());
		}
	}
}
