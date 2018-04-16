package shapes;

public class Circle extends Shape {
	private double radius;
	
	public Circle(double x, double y, double radius) {
		super(x, y);
		this.radius = radius;
	}

	public double getRadius() {
		return radius;
	}

	public void setRadius(double radius) {
		this.radius = radius;
	}

	@Override
	public double calculateArea() {
		return Math.PI * this.radius * this.radius;
	}
	
	@Override
	public String toString() {
		return "Circle(" + this.x + ", " + this.y + 
				", r=" + this.radius + ")";
	}
}
