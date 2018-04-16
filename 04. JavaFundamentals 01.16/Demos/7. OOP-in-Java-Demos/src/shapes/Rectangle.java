package shapes;

public class Rectangle extends Shape {
	private double width;
	private double height;

	public Rectangle(double x, double y, double width, double height) {
		super(x, y);
		this.width = width;
		this.height = height;
	}
	
	public double getWidth() {
		return width;
	}

	public void setWidth(double width) {
		this.width = width;
	}

	public double getHeight() {
		return height;
	}

	public void setHeight(double height) {
		this.height = height;
	}

	@Override
	public double calculateArea() {
		return this.width * this.height;
	}
	
	@Override
	public String toString() {
		return "Rect(" + this.x + ", " + this.y + 
				", size: " + this.width + " x " + this.height + ")";
	}	
}
